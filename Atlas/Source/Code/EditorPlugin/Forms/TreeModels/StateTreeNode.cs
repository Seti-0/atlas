using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality.Editor;
using Duality.Editor.Properties;

using Soulstone.Duality.Plugins.Atlas.State;
using Soulstone.Duality.Editor.Plugins.Atlas.Base;

namespace Soulstone.Duality.Editor.Plugins.Atlas.Base
{
    /// <summary>
    /// Represents a node in a TypeTreeModel, which corresponds to a namespace. 
    /// </summary>
    public class StateTreeNode : SortedTreeNode<StateTreeNode, StateTreeItem>
    {
        public GameObject GameObj { get; }

        public StateTreeNode(StateTreeNode parent, GameObject gameObj)
            : base(parent, gameObj?.Name, typeof(global::Duality.GameObject).GetEditorImage()) 
        {
            GameObj = gameObj;
        }
    }
}
