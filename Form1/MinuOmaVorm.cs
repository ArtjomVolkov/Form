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
        CheckBox mruut1, mruut2;
        ProgressBar riba;
        RadioButton rnupp1,rnupp2,rnupp3,rnupp4;
        PictureBox pilt;
        Button button4;
        Timer aeg;
        TextBox tekst;
        CheckBox music,music1;
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
            oksad.Nodes.Add(new TreeNode("CheckBox"));
            oksad.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            oksad.Nodes.Add(new TreeNode("ProgressBar"));
            oksad.Nodes.Add(new TreeNode("Mouse-button"));
            oksad.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            oksad.Nodes.Add(new TreeNode("OmaVorm-Myform"));
            oksad.Nodes.Add(new TreeNode("Picture-Viewer"));
            oksad.Nodes.Add(new TreeNode("Math-Quiz"));
            oksad.Nodes.Add(new TreeNode("Picture-Game"));
            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            puu.DoubleClick += Tekst_MouseDoubleClick;
            this.Controls.Add(puu);
        }
        
        private void Puu_AfterSelect(object sender,TreeViewEventArgs e)
        {
            silt = new Label
            {
                Text = "Minu oma vorm koos elementidega",
                Size = new Size(200, 50),
                Location = new Point(200, 0)
            };
            mruut1 = new CheckBox
            {
                Checked = false,
                Text = "TARpv21",
                Location = new Point(silt.Left + silt.Width, 30),
                Height = 50
            };
            mruut2 = new CheckBox
            {
                Checked = false,
                Text = "LOGITpv21",
                Location = new Point(silt.Left + silt.Width, 75),
                Height = 50
            };
            music = new CheckBox
            {
                Checked = false,
                Text = "Music 1",
                Location = new Point(120,100),
                Height = 50
            };
            music1 = new CheckBox
            {
                Checked = false,
                Text = "Music 2",
                Location = new Point(150, 100),
                Height = 50
            };
            if (e.Node.Text== "Nupp-Button")
            {
                nupp = new Button();
                nupp.Text = "Valjuta siia";
                nupp.Height = 30;
                nupp.Width = 100;
                nupp.Location = new Point(340, 150);
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
            else if (e.Node.Text=="CheckBox")
            {
                
                mruut1.CheckedChanged += new EventHandler(Mruut_1_2_Changed);
                mruut2.CheckedChanged += new EventHandler(Mruut_1_2_Changed);
                this.Controls.Add(mruut1);
                this.Controls.Add(mruut2);
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                rnupp1 = new RadioButton
                {
                    Text = "Paremale",
                    Width = 112,
                    Location=new Point(mruut2.Left+mruut2.Width, mruut1.Height + mruut2.Height)
                };
                rnupp2 = new RadioButton
                {
                    Text = "Vasakule",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width+rnupp1.Width, mruut1.Height + mruut2.Height)
                };
                rnupp3 = new RadioButton
                {
                    Text = "Ülesse",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width+rnupp2.Width+rnupp1.Width, mruut1.Height + mruut2.Height)
                };
                rnupp4 = new RadioButton
                {
                    Text = "Alla",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width+rnupp3.Width+rnupp1.Width+rnupp2.Width, mruut1.Height + mruut2.Height)
                };
                pilt = new PictureBox
                {
                    Image=new Bitmap("pgn.png"),
                    Location=new Point(300,300),
                    Size=new Size(100,100),
                    SizeMode=PictureBoxSizeMode.Zoom
                };
                rnupp1.CheckedChanged += new EventHandler(sizepic);
                rnupp2.CheckedChanged += new EventHandler(sizepic);
                rnupp3.CheckedChanged += new EventHandler(sizepic);
                rnupp4.CheckedChanged += new EventHandler(sizepic);
                this.Controls.Add(rnupp1);
                this.Controls.Add(rnupp2);
                this.Controls.Add(rnupp3);
                this.Controls.Add(rnupp4);
                this.Controls.Add(pilt);
            }
            else if (e.Node.Text == "ProgressBar")
            {
                riba = new ProgressBar
                {
                    Value = 0,
                    Minimum = 0,
                    Maximum = 100,
                    Step = 1,
                    Dock = DockStyle.Bottom

                };
                aeg = new Timer();
                aeg.Enabled = true;
                aeg.Tick += Aeg_Tick;
                this.Controls.Add(riba);
            }
            else if (e.Node.Text == "Mouse-button")
            {
                button4 = new Button();
                button4.Text = "Klõpsake!";
                button4.Height = 30;
                button4.Width = 100;
                button4.Location = new Point(340, 340);
                button4.MouseMove += button4_MouseMove;
                this.Controls.Add(button4);
            }
            else if (e.Node.Text == "Tekstkast-TextBox")
            {
                tekst = new TextBox
                {
                    Font = new Font("Arial",34,FontStyle.Bold),
                    Width = 150,
                    Location = new Point(200,360),
                    Enabled = true
                };
                tekst.MouseDoubleClick += Tekst_MouseDoubleClick;
                this.Controls.Add(tekst);
            }
            else if (e.Node.Text == "OmaVorm-Myform")
            {
                //music.CheckedChanged += new EventHandler(Music_Changed);
                //music1.CheckedChanged += new EventHandler(Music_Changed);
                OmaVorm oma = new OmaVorm("Kuulame muusikat","Valige muusika","Music");
                oma.ShowDialog();
            }
            else if (e.Node.Text == "Picture-Viewer")
            {
                Viewer viewer = new Viewer();
                viewer.ShowDialog();
            }
            else if (e.Node.Text == "Math-Quiz")
            {
                MathQuiz math = new MathQuiz();
                math.ShowDialog();
            }
            else if (e.Node.Text == "Picture-Game")
            {
                PicGame game = new PicGame();
                game.ShowDialog();
            }
        }
        //bool t=false;
        
        private void Tekst_MouseDoubleClick(object sender, EventArgs e)
        {
            if (tekst.Enabled)
            {
                tekst.Enabled = false;
            }
            else
            {
                tekst.Enabled = true;
            }
        }

        private void Aeg_Tick(object sender, EventArgs e)
        {
            riba.PerformStep();
            BackColor = Color.Red;
            MessageBox.Show("VIIRUS!", "VIRUS",0,MessageBoxIcon.Warning);
             
            
        }
        int x = 300;
        int y = 300;
        private void sizepic(object sender, EventArgs e)
        {
            if (rnupp1.Checked)
            {
                x += 20;
                pilt.Location = new Point(x, y);
                rnupp1.Checked = false;
            }
            else if (rnupp2.Checked)
            {
                x -= 20;
                pilt.Location = new Point(x, y);
                rnupp2.Checked = false;
            }
            else if (rnupp3.Checked)
            {
                y -= 20;
                pilt.Location = new Point(x, y);
                rnupp3.Checked = false;
            }
            else if (rnupp4.Checked)
            {
                y += 20;
                pilt.Location = new Point(x, y);
                rnupp4.Checked = false;
            }
        }
        private void button4_MouseMove(object sender, MouseEventArgs e)
        {

            Random x = new Random();
            Random y = new Random();
            int xx = Convert.ToInt32(x.Next(124, 300));
            int yy = Convert.ToInt32(y.Next(35, 250));
            button4.Location = new Point(xx, yy);

        }
        private void Mruut_1_2_Changed(object sender, EventArgs e)
        {
            if (mruut1.Checked == true && mruut2.Checked == true)
            {
                BackColor = Color.Green;
                MessageBox.Show("Green","Color", 0, MessageBoxIcon.Hand);
            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {
                BackColor = Color.Yellow;
                MessageBox.Show("Yellow", "Color", 0, MessageBoxIcon.Hand);
            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {
                BackColor = Color.Blue;
                MessageBox.Show("Blue", "Color", 0, MessageBoxIcon.Hand);
            }
            else if (mruut1.Checked == false && mruut2.Checked == false)
            {
                BackColor = Color.LightSkyBlue;
                MessageBox.Show("LightSkyBlue", "Color",0,MessageBoxIcon.Hand);
            }
        }
        /*    private void Mruut2_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked == true && mruut2.Checked == true)
            {

            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {

            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {

            }
            else if (mruut1.Checked == false && mruut2.Checked == false)
            {

            }
        }

        private void Mruut1_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked==true && mruut2.Checked==true)
            {
                BackColor = Color.Green;
            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {
                BackColor = Color.Yellow;
            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {
                BackColor = Color.Blue;
            }
            else if (mruut1.Checked == false && mruut2.Checked == false)
            {
                BackColor = Color.LightSkyBlue;
            }
        }*/

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
