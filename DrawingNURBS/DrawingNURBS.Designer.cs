using System.Windows.Forms;

namespace DrawingNURBS
{
    partial class DrawingNURBS
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("PlaneXY");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("PlaneYZ");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("PlaneZX");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Patch");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Geometry", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingNURBS));
            this.MainBody = new System.Windows.Forms.SplitContainer();
            this.ToolBox = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.PolyLine = new System.Windows.Forms.Button();
            this.LineBtn = new System.Windows.Forms.Button();
            this.PointBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawingBodyMain = new System.Windows.Forms.SplitContainer();
            this.TreeAndDetail = new System.Windows.Forms.SplitContainer();
            this.TreeLine = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Coordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.MainBody)).BeginInit();
            this.MainBody.Panel1.SuspendLayout();
            this.MainBody.Panel2.SuspendLayout();
            this.MainBody.SuspendLayout();
            this.ToolBox.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingBodyMain)).BeginInit();
            this.DrawingBodyMain.Panel1.SuspendLayout();
            this.DrawingBodyMain.Panel2.SuspendLayout();
            this.DrawingBodyMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeAndDetail)).BeginInit();
            this.TreeAndDetail.Panel1.SuspendLayout();
            this.TreeAndDetail.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainBody
            // 
            this.MainBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainBody.Location = new System.Drawing.Point(0, 0);
            this.MainBody.Margin = new System.Windows.Forms.Padding(0);
            this.MainBody.Name = "MainBody";
            this.MainBody.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainBody.Panel1
            // 
            this.MainBody.Panel1.AccessibleName = "ToolAndMenu";
            this.MainBody.Panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.MainBody.Panel1.Controls.Add(this.ToolBox);
            this.MainBody.Panel1.Controls.Add(this.menuStrip1);
            // 
            // MainBody.Panel2
            // 
            this.MainBody.Panel2.AccessibleName = "DrawingBody";
            this.MainBody.Panel2.Controls.Add(this.DrawingBodyMain);
            this.MainBody.Size = new System.Drawing.Size(883, 574);
            this.MainBody.SplitterDistance = 165;
            this.MainBody.SplitterWidth = 1;
            this.MainBody.TabIndex = 1;
            // 
            // ToolBox
            // 
            this.ToolBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolBox.Controls.Add(this.tabPage1);
            this.ToolBox.Controls.Add(this.tabPage2);
            this.ToolBox.Location = new System.Drawing.Point(3, 28);
            this.ToolBox.Margin = new System.Windows.Forms.Padding(0);
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.SelectedIndex = 0;
            this.ToolBox.Size = new System.Drawing.Size(878, 135);
            this.ToolBox.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ClearBtn);
            this.tabPage1.Controls.Add(this.PolyLine);
            this.tabPage1.Controls.Add(this.LineBtn);
            this.tabPage1.Controls.Add(this.PointBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(870, 109);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ClearBtn
            // 
            this.ClearBtn.AccessibleName = "ClearBtn";
            this.ClearBtn.Location = new System.Drawing.Point(250, 6);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(77, 94);
            this.ClearBtn.TabIndex = 3;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // PolyLine
            // 
            this.PolyLine.AccessibleName = "PolyLine";
            this.PolyLine.Location = new System.Drawing.Point(167, 6);
            this.PolyLine.Name = "PolyLine";
            this.PolyLine.Size = new System.Drawing.Size(77, 94);
            this.PolyLine.TabIndex = 2;
            this.PolyLine.Text = "Poly Line";
            this.PolyLine.UseVisualStyleBackColor = true;
            this.PolyLine.Click += new System.EventHandler(this.PolyLineBtn_Click);
            // 
            // LineBtn
            // 
            this.LineBtn.AccessibleName = "LineBtn";
            this.LineBtn.Location = new System.Drawing.Point(87, 6);
            this.LineBtn.Name = "LineBtn";
            this.LineBtn.Size = new System.Drawing.Size(75, 94);
            this.LineBtn.TabIndex = 1;
            this.LineBtn.Text = "Line";
            this.LineBtn.UseVisualStyleBackColor = true;
            this.LineBtn.Click += new System.EventHandler(this.LineBtn_Click);
            // 
            // PointBtn
            // 
            this.PointBtn.AccessibleName = "PointBtn";
            this.PointBtn.Location = new System.Drawing.Point(6, 6);
            this.PointBtn.Name = "PointBtn";
            this.PointBtn.Size = new System.Drawing.Size(75, 94);
            this.PointBtn.TabIndex = 0;
            this.PointBtn.Text = "Point";
            this.PointBtn.UseVisualStyleBackColor = true;
            this.PointBtn.Click += new System.EventHandler(this.PointBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(870, 109);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(141, 26);
            this.toolStripMenuItem1.Text = "Save";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.saveToolStripMenuItem.Text = "Save as";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // DrawingBodyMain
            // 
            this.DrawingBodyMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingBodyMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawingBodyMain.Location = new System.Drawing.Point(0, 0);
            this.DrawingBodyMain.Name = "DrawingBodyMain";
            // 
            // DrawingBodyMain.Panel1
            // 
            this.DrawingBodyMain.Panel1.Controls.Add(this.TreeAndDetail);
            // 
            // DrawingBodyMain.Panel2
            // 
            this.DrawingBodyMain.Panel2.AccessibleName = "DrawingBody";
            this.DrawingBodyMain.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.DrawingBodyMain.Panel2.Controls.Add(this.statusStrip1);
            this.DrawingBodyMain.Panel2.Controls.Add(this.panel1);
            this.DrawingBodyMain.Size = new System.Drawing.Size(881, 457);
            this.DrawingBodyMain.SplitterDistance = 249;
            this.DrawingBodyMain.SplitterWidth = 1;
            this.DrawingBodyMain.TabIndex = 0;
            // 
            // TreeAndDetail
            // 
            this.TreeAndDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TreeAndDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeAndDetail.Location = new System.Drawing.Point(0, 0);
            this.TreeAndDetail.Name = "TreeAndDetail";
            this.TreeAndDetail.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // TreeAndDetail.Panel1
            // 
            this.TreeAndDetail.Panel1.AccessibleName = "TreeBox";
            this.TreeAndDetail.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.TreeAndDetail.Panel1.Controls.Add(this.TreeLine);
            // 
            // TreeAndDetail.Panel2
            // 
            this.TreeAndDetail.Panel2.AccessibleName = "DetailBox";
            this.TreeAndDetail.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.TreeAndDetail.Size = new System.Drawing.Size(249, 457);
            this.TreeAndDetail.SplitterDistance = 217;
            this.TreeAndDetail.SplitterWidth = 1;
            this.TreeAndDetail.TabIndex = 0;
            // 
            // TreeLine
            // 
            this.TreeLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TreeLine.Location = new System.Drawing.Point(-2, 0);
            this.TreeLine.Margin = new System.Windows.Forms.Padding(0);
            this.TreeLine.Name = "TreeLine";
            treeNode1.Name = "PlaneXY";
            treeNode1.Text = "PlaneXY";
            treeNode2.Name = "PlaneYZ";
            treeNode2.Text = "PlaneYZ";
            treeNode3.Name = "PlaneZX";
            treeNode3.Text = "PlaneZX";
            treeNode4.Name = "Patch";
            treeNode4.Text = "Patch";
            treeNode5.Name = "Geometry";
            treeNode5.Text = "Geometry";
            this.TreeLine.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.TreeLine.Size = new System.Drawing.Size(252, 215);
            this.TreeLine.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Coordinate});
            this.statusStrip1.Location = new System.Drawing.Point(538, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(100, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Coordinate
            // 
            this.Coordinate.AccessibleName = "Coordinate";
            this.Coordinate.Name = "Coordinate";
            this.Coordinate.Size = new System.Drawing.Size(83, 20);
            this.Coordinate.Text = "Coordinate";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 379);
            this.panel1.TabIndex = 2;
            // 
            // DrawingNURBS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(883, 573);
            this.Controls.Add(this.MainBody);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DrawingNURBS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DrawingNURBS";
            this.Load += new System.EventHandler(this.drawingNURBS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CancelTool);
            this.MainBody.Panel1.ResumeLayout(false);
            this.MainBody.Panel1.PerformLayout();
            this.MainBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainBody)).EndInit();
            this.MainBody.ResumeLayout(false);
            this.ToolBox.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.DrawingBodyMain.Panel1.ResumeLayout(false);
            this.DrawingBodyMain.Panel2.ResumeLayout(false);
            this.DrawingBodyMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingBodyMain)).EndInit();
            this.DrawingBodyMain.ResumeLayout(false);
            this.TreeAndDetail.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeAndDetail)).EndInit();
            this.TreeAndDetail.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer MainBody;
        private SplitContainer DrawingBodyMain;
        private SplitContainer TreeAndDetail;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel Coordinate;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private TabControl ToolBox;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TreeView TreeLine;
        private Panel panel1;
        private Button PolyLine;
        private Button LineBtn;
        private Button PointBtn;
        private Button ClearBtn;
    }
}

