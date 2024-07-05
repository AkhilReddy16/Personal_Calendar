
namespace Personal_Calendar
{
    partial class NonBlankDay
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
            this.lbdays = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbdays
            // 
            this.lbdays.AutoSize = true;
            this.lbdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdays.Location = new System.Drawing.Point(167, 15);
            this.lbdays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbdays.Name = "lbdays";
            this.lbdays.Size = new System.Drawing.Size(29, 20);
            this.lbdays.TabIndex = 0;
            this.lbdays.Text = "00";
            this.lbdays.Click += new System.EventHandler(this.label1_Click);
            // 
            // NonBlankDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.lbdays);
            this.ForeColor = System.Drawing.Color.Firebrick;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NonBlankDay";
            this.Size = new System.Drawing.Size(200, 125);
            this.Load += new System.EventHandler(this.NonBlankDay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbdays;
    }
}