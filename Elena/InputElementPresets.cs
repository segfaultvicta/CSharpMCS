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
    public partial class InputElementPresets : Form
    {
        public InputElementPresets()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        public int ReturnSet()
        {
            if (radioButton1.Checked)
            {
                return 1;
            }
            if (radioButton2.Checked)
            {
                return 2;
            }
            if (radioButton3.Checked)
            {
                return 3;
            }
            if (radioButton4.Checked)
            {
                return 4;
            }
            return 0;
        }

        public Element ReturnPrimary()
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Fire":
                    return Element.Fire;

                case "Ice":
                    return Element.Ice;

                case "Water":
                    return Element.Water;

                case "Lightning":
                    return Element.Lightning;

                case "Holy":
                    return Element.Holy;

                case "Shadow":
                    return Element.Shadow;

                default:
                    return Element.Null;
            }
        }

        public Element ReturnOpposite()
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Fire":
                    return Element.Ice;

                case "Ice":
                    return Element.Fire;

                case "Water":
                    return Element.Lightning;

                case "Lightning":
                    return Element.Water;

                case "Holy":
                    return Element.Shadow;

                case "Shadow":
                    return Element.Holy;

                default:
                    return Element.Null;
            }
        }

        public Element ReturnTertiary1()
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Fire":
                    return Element.Water;

                case "Ice":
                    return Element.Lightning;

                case "Water":
                    return Element.Fire;

                case "Lightning":
                    return Element.Ice;

                case "Holy":
                    return Element.Null;

                case "Shadow":
                    return Element.Null;

                default:
                    return Element.Null;
            }
        }

        public Element ReturnTertiary2()
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Fire":
                    return Element.Lightning;

                case "Ice":
                    return Element.Water;

                case "Water":
                    return Element.Ice;

                case "Lightning":
                    return Element.Fire;

                case "Holy":
                    return Element.Null;

                case "Shadow":
                    return Element.Null;

                default:
                    return Element.Null;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Holy" || comboBox1.SelectedItem.ToString() == "Shadow")
            {
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
            else
            {
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
        }
    }
}
