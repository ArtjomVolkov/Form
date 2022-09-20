using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class MinuOmaVorm : Form
    {
        TreeView puu;
        Button nupp;
        Label silt;
        public MinuOmaVorm()
        {
            Height = 600; //высота
            Width = 900; //ширина
            Text = "Minu oma vorm koos elementidega"; //название формы
            BackColor = Color.Gray;
            puu = new TreeView();
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            TreeNode oksad = new TreeNode("Elemendid");
            oksad.Nodes.Add(new TreeNode("Nupp-Button"));
            oksad.Nodes.Add(new TreeNode("Silt-Label"));
            oksad.Nodes.Add(new TreeNode("Dialog aken-MessageBox"));
            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);
        }

        private void Puu_AfterSelect(object sender,TreeViewEventArgs e)
        {
            if(e.Node.Text== "Nupp-Button")
            {
                nupp = new Button();
                nupp.Text = "Valjuta siia";
                nupp.Height = 30;
                nupp.Width = 100;
                nupp.Location = new Point(340, 100);
                nupp.Click += Nupp_Click;
                this.Controls.Add(nupp);
                nupp.BackColor = Color.Red;
            }
            else if (e.Node.Text == "Silt-Label")
            {
                silt = new Label
                {
                    Text = "Minu esimene vorm",
                    Size = new Size(200, 100),
                    Location = new Point(300, 0),
                    Font = new Font("ArialBlack", 15),
                    BorderStyle= BorderStyle.Fixed3D,
                    AutoSize = true
            };
                silt.MouseEnter += Silt_MouseEnter;
                silt.MouseLeave += Silt_MouseLeave;
                this.Controls.Add(silt);
            }
            else if (e.Node.Text== "Dialog aken-MessageBox")
            {
                MessageBox.Show("Tere päevast!","Kõike lihtne aken");
                var vastus = MessageBox.Show("Kas paneme aken kinni?","Error",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (vastus==DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hästi! Töötame edasi!");
                    var vastus1 = MessageBox.Show("Hahaha, saada mulle 500 euro või teie isikuandmed avaldatakse Internetti!","Scammer",MessageBoxButtons.YesNo,MessageBoxIcon.Stop);
                    if (vastus1==DialogResult.Yes)
                    {
                        this.Close();
                    }
                }

            }
        }
        public void Silt_MouseEnter(object sender, EventArgs e)
        {
            silt.ForeColor = Color.Black;
            silt.BackColor = Color.Purple;
        }
        public void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.ForeColor = Color.Black;
            silt.BackColor = Color.Transparent;
        }
        Random random = new Random();
        private void Nupp_Click(object sender, EventArgs e)
        {
            nupp.Font = new Font("French Script MT", 12);
            int red, green, blue;
            red=random.Next(255);
            green=random.Next(255);
            blue=random.Next(255);
            int red1, green1, blue1;
            red1 = random.Next(150);
            green1 = random.Next(150);
            blue1 = random.Next(150);
            nupp.BackColor = Color.FromArgb(red1, green1, blue1);
            this.BackColor = Color.FromArgb(red,green,blue);
        }
    }
}
