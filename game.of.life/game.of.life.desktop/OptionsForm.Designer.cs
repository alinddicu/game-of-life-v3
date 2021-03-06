﻿namespace game.of.life.desktop
{
    partial class OptionsForm
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
            this.isShowCellsCoordinatesCheckBox = new System.Windows.Forms.CheckBox();
            this.numberOfCellsPerRowLabel = new System.Windows.Forms.Label();
            this.numberOfCellsPerRowDropDown = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // isShowCellsCoordinatesCheckBox
            // 
            this.isShowCellsCoordinatesCheckBox.AutoSize = true;
            this.isShowCellsCoordinatesCheckBox.Location = new System.Drawing.Point(13, 13);
            this.isShowCellsCoordinatesCheckBox.Name = "isShowCellsCoordinatesCheckBox";
            this.isShowCellsCoordinatesCheckBox.Size = new System.Drawing.Size(130, 17);
            this.isShowCellsCoordinatesCheckBox.TabIndex = 0;
            this.isShowCellsCoordinatesCheckBox.Text = "Show cell coordinates";
            this.isShowCellsCoordinatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // numberOfCellsPerRowLabel
            // 
            this.numberOfCellsPerRowLabel.AutoSize = true;
            this.numberOfCellsPerRowLabel.Location = new System.Drawing.Point(13, 37);
            this.numberOfCellsPerRowLabel.Name = "numberOfCellsPerRowLabel";
            this.numberOfCellsPerRowLabel.Size = new System.Drawing.Size(118, 13);
            this.numberOfCellsPerRowLabel.TabIndex = 1;
            this.numberOfCellsPerRowLabel.Text = "Number of cells per row";
            // 
            // numberOfCellsPerRowDropDown
            // 
            this.numberOfCellsPerRowDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberOfCellsPerRowDropDown.DropDownWidth = 40;
            this.numberOfCellsPerRowDropDown.FormattingEnabled = true;
            this.numberOfCellsPerRowDropDown.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "30",
            "40",
            "50"});
            this.numberOfCellsPerRowDropDown.Location = new System.Drawing.Point(137, 34);
            this.numberOfCellsPerRowDropDown.Name = "numberOfCellsPerRowDropDown";
            this.numberOfCellsPerRowDropDown.Size = new System.Drawing.Size(50, 21);
            this.numberOfCellsPerRowDropDown.TabIndex = 2;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(197, 64);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 99);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.numberOfCellsPerRowDropDown);
            this.Controls.Add(this.numberOfCellsPerRowLabel);
            this.Controls.Add(this.isShowCellsCoordinatesCheckBox);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OptionsForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isShowCellsCoordinatesCheckBox;
        private System.Windows.Forms.Label numberOfCellsPerRowLabel;
        private System.Windows.Forms.ComboBox numberOfCellsPerRowDropDown;
        private System.Windows.Forms.Button okButton;
    }
}