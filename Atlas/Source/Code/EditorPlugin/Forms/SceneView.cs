using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using WeifenLuo.WinFormsUI.Docking;

using Aga.Controls.Tree;
using Aga.Controls.Tree.NodeControls;

using Soulstone.Duality.Plugins.Atlas.State;

using Soulstone.Duality.Editor.Plugins.Atlas;
using Soulstone.Duality.Editor.Plugins.Atlas.Properties;

namespace Soulstone.Duality.Editor.Plugins.Atlas.Forms
{
    public partial class SceneView : DockContent
    {
        /*
         * Note to future self: If forms starts having problems with a "Duality. ... .CueTextbox", just remove the namespace
         * i.e. new CueTextBox in the auto-generated code.
         */

        private StateTreeModel _sceneModel;

        private bool _expandAll = true;

        private string _startingText = "";

        public string StartingText
        {
            get => _startingText;

            set
            {
                _startingText = value ?? "";
            }
        }

        public SceneView(Scene subject = null)
        {
            InitializeComponent();

            // I can't figure out how to make those duality toolbars at the moment
            //toolStrip.Renderer = new global::Duality.Editor.Controls.ToolStrip.DualitorToolStripProfessionalRenderer();

            viewObjectType.NodeControls.Add(iconTreeNode);
            viewObjectType.NodeControls.Add(txtNodeName);

            //txtNodeName.DrawText += treeNodeName_DrawText;

            _sceneModel = new StateTreeModel(subject);
            _sceneModel.Init();
            _sceneModel.Initialized += _typeModel_Initialized;
        }

        private void _typeModel_Initialized(object sender, EventArgs e)
        {
            //UpdateView();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            txtFilter.Text = StartingText;
            txtFilter.SelectAll();

            viewObjectType.Model = _sceneModel;
            _sceneModel.NameHint = txtFilter.Text;
            //UpdateView();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TxtFilterInput_TextChanged(object sender, EventArgs e)
        {
            _sceneModel.NameHint = txtFilter.Text;
            //UpdateView();
        }

        /*private void UpdateView()
        {
            if (_expandAll)
            {
                buttonExpandAll.Image = Resources.expand_active;
                viewObjectType.ExpandAll();
            }
            else
            {
                buttonExpandAll.Image = Resources.expand;
                viewObjectType.CollapseAll();
            }
        }
        */

        private void ButtonExpandAll_Click(object sender, EventArgs e)
        {

        }

        private void viewObjectType_Click(object sender, EventArgs e)
        {

        }
    }
}
