using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elena
{
    public partial class AbilitiesForm : Form
    {
        public AbilitiesForm()
        {
            InitializeComponent();

        }

        private void treeView1_OnDoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Name != "")
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }
        public TreeNode SelectedNode()
        {
            return treeView1.SelectedNode;
        }
    }
}
