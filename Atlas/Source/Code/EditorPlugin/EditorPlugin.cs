using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdamsLair.WinForms.ItemModels;
using Duality.Editor;
using Duality.Editor.Forms;
using Duality.Editor.Properties;
using Soulstone.Duality.Editor.Plugins.Atlas.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Soulstone.Duality.Editor.Plugins.Atlas
{
    public class Duality_EditorPlugin : EditorPlugin
	{
		private SceneView _view;
		private bool _isLoading = false;

		public override string Id
		{
			get { return "Soulstone.Duality.Editor.Plugins.Atlas"; }
		}

		protected override void InitPlugin(MainForm main)
		{
			base.InitPlugin(main);

			// Request menu
			MenuModelItem viewItem = main.MainMenu.RequestItem(GeneralRes.MenuName_View);
			viewItem.AddItem(new MenuModelItem
			{
				Name = "State",
				//Icon = SceneViewResCache.IconSceneView.ToBitmap(),
				ActionHandler = menuItemSceneView_Click
			});
		}

		private void menuItemSceneView_Click(object sender, EventArgs e)
		{
			RequestSceneView();
		}

		public SceneView RequestSceneView()
		{
			if (_view != null)
				_view.Dispose();

			_view = new SceneView();

			if (!_isLoading)
			{
				_view.Show(DualityEditorApp.MainForm.MainDockPanel);
				if (_view.Pane != null)
				{
					_view.Pane.Activate();
					_view.Focus();
				}
			}

			return _view;
		}

		protected override IDockContent DeserializeDockContent(Type dockContentType)
		{
			_isLoading = true;
			
			IDockContent result;
			
			if (dockContentType == typeof(SceneView))
				result = RequestSceneView();
			else
				result = base.DeserializeDockContent(dockContentType);
			
			_isLoading = false;
			return result;
		}
	}
}
