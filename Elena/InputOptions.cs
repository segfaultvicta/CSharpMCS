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
    public partial class InputOptions : Form
    {
		private Dictionary<Panel, string> panels = new Dictionary<Panel, string>();

        public InputOptions()
        {
            InitializeComponent();
            panels.Add(absorbColorPanel, "AbsorbColour");
            panels.Add(immuneColorPanel, "ImmuneColour");
            panels.Add(resistColorPanel, "ResistColour");
            panels.Add(normalColorPanel, "NormalColour");
            panels.Add(weaknessColorPanel, "WeakColour");
            panels.Add(textColorPanel, "TextColour");
            panels.Add(backColorPanel, "BackColour");
            panels.Add(fieldTextColorPanel, "FieldTextColour");
            panels.Add(fieldColorPanel, "FieldBackColour");
            panels.Add(errorColorPanel, "ErrorTextColour");
            textColorPanel.BackColor = Properties.Settings.Default.TextColour;
            backColorPanel.BackColor = Properties.Settings.Default.BackColour;
            fieldColorPanel.BackColor = Properties.Settings.Default.FieldBackColour;
            fieldTextColorPanel.BackColor = Properties.Settings.Default.FieldTextColour;
            weaknessColorPanel.BackColor = Properties.Settings.Default.WeakColour;
            normalColorPanel.BackColor = Properties.Settings.Default.NormalColour;
            resistColorPanel.BackColor = Properties.Settings.Default.ResistColour;
            immuneColorPanel.BackColor = Properties.Settings.Default.ImmuneColour;
            absorbColorPanel.BackColor = Properties.Settings.Default.AbsorbColour;
            errorColorPanel.BackColor = Properties.Settings.Default.ErrorTextColour;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Random r = new Random();
            Color borderColor = Color.FromArgb(r.Next(0,255), r.Next(0,255),r.Next(0,255));
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(borderColor), 2), e.ClipRectangle);
        }

        private void colorPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel origin = (Panel)sender;
            origin.BackColor = colorDialog(origin.BackColor);
        }

        private Color colorDialog(Color def)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                return colorDialog1.Color;
            }
            else
            {
                return def;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<Panel,string> panel in panels) 
            {
                Properties.Settings.Default[panel.Value] = panel.Key.BackColor;
            }
            Properties.Settings.Default.Save();
        }

        private void defaultsButton_Click(object sender, EventArgs e)
        {
            textColorPanel.BackColor = Color.Lime;
            backColorPanel.BackColor = Color.Black;
            fieldColorPanel.BackColor = Color.FromArgb(38, 38, 38);
            fieldTextColorPanel.BackColor = Color.DarkSeaGreen;
            weaknessColorPanel.BackColor = Color.Red;
            normalColorPanel.BackColor = Color.Gray;
            resistColorPanel.BackColor = Color.Green;
            immuneColorPanel.BackColor = Color.White;
            absorbColorPanel.BackColor = Color.SkyBlue;
            errorColorPanel.BackColor = Color.Firebrick;
        }
    }
}
