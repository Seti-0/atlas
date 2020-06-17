using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

using Aga.Controls.Tree;

using Duality.Editor;

using Soulstone.Duality.Plugins.Atlas.State;
using Soulstone.Duality.Editor.Plugins.Atlas.Base;

namespace Soulstone.Duality.Editor.Plugins.Atlas
{
    public class StateTreeModel : SortedTreeModel<StateTreeNode, StateTreeItem>
	{
        private Scene _scene;

        public Scene Scene
        {
            get => _scene;

            set
            {
                RegisterEvents(value, _scene);
                _scene = value;
                ApplyStructure();
            }
        }

        protected override string EmptyMessage
        {
            get { return "No GameObjects or Components found"; }
        }

        public StateTreeModel(Scene scene = null)
		{
            _scene = scene ?? Scene.Current;
            RegisterEvents(_scene);

            Scene.Entered += OnSceneEvent;
            Scene.Leaving += OnSceneEvent;
		}

        protected override void OnInit()
        {
            ShowEmptyMessage = false;
            SetScene();
        }

        private void SetScene()
        {
            RootNodes.Clear();

            if (_scene == null)
                return;

            foreach (var obj in _scene.RootObjects)
            {
                var root = new StateTreeNode(null, obj);
                PopulateNode(obj, root);
                RootNodes.Add(root);
            }
        }

        private void PopulateNode(GameObject obj, StateTreeNode parentNode)
        {
            foreach (var child in obj.Children)
            {
                var childNode = new StateTreeNode(parentNode, child);
                parentNode.ChildNodes.Add(childNode.Name, childNode);

                PopulateNode(child, childNode);
            }

            foreach (var component in obj.Components)
            {
                StateTreeItem item = new StateTreeItem(component);
                parentNode.ChildLeaves.Add(item.Name, item);
            }
        }

        private void RegisterEvents(Scene newScene, Scene oldScene = null)
        {
            if (oldScene != null)
            {
                oldScene.ObjectAdded -= OnSceneEvent;
                oldScene.ObjectRemoved -= OnSceneEvent;
                oldScene.ComponentAdded -= OnSceneEvent;
                oldScene.ComponentRemoved -= OnSceneEvent;
                oldScene.ParentChanged -= OnSceneEvent;
            }

            if (newScene != null)
            {
                newScene.ObjectAdded += OnSceneEvent;
                newScene.ObjectRemoved += OnSceneEvent;
                newScene.ComponentAdded += OnSceneEvent;
                newScene.ComponentRemoved += OnSceneEvent;
                newScene.ParentChanged += OnSceneEvent;
            }
        }

        private void OnSceneEvent(object sender, EventArgs e)
        {
            SetScene();
            ApplyStructure();
        }
	}
}
