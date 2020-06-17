using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Linq;

using Duality.Serialization;
using Duality.Editor;
using System.IO;

using Soulstone.Duality.Editor.Plugins.Atlas.Forms;
using Soulstone.Duality.Plugins.Atlas.State;

namespace Soulstone.Duality.Editor.Plugins.Atlas.EditorActions
{
    public class Inspect : EditorAction<object> //(Stop it appearing in the editor for now)
    {
        /* 
         This is a WIP. I probably won't come back to it for a while.
             */

        public override string Name => "Inspect Scene";

        public override void Perform(IEnumerable<object> objEnum)
        {
            var subject = Scene.Current;

            var dialog = new SceneView(subject);
            dialog.Show();
        }
    }
}
