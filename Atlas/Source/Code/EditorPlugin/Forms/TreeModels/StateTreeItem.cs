using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality.Editor;
using Duality.Editor.Properties;

using Soulstone.Duality.Plugins.Atlas.State;

using Soulstone.Duality.Editor.Plugins.Atlas.Base;
using System.Drawing;

namespace Soulstone.Duality.Editor.Plugins.Atlas
{
    public class StateTreeItem : SortedTreeItem
    {
        public Component Content { get; }

        public StateTreeItem(Component content) 
            : base(content?.ToString(), content?.GetType()?.GetEditorImage() ??
                  typeof(global::Duality.Component).GetEditorImage())
        {
            Content = content;
        }

        protected override int GetScore(string nameHint, int depthLimit)
        {
            if (Content == null) return 0;

            return StringHelper.CoderScore(Content.GameObj.FullName,
                typeof(ContentAlignment).Name, nameHint);
        }
    }
}
