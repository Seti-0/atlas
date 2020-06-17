using Duality.Editor.Controls;

namespace Soulstone.Duality.Editor.Plugins.Atlas.Forms
{
    partial class SceneView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.viewObjectType = new Aga.Controls.Tree.TreeViewAdv();
            this.iconTreeNode = new Aga.Controls.Tree.NodeControls.NodeStateIcon();
            this.txtNodeName = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.txtFilter = new CueTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewObjectType
            // 
            this.viewObjectType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.viewObjectType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.viewObjectType.ColumnHeaderHeight = 0;
            this.viewObjectType.DefaultToolTipProvider = null;
            this.viewObjectType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewObjectType.DragDropMarkColor = System.Drawing.Color.Black;
            this.viewObjectType.FullRowSelect = true;
            this.viewObjectType.FullRowSelectActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.viewObjectType.FullRowSelectInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.viewObjectType.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.viewObjectType.LoadOnDemand = true;
            this.viewObjectType.Location = new System.Drawing.Point(0, 0);
            this.viewObjectType.Margin = new System.Windows.Forms.Padding(0);
            this.viewObjectType.Model = null;
            this.viewObjectType.Name = "viewObjectType";
            this.viewObjectType.NodeFilter = null;
            this.viewObjectType.SelectedNode = null;
            this.viewObjectType.Size = new System.Drawing.Size(330, 369);
            this.viewObjectType.TabIndex = 0;
            this.viewObjectType.Click += new System.EventHandler(this.viewObjectType_Click);
            // 
            // iconTreeNode
            // 
            this.iconTreeNode.DataPropertyName = "Icon";
            this.iconTreeNode.LeftMargin = 1;
            this.iconTreeNode.ParentColumn = null;
            this.iconTreeNode.ScaleMode = Aga.Controls.Tree.ImageScaleMode.Clip;
            // 
            // txtNodeName
            // 
            this.txtNodeName.DataPropertyName = "Name";
            this.txtNodeName.IncrementalSearchEnabled = true;
            this.txtNodeName.LeftMargin = 3;
            this.txtNodeName.ParentColumn = null;
            // 
            // txtFilter
            // 
            this.txtFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.CueText = "";
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilter.Location = new System.Drawing.Point(43, 0);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(287, 22);
            this.txtFilter.TabIndex = 4;
            this.txtFilter.TextChanged += new System.EventHandler(this.TxtFilterInput_TextChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(43, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Filter:";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.txtFilter);
            this.panelBottom.Controls.Add(this.panel2);
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 369);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(330, 22);
            this.panelBottom.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Location = new System.Drawing.Point(117, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 9;
            // 
            // SceneView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(330, 391);
            this.Controls.Add(this.viewObjectType);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SceneView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "State View";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Aga.Controls.Tree.TreeViewAdv viewObjectType;
        private Aga.Controls.Tree.NodeControls.NodeStateIcon iconTreeNode;
        private Aga.Controls.Tree.NodeControls.NodeTextBox txtNodeName;
        private CueTextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel2;
    }
}