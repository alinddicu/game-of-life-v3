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
            this.cycleButton = new System.Windows.Forms.ToolStripButton();
            this.resetButton = new System.Windows.Forms.ToolStripButton();
            this.optionsDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cycleButton,
            this.resetButton,
            this.optionsDownButton});
            this.topToolStrip.Location = new System.Drawing.Point(0, 0);
            this.topToolStrip.Name = "topToolStrip";
            this.topToolStrip.Size = new System.Drawing.Size(634, 25);
            this.topToolStrip.Stretch = true;
            this.topToolStrip.TabIndex = 0;
            this.topToolStrip.Text = "topToolStrip";
            // 
            // cycleButton
            // 
            this.cycleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cycleButton.Image = ((System.Drawing.Image)(resources.GetObject("cycleButton.Image")));
            this.cycleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cycleButton.Name = "cycleButton";
            this.cycleButton.Size = new System.Drawing.Size(32, 22);
            this.cycleButton.Text = "Run";
            this.cycleButton.Click += new System.EventHandler(this.cycleButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
            this.resetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(39, 22);
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // optionsDownButton
            // 
            this.optionsDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.optionsDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.optionsDownButton.Image = ((System.Drawing.Image)(resources.GetObject("optionsDownButton.Image")));
            this.optionsDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optionsDownButton.Name = "optionsDownButton";
            this.optionsDownButton.Size = new System.Drawing.Size(62, 22);
            this.optionsDownButton.Text = "Options";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.optionsToolStripMenuItem.Text = "GoL options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.golOptions_Click);
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
        private System.Windows.Forms.ToolStripButton cycleButton;
        private System.Windows.Forms.ToolStripButton resetButton;
        private System.Windows.Forms.ToolStripDropDownButton optionsDownButton;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

