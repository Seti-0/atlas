using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Editor;

namespace Soulstone.Duality.Plugins.Atlas.Testing
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class FlowTest : Component, ICmpInitializable, ICmpUpdatable, ICmpSerializeListener, ICmpAttachmentListener
    {
        public void OnActivate()
        {
            Report("OnActivate");
        }

        public void OnAddToGameObject()
        {
            Report("OnAddToGameObject");
        }

        public void OnDeactivate()
        {
            Report("OnDeactivate");
        }

        public void OnLoaded()
        {
            Report("OnLoaded");
        }

        public void OnRemoveFromGameObject()
        {
            Report("OnRemoveFromGameObject");
        }

        public void OnSaved()
        {
            Report("OnSaved");
        }

        public void OnSaving()
        {
            Report("OnSaving");
        }

        public void OnUpdate()
        {
            Report("OnUpdate");
        }

        private void Report(string item)
        {
            AtlasApp.TestLog.Write(item);
        }
    }
}
