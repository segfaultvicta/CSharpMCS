namespace Elena
{
    partial class InputInflictsStatus
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
            this.addStatusButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mpCostText = new System.Windows.Forms.Label();
            this.mpButton = new System.Windows.Forms.RadioButton();
            this.delayButton = new System.Windows.Forms.RadioButton();
            this.mpCostLabel = new System.Windows.Forms.Label();
            this.delayText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.slotCostText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gravityCheckBox = new System.Windows.Forms.CheckBox();
            this.moreDelayText = new System.Windows.Forms.Label();
            this.moreDelaySlider = new System.Windows.Forms.NumericUpDown();
            this.gravityText = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusList = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moreDelaySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // addStatusButton
            // 
            this.addStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStatusButton.Location = new System.Drawing.Point(12, 10);
            this.addStatusButton.Name = "addStatusButton";
            this.addStatusButton.Size = new System.Drawing.Size(191, 23);
            this.addStatusButton.TabIndex = 0;
            this.addStatusButton.Text = "Add A Status";
            this.addStatusButton.UseVisualStyleBackColor = false;
            this.addStatusButton.Click += new System.EventHandler(this.baseStatusButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mpCostText);
            this.groupBox1.Controls.Add(this.mpButton);
            this.groupBox1.Controls.Add(this.delayButton);
            this.groupBox1.Controls.Add(this.mpCostLabel);
            this.groupBox1.Controls.Add(this.delayText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.slotCostText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
            this.groupBox1.Location = new System.Drawing.Point(209, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Costs";
            // 
            // mpCostText
            // 
            this.mpCostText.AutoSize = true;
            this.mpCostText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mpCostText.Location = new System.Drawing.Point(75, 81);
            this.mpCostText.Name = "mpCostText";
            this.mpCostText.Size = new System.Drawing.Size(13, 13);
            this.mpCostText.TabIndex = 2;
            this.mpCostText.Text = "0";
            // 
            // mpButton
            // 
            this.mpButton.AutoSize = true;
            this.mpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mpButton.Location = new System.Drawing.Point(6, 81);
            this.mpButton.Name = "mpButton";
            this.mpButton.Size = new System.Drawing.Size(14, 13);
            this.mpButton.TabIndex = 2;
            this.mpButton.TabStop = true;
            this.mpButton.UseVisualStyleBackColor = true;
            // 
            // delayButton
            // 
            this.delayButton.AutoSize = true;
            this.delayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delayButton.Location = new System.Drawing.Point(6, 58);
            this.delayButton.Name = "delayButton";
            this.delayButton.Size = new System.Drawing.Size(14, 13);
            this.delayButton.TabIndex = 5;
            this.delayButton.TabStop = true;
            this.delayButton.UseVisualStyleBackColor = true;
            // 
            // mpCostLabel
            // 
            this.mpCostLabel.AutoSize = true;
            this.mpCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mpCostLabel.Location = new System.Drawing.Point(23, 81);
            this.mpCostLabel.Name = "mpCostLabel";
            this.mpCostLabel.Size = new System.Drawing.Size(55, 13);
            this.mpCostLabel.TabIndex = 4;
            this.mpCostLabel.Text = "+MP/Tier:";
            // 
            // delayText
            // 
            this.delayText.AutoSize = true;
            this.delayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delayText.Location = new System.Drawing.Point(75, 58);
            this.delayText.Name = "delayText";
            this.delayText.Size = new System.Drawing.Size(13, 13);
            this.delayText.TabIndex = 3;
            this.delayText.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "+Delay:";
            // 
            // slotCostText
            // 
            this.slotCostText.AutoSize = true;
            this.slotCostText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slotCostText.Location = new System.Drawing.Point(75, 32);
            this.slotCostText.Name = "slotCostText";
            this.slotCostText.Size = new System.Drawing.Size(13, 13);
            this.slotCostText.TabIndex = 1;
            this.slotCostText.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Slot Cost:";
            // 
            // gravityCheckBox
            // 
            this.gravityCheckBox.AutoSize = true;
            this.gravityCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gravityCheckBox.Location = new System.Drawing.Point(108, 193);
            this.gravityCheckBox.Name = "gravityCheckBox";
            this.gravityCheckBox.Size = new System.Drawing.Size(15, 14);
            this.gravityCheckBox.TabIndex = 9;
            this.gravityCheckBox.UseVisualStyleBackColor = true;
            this.gravityCheckBox.CheckedChanged += new System.EventHandler(this.gravityCheckBox_CheckedChanged);
            // 
            // moreDelayText
            // 
            this.moreDelayText.AutoSize = true;
            this.moreDelayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moreDelayText.Location = new System.Drawing.Point(129, 191);
            this.moreDelayText.Name = "moreDelayText";
            this.moreDelayText.Size = new System.Drawing.Size(40, 13);
            this.moreDelayText.TabIndex = 7;
            this.moreDelayText.Text = "+Delay";
            // 
            // moreDelaySlider
            // 
            this.moreDelaySlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moreDelaySlider.Location = new System.Drawing.Point(175, 191);
            this.moreDelaySlider.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.moreDelaySlider.Name = "moreDelaySlider";
            this.moreDelaySlider.Size = new System.Drawing.Size(28, 20);
            this.moreDelaySlider.TabIndex = 6;
            this.moreDelaySlider.ValueChanged += new System.EventHandler(this.moreDelaySlider_ValueChanged);
            // 
            // gravityText
            // 
            this.gravityText.AutoSize = true;
            this.gravityText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gravityText.Location = new System.Drawing.Point(39, 193);
            this.gravityText.Name = "gravityText";
            this.gravityText.Size = new System.Drawing.Size(63, 13);
            this.gravityText.TabIndex = 4;
            this.gravityText.Text = "Gravity 50%";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(209, 159);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(209, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // statusList
            // 
            this.statusList.FormattingEnabled = true;
            this.statusList.Location = new System.Drawing.Point(12, 39);
            this.statusList.Name = "statusList";
            this.statusList.Size = new System.Drawing.Size(191, 121);
            this.statusList.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Delete A Status";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // InputInflictsStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Elena.Properties.Settings.Default.BackColour;
            this.ClientSize = new System.Drawing.Size(315, 216);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gravityCheckBox);
            this.Controls.Add(this.moreDelaySlider);
            this.Controls.Add(this.moreDelayText);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addStatusButton);
            this.Controls.Add(this.gravityText);
            this.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
            this.Name = "InputInflictsStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Build Status Rider...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moreDelaySlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addStatusButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label mpCostText;
        private System.Windows.Forms.RadioButton mpButton;
        private System.Windows.Forms.RadioButton delayButton;
        private System.Windows.Forms.Label mpCostLabel;
        private System.Windows.Forms.Label delayText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label slotCostText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox gravityCheckBox;
        private System.Windows.Forms.Label moreDelayText;
        private System.Windows.Forms.NumericUpDown moreDelaySlider;
        private System.Windows.Forms.Label gravityText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox statusList;
        private System.Windows.Forms.Button button2;
    }
}