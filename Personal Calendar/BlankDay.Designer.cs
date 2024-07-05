
using System.Windows.Forms;

namespace Personal_Calendar
{
    partial class BlankDay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tempory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Tempory
            // 
            this.Tempory.AutoSize = true;
            this.Tempory.Location = new System.Drawing.Point(52, 45);
            this.Tempory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Tempory.Name = "Tempory";
            this.Tempory.Size = new System.Drawing.Size(0, 20);
            this.Tempory.TabIndex = 0;
            // 
            // BlankDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.Tempory);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BlankDay";
            this.Size = new System.Drawing.Size(200, 125);
            this.Load += new System.EventHandler(this.BlankDay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Tempory;

    }
}