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
    public partial class InputElement : Form
    {
        public InputElement()
        {
            InitializeComponent();
        }
        public String ChosenString()
        {
            return this.comboBox1.SelectedItem.ToString();
        }
        public Element SelectedElement()
        {
            return (Element)Enum.Parse(typeof(Element), this.comboBox1.SelectedItem.ToString());
        }

		internal void SetElement(Element toElement)
		{
			comboBox1.SelectedText = toElement.ToString();
		}
	}
}
