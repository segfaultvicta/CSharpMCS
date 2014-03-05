namespace Elena
{
    partial class InputAdditionalCost
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
            this.label1 = new System.Windows.Forms.Label();
            this.mpChoice = new System.Windows.Forms.Button();
            this.delayChoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "This ability incurs an additional cost.  Pick that cost:";
            // 
            // mpChoice
            // 
            this.mpChoice.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mpChoice.Location = new System.Drawing.Point(193, 38);
            this.mpChoice.Name = "mpChoice";
            this.mpChoice.Size = new System.Drawing.Size(95, 24);
            this.mpChoice.TabIndex = 2;
            this.mpChoice.Text = "button2";
            this.mpChoice.UseVisualStyleBackColor = false;
            this.mpChoice.Click += new System.EventHandler(this.mpChoice_Click);
            // 
            // delayChoice
            // 
            this.delayChoice.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.delayChoice.Location = new System.Drawing.Point(41, 38);
            this.delayChoice.Name = "delayChoice";
            this.delayChoice.Size = new System.Drawing.Size(95, 24);
            this.delayChoice.TabIndex = 1;
            this.delayChoice.Text = "button1";
            this.delayChoice.UseVisualStyleBackColor = false;
            this.delayChoice.Click += new System.EventHandler(this.delayChoice_Click);
            // 
            // InputAdditionalCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Elena.Properties.Settings.Default.BackColour;
            this.ClientSize = new System.Drawing.Size(323, 81);
            this.Controls.Add(this.delayChoice);
            this.Controls.Add(this.mpChoice);
            this.Controls.Add(this.label1);
            this.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
            this.Name = "InputAdditionalCost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button delayChoice;
        private System.Windows.Forms.Button mpChoice;
    }
}