namespace Elena
{
    partial class AbilitiesForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Basic Attack (Default free, 1 slot per extra)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Special Ability (1)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Enhancement (2/4)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("w/o Positive Status (2)");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("w/ Positive Status (4)");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Devour... [M.Boss or Boss]", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbilitiesForm));
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("One Monster (2)");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("2-4 Monsters (4)");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Alarm...", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Call For Help! (4)");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Form Change (2) [M.Boss or Boss]");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Reduce: 1 (1)");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Reduce: 3 (2)");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Remove All (4)");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Status Shake...", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Store Element (2)");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Action Abilities", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode6,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Type Swap (1)");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Group Attack (2)");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Row Cutter (1)");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Element Shift (1)");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Faster (1)");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Counter (1, or 3 if ability had CT)");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Power Strike (1, per rank if M.Boss or Boss)");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Critical [Tier 2+] (1)");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Piercing [Tier 4+] (2)");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Added Status (V)");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Inflicts Status (V)");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Ranged (2)");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("High CoS (1, per rank if M.Boss or Boss)");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Longer Status (1, per rank if M.Boss or Boss)");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Countdown (1 per rank)");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Clumsy Strength (1)");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Tectonic [Tier 2+] (1 or 2)");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Drain Health [Tier 4+] (3 or 7)");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Linked to Status (+1 or 0)");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Action Modifiers", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Other (V)");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okgoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = global::Elena.Properties.Settings.Default.FieldBackColour;
            this.treeView1.ForeColor = global::Elena.Properties.Settings.Default.FieldTextColour;
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "BasicAttack";
            treeNode1.Text = "Basic Attack (Default free, 1 slot per extra)";
            treeNode1.ToolTipText = "Action, Weapon Technique, T:Single F20 CoS 80";
            treeNode2.Name = "SpecialAbility";
            treeNode2.Text = "Special Ability (1)";
            treeNode2.ToolTipText = "Technique or Magic Spell, T:Single, CoS 95";
            treeNode3.Name = "Enhancement";
            treeNode3.Text = "Enhancement (2/4)";
            treeNode4.Name = "DevourBasic";
            treeNode4.Text = "w/o Positive Status (2)";
            treeNode5.Name = "DevourPlus";
            treeNode5.Text = "w/ Positive Status (4)";
            treeNode6.Name = "";
            treeNode6.Text = "Devour... [M.Boss or Boss]";
            treeNode6.ToolTipText = resources.GetString("treeNode6.ToolTipText");
            treeNode7.Name = "AlarmSingle";
            treeNode7.Text = "One Monster (2)";
            treeNode8.Name = "AlarmMulti";
            treeNode8.Text = "2-4 Monsters (4)";
            treeNode9.Name = "";
            treeNode9.Text = "Alarm...";
            treeNode9.ToolTipText = "When \"Alarm\" is taken, choose a single monster of equal or lower level, and of eq" +
                "ual or lower difficulty, and of normal rank. When \"Alarm\" is used, add that mons" +
                "ter to the battle with 50 Delay.";
            treeNode10.Name = "CallForHelp";
            treeNode10.Text = "Call For Help! (4)";
            treeNode10.ToolTipText = resources.GetString("treeNode10.ToolTipText");
            treeNode11.Name = "FormChange";
            treeNode11.Text = "Form Change (2) [M.Boss or Boss]";
            treeNode11.ToolTipText = resources.GetString("treeNode11.ToolTipText");
            treeNode12.Name = "StatusShake2";
            treeNode12.Text = "Reduce: 1 (1)";
            treeNode13.Name = "StatusShake4";
            treeNode13.Text = "Reduce: 3 (2)";
            treeNode14.Name = "StatusShakeAll";
            treeNode14.Text = "Remove All (4)";
            treeNode15.Name = "";
            treeNode15.Text = "Status Shake...";
            treeNode15.ToolTipText = resources.GetString("treeNode15.ToolTipText");
            treeNode16.Name = "StoreElement";
            treeNode16.Text = "Store Element (2)";
            treeNode17.Name = "";
            treeNode17.Text = "Action Abilities";
            treeNode18.Name = "TypeSwap";
            treeNode18.Text = "Type Swap (1)";
            treeNode18.ToolTipText = resources.GetString("treeNode18.ToolTipText");
            treeNode19.Name = "GroupAttack";
            treeNode19.Text = "Group Attack (2)";
            treeNode19.ToolTipText = "Ability is Target: Group.";
            treeNode20.Name = "RowCutter";
            treeNode20.Text = "Row Cutter (1)";
            treeNode20.ToolTipText = "Ability is Target: Group (Row).";
            treeNode21.Name = "ElementShift";
            treeNode21.Text = "Element Shift (1)";
            treeNode21.ToolTipText = "Select an element. All damage inflicted by this action is now of that element.";
            treeNode22.Name = "Faster";
            treeNode22.Tag = "";
            treeNode22.Text = "Faster (1)";
            treeNode22.ToolTipText = "Ability is faster, acting with -5D F-5 - it bears a lower delay and floor.";
            treeNode23.Name = "Counter";
            treeNode23.Text = "Counter (1, or 3 if ability had CT)";
            treeNode23.ToolTipText = resources.GetString("treeNode23.ToolTipText");
            treeNode24.Name = "PowerStrike";
            treeNode24.Text = "Power Strike (1, per rank if M.Boss or Boss)";
            treeNode24.ToolTipText = resources.GetString("treeNode24.ToolTipText");
            treeNode25.Name = "Critical";
            treeNode25.Text = "Critical [Tier 2+] (1)";
            treeNode25.ToolTipText = resources.GetString("treeNode25.ToolTipText");
            treeNode26.Name = "Piercing";
            treeNode26.Text = "Piercing [Tier 4+] (2)";
            treeNode26.ToolTipText = "This action is Piercing and ignores Armor or M.Armor. This modifier is sealed by " +
                "\"Seal Piercing\".";
            treeNode27.Name = "AddedStatus";
            treeNode27.Text = "Added Status (V)";
            treeNode27.ToolTipText = resources.GetString("treeNode27.ToolTipText");
            treeNode28.Name = "InflictsStatus";
            treeNode28.Text = "Inflicts Status (V)";
            treeNode28.ToolTipText = resources.GetString("treeNode28.ToolTipText");
            treeNode29.Name = "Ranged";
            treeNode29.Text = "Ranged (2)";
            treeNode29.ToolTipText = "This particular ability ignores the effects of rows.";
            treeNode30.Name = "HighCoS";
            treeNode30.Text = "High CoS (1, per rank if M.Boss or Boss)";
            treeNode30.ToolTipText = "The ability has +5 CoS. M.Boss or higher ranked enemies may take multiple ranks o" +
                "f this, applying +5 CoS per.";
            treeNode31.Name = "LongerStatus";
            treeNode31.Text = "Longer Status (1, per rank if M.Boss or Boss)";
            treeNode31.ToolTipText = "Increases the timer of any statuses that the ability inflicts or bestows by +(1)." +
                "";
            treeNode32.Name = "Countdown";
            treeNode32.Text = "Countdown (1 per rank)";
            treeNode32.ToolTipText = "The action has an additional CT of 25 + 5 per rank above 1, and a x1.5 power mult" +
                " (+0.5 for every rank above one)";
            treeNode33.Name = "ClumsyStrength";
            treeNode33.Text = "Clumsy Strength (1)";
            treeNode33.ToolTipText = "The ability has -25 CoS but has +(6xTier) Power.";
            treeNode34.Name = "Tectonic";
            treeNode34.Text = "Tectonic [Tier 2+] (1 or 2)";
            treeNode35.Name = "DrainHealth";
            treeNode35.Text = "Drain Health [Tier 4+] (3 or 7)";
            treeNode35.ToolTipText = "Damage inflicted by this action is drained to the monster that performed it, repl" +
                "enishing its health.";
            treeNode36.Name = "StatusLinked";
            treeNode36.Text = "Linked to Status (+1 or 0)";
            treeNode36.ToolTipText = resources.GetString("treeNode36.ToolTipText");
            treeNode37.Name = "";
            treeNode37.Text = "Action Modifiers";
            treeNode38.Name = "ActionOther";
            treeNode38.Text = "Other (V)";
            treeNode38.ToolTipText = "Manually enter in an ability accessible to PCs, or select one from the preload op" +
                "tions.";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode37,
            treeNode38});
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(268, 214);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_OnDoubleClick);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(12, 232);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(128, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // okgoButton
            // 
            this.okgoButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okgoButton.Location = new System.Drawing.Point(147, 232);
            this.okgoButton.Name = "okgoButton";
            this.okgoButton.Size = new System.Drawing.Size(133, 23);
            this.okgoButton.TabIndex = 2;
            this.okgoButton.Text = "OKGO";
            this.okgoButton.UseVisualStyleBackColor = false;
            // 
            // AbilitiesForm
            // 
            this.AcceptButton = this.okgoButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Elena.Properties.Settings.Default.BackColour;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.ControlBox = false;
            this.Controls.Add(this.okgoButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.treeView1);
            this.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
            this.Name = "AbilitiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Monster Property";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okgoButton;
    }
}