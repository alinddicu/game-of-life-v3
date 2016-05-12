namespace game.of.life.v3.desktop
{
    partial class GoLForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoLForm));
            this._cellsPanel = new System.Windows.Forms.Panel();
            this.topToolStrip = new System.Windows.Forms.ToolStrip();
            this.previousCycleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.nextCycleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.goLOptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveGridButton = new System.Windows.Forms.ToolStripButton();
            this.topToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cellsPanel
            // 
            this._cellsPanel.Location = new System.Drawing.Point(0, 28);
            this._cellsPanel.Name = "_cellsPanel";
            this._cellsPanel.Size = new System.Drawing.Size(631, 638);
            this._cellsPanel.TabIndex = 0;
            // 
            // topToolStrip
            // 
            this.topToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previousCycleButton,
            this.toolStripSeparator2,
            this.nextCycleButton,
            this.toolStripSeparator1,
            this.resetButton,
            this.toolStripSeparator3,
            this.saveGridButton,
            this.toolStripSeparator4,
            this.optionsDownButton});
            this.topToolStrip.Location = new System.Drawing.Point(0, 0);
            this.topToolStrip.Name = "topToolStrip";
            this.topToolStrip.Size = new System.Drawing.Size(634, 25);
            this.topToolStrip.Stretch = true;
            this.topToolStrip.TabIndex = 0;
            this.topToolStrip.Text = "topToolStrip";
            // 
            // previousCycleButton
            // 
            this.previousCycleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.previousCycleButton.Image = ((System.Drawing.Image)(resources.GetObject("previousCycleButton.Image")));
            this.previousCycleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousCycleButton.Name = "previousCycleButton";
            this.previousCycleButton.Size = new System.Drawing.Size(86, 22);
            this.previousCycleButton.Text = "Previous cycle";
            this.previousCycleButton.Click += new System.EventHandler(this.PreviousCycleButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // nextCycleButton
            // 
            this.nextCycleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nextCycleButton.Image = ((System.Drawing.Image)(resources.GetObject("nextCycleButton.Image")));
            this.nextCycleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextCycleButton.Name = "nextCycleButton";
            this.nextCycleButton.Size = new System.Drawing.Size(65, 22);
            this.nextCycleButton.Text = "Next cycle";
            this.nextCycleButton.Click += new System.EventHandler(this.NextCycleButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // resetButton
            // 
            this.resetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
            this.resetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(39, 22);
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // optionsDownButton
            // 
            this.optionsDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.optionsDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goLOptionsMenuItem});
            this.optionsDownButton.Image = ((System.Drawing.Image)(resources.GetObject("optionsDownButton.Image")));
            this.optionsDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optionsDownButton.Name = "optionsDownButton";
            this.optionsDownButton.Size = new System.Drawing.Size(62, 22);
            this.optionsDownButton.Text = "Options";
            // 
            // goLOptionsMenuItem
            // 
            this.goLOptionsMenuItem.Name = "goLOptionsMenuItem";
            this.goLOptionsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.goLOptionsMenuItem.Text = "GoL options";
            this.goLOptionsMenuItem.Click += new System.EventHandler(this.golOptions_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // saveGridButton
            // 
            this.saveGridButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveGridButton.Image = ((System.Drawing.Image)(resources.GetObject("saveGridButton.Image")));
            this.saveGridButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveGridButton.Name = "saveGridButton";
            this.saveGridButton.Size = new System.Drawing.Size(35, 22);
            this.saveGridButton.Text = "Save";
            this.saveGridButton.Click += new System.EventHandler(this.saveGridButton_Click);
            // 
            // GoLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 662);
            this.Controls.Add(this.topToolStrip);
            this.Controls.Add(this._cellsPanel);
            this.Name = "GoLForm";
            this.Text = "GoL";
            this.Load += new System.EventHandler(this.GoLForm_Load);
            this.topToolStrip.ResumeLayout(false);
            this.topToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _cellsPanel;
        private System.Windows.Forms.ToolStrip topToolStrip;
        private System.Windows.Forms.ToolStripButton nextCycleButton;
        private System.Windows.Forms.ToolStripButton resetButton;
        private System.Windows.Forms.ToolStripDropDownButton optionsDownButton;
        private System.Windows.Forms.ToolStripMenuItem goLOptionsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton previousCycleButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton saveGridButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

