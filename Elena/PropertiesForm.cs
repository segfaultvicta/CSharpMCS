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
    public partial class PropertiesForm : Form
    {
        private Form1 parent;

        public PropertiesForm(Form1 p)
        {
            parent = p;
            InitializeComponent();
        }

        private string Recurse(TreeNode n)
        {
            String result = "";
            result += n.Name + ":" + n.Text + "\r\n";
            foreach (TreeNode tn in n.Nodes)
            {
                result += Recurse(tn);
            }
            return result;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okgoButton_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Name != "")
            {
                parent.RegisterNewProperty(treeView1.SelectedNode);
            }
            this.Close();
        }

        private void treeView1_OnDoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Name != "")
            {
                parent.RegisterNewProperty(treeView1.SelectedNode);
                this.Close();
            }
        }
    }
}
