using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Drawing;
using Duality.Resources;

using Soulstone.Duality.Plugins.Atlas.Interface;
using Soulstone.Duality.Plugins.Atlas.Network;
using Soulstone.Duality.Plugins.Atlas.Sync;

namespace Soulstone.Duality.Plugins.Atlas
{
    public static class SyncManager
    {
        private static void CheckInput(ICmpHostComponent component)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));

            var dualityComponent = component as Component;

            if (dualityComponent == null) throw new ArgumentException("ICmpHostComponent must be a Duality Component");
            if (dualityComponent.Scene == null) throw new ArgumentException("component must be a part of a scene");

            CheckClientType(component);
        }

        private static void CheckClientType(ICmpHostComponent component)
        {
            var clientType = component.GetClientComponentType();

            if (clientType == null) throw new ArgumentException("component client type" +
                " cannot be null");

            if (!typeof(ICmpClientComponent).GetTypeInfo().IsAssignableFrom(clientType.GetTypeInfo()))
                throw new ArgumentException("component client type must be assignable to ICmpClientComponent");

            bool parameterlessConstructorFound = false;

            var typeInfo = clientType.GetTypeInfo();
            while (typeInfo != null)
            {
                foreach (var constructor in typeInfo.DeclaredConstructors)
                {
                    if (constructor.GetParameters().Length == 0)
                        parameterlessConstructorFound = true;
                }

                typeInfo = typeInfo.GetBaseTypeInfo();
            }

            if (!parameterlessConstructorFound)
                throw new ArgumentException("component client type must declare a parameterless constructor");
        }

        public static void PushParentChanged(GameObject obj, GameObject oldParent, GameObject newParent, 
            PeerInfo target = null)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var message = SyncMessageHelper.GetParentChangedMessage(obj, oldParent, newParent);
            message.MessageType = MessageType.ObjectParentChanged;

            SendMessageFromHost(message, target);
        }

        public static void PushGameObjectName(GameObject obj, string oldName, string newName,
            PeerInfo target = null)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (oldName == null) throw new ArgumentNullException(nameof(oldName));
            if (newName == null) throw new ArgumentNullException(nameof(newName));

            var message = SyncMessageHelper.GetRenameMessage(obj, oldName, newName);
            message.MessageType = MessageType.ObjectNameChanged;

            SendMessageFromHost(message, target);
        }

        public static void PushComponentActivation(IEnumerable<ICmpHostComponent> components, 
            PeerInfo target = null)
        {
            foreach (var component in components)
                CheckInput(component);

            var message = SyncMessageHelper.GetComponentMessage(components);
            message.MessageType = MessageType.ComponentActivationCollection;

            SendMessageFromHost(message, target);
        }

        public static void PushComponentActivation(ICmpHostComponent component, 
            PeerInfo target = null)
        {
            CheckInput(component);

            var message = SyncMessageHelper.GetComponentMessage(component);
            message.MessageType = MessageType.ComponentActivation;

            SendMessageFromHost(message, target);
        }

        public static void PushComponentDeactivation(IEnumerable<ICmpHostComponent> components, 
            PeerInfo target = null)
        {
            foreach (var component in components)
                CheckInput(component);

            var message = SyncMessageHelper.GetComponentMessage(components);
            message.MessageType = MessageType.ComponentDeactivation;

            SendMessageFromHost(message, target);
        }

        public static void PushComponentDeactivation(ICmpHostComponent component, 
            PeerInfo target = null)
        {
            CheckInput(component);

            var message = SyncMessageHelper.GetComponentMessage(component);
            message.MessageType = MessageType.ComponentDeactivation;

            SendMessageFromHost(message, target);
        }

        public static void PushData(ICmpHostComponent component, 
            PeerInfo target = null)
        {
            CheckInput(component);

            var message = SyncMessageHelper.GetDataMessage(component);
            message.MessageType = MessageType.ComponentData;

            SendMessageFromHost(message, target);
        }

        public static void PushAll(PeerInfo target = null)
        {
            var items = Scene.Current.FindComponents<ICmpHostComponent>();

            // This is silly. Perhaps an attribute that can be checked against the type
            //  as a whole instead?
            foreach (var item in items)
                CheckClientType(item);

            var message = SyncMessageHelper.GetDataMessage(items);
            message.MessageType = MessageType.FullSync;

            SendMessageFromHost(message, target);
        }

        public static void RequestSync()
        {
            var message = SyncMessageHelper.GetSyncRequestMessage();
            message.MessageType = MessageType.SyncRequest;

            SendMessageFromClient(message);
        }

        private static void SendMessageFromHost(SyncMessage message, PeerInfo target)
        {
            if (AtlasApp.Server == null) return;
            if (!AtlasApp.Server.Connected) return;

            var data = SerializationHelper.GetBytes(message);

            if (target == null)
            {
                AtlasApp.Server.SendData(data, DeliveryMethod.ReliableOrdered, 0);
            }
            else
            {
                AtlasApp.Server.SendData(data, DeliveryMethod.ReliableOrdered, 0, target);
            }
        }

        private static void SendMessageFromClient(SyncMessage message)
        {
            if (AtlasApp.Client == null) return;
            if (!AtlasApp.Client.Connected) return;

            var data = SerializationHelper.GetBytes(message);
            AtlasApp.Client.SendData(data, DeliveryMethod.ReliableOrdered, 0);
        }

        public static bool TryParseData(byte[] data, PeerInfo sender)
        {
            var success = SerializationHelper.TryGetObject(data, out SyncMessage message);

            if (success)
                ParseMessage(message, sender);
            else
            {
                Logs.Game.WriteWarning($"Unrecognised incoming data from {sender.ToLongString()}");
                Logs.Game.Write(Encoding.UTF8.GetString(data, 0, data.Length));
            }

            return success;
        }

        private static bool CheckConversion(object result, SyncMessage source)
        {
            if (result == null)
            {
                AtlasLogs.Network.WriteWarning($"Message of type {source.MessageType} was" +
                    $" of unexpected Type {source.GetType().Name}");
            }

            return true;
        }

        private static void ParseMessage(SyncMessage message, PeerInfo sender)
        {
            if (message.MessageType == MessageType.SyncRequest)
            {
                AtlasLogs.Sync.Write($"Sync request from {sender} acknowledged");
                PushAll(sender);
            }

            else if (message.MessageType == MessageType.ComponentActivation)
            {
                var content = message as SyncComponentSingle;

                if (CheckConversion(content, message))
                {
                    if (SyncMessageHelper.TryReadComponentMessage(content, out Type type))
                    {
                        SceneHelper.Activate(content.Path, type);
                    }
                }
            }

            else if (message.MessageType == MessageType.ComponentActivationCollection)
            {
                var content = message as SyncComponentCollection;

                if (CheckConversion(content, message))
                {
                    if (SyncMessageHelper.TryReadComponentMessage(content, out Type[] types))
                    {
                        SceneHelper.Activate(content.Paths, types);
                    }
                }
            }

            else if (message.MessageType == MessageType.ComponentDeactivation)
            {
                var content = message as SyncComponentSingle;

                if (CheckConversion(content, message))
                {
                    if (SyncMessageHelper.TryReadComponentMessage(content, out Type type))
                    {
                        SceneHelper.Deactivate(content.Path, type);
                    }
                }
            }

            else if (message.MessageType == MessageType.ComponentDeactivationCollection)
            {
                var content = message as SyncComponentCollection;

                if (CheckConversion(content, message))
                {
                    if (SyncMessageHelper.TryReadComponentMessage(content, out Type[] types))
                    {
                        SceneHelper.Deactivate(content.Paths, types);
                    }
                }
            }

            else if (message.MessageType == MessageType.ComponentData)
            {
                var content = message as SyncDataSingle;

                if (CheckConversion(content, message))
                {
                    if (SyncMessageHelper.TryReadComponentMessage(content, out Type type))
                    {
                        SceneHelper.Update(content.Path, type, content.Data);
                    }
                }
            }

            else if (message.MessageType == MessageType.ObjectNameChanged)
            {
                var content = message as SyncRename;

                if (CheckConversion(content, message))
                {
                    if (SyncMessageHelper.CheckGameObjectMessage(content))
                    {
                        SceneHelper.ChangeName(content.Path, content.NewName);
                    }
                }
            }

            else if (message.MessageType == MessageType.ObjectParentChanged)
            {
                var content = message as SyncParentChanged;

                if (CheckConversion(content, message))
                {
                    if (SyncMessageHelper.CheckGameObjectMessage(content))
                    {
                        SceneHelper.ChangeParent(content.Path, content.NewParentPath);
                    }
                }
            }

            else if (message.MessageType == MessageType.FullSync)
            {
                var content = message as SyncDataCollection;

                if (CheckConversion(content, message))
                {
                    if (SyncMessageHelper.TryReadComponentMessage(content, out Type[] types))
                    {
                        SceneHelper.FullSync(content.Paths, types, content.Data);
                    }
                }
            }
        }
    }
}
