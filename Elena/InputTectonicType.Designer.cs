namespace Elena
{
    partial class InputTectonicType
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
            this.powerChoice = new System.Windows.Forms.Button();
            this.delayChoice = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Which Tectonic modifier do you wish to use?";
            // 
            // powerChoice
            // 
            this.powerChoice.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.powerChoice.Location = new System.Drawing.Point(12, 48);
            this.powerChoice.Name = "powerChoice";
            this.powerChoice.Size = new System.Drawing.Size(95, 24);
            this.powerChoice.TabIndex = 1;
            this.powerChoice.Text = "3*Tier Power+";
            this.powerChoice.UseVisualStyleBackColor = false;
            this.powerChoice.Click += new System.EventHandler(this.powerChoice_Click);
            // 
            // delayChoice
            // 
            this.delayChoice.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.delayChoice.Location = new System.Drawing.Point(136, 48);
            this.delayChoice.Name = "delayChoice";
            this.delayChoice.Size = new System.Drawing.Size(95, 24);
            this.delayChoice.TabIndex = 2;
            this.delayChoice.Text = "Delay Target";
            this.delayChoice.UseVisualStyleBackColor = false;
            this.delayChoice.Click += new System.EventHandler(this.delayChoice_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(197, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Spend an extra slot to strip element?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // InputTectonicType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Elena.Properties.Settings.Default.BackColour;
            this.ClientSize = new System.Drawing.Size(243, 84);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.delayChoice);
            this.Controls.Add(this.powerChoice);
            this.Controls.Add(this.label1);
            this.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
            this.Name = "InputTectonicType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tectonic Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button powerChoice;
        private System.Windows.Forms.Button delayChoice;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}