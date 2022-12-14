using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_rakenduste_loomine
{
    public partial class PicGame : Form
    {
        Random rnd = new Random(); //random
        TableLayoutPanel tableLayoutPanel1;
        Label esimeneClicked = null;
        Label teineClicked = null;
        Timer timer1 = new Timer { Interval = 750 };
        Timer timer2 = new Timer { Interval = 40, Enabled = true, };
        Timer timer3 = new Timer { Interval = 40, Enabled = false, };
        List<string> icons = new List<string>() //list
        {
            "a", "a", "c", "c", "q", "q", "x", "x",
            "l", "l", "f", "f", "v", "v", "w", "w"
        };
        public PicGame()
        {
            timer3.Tick += timer3_Tick; //taimer
            timer2.Tick += timer2_Tick; //taimer
            CenterToScreen(); //ekraani keskel
            timer1.Tick += timer1_Tick; //taimer
            Text = "Matching game";
            ClientSize = new Size(455, 455); //vormi suurus
            tableLayoutPanel1 = new TableLayoutPanel
            {
                BackColor = System.Drawing.Color.Cornsilk,
                Dock = System.Windows.Forms.DockStyle.Fill,
                CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset,
                RowCount = 4,
                ColumnCount = 4
            };
            this.Controls.Add(tableLayoutPanel1);
            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                for (int j = 0; j < 4; j++)
                {

                    Label lbl1 = new Label
                    {
                        BackColor = Color.Blue,
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Text = "c",
                        Font = new Font("Webdings", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2))),
                    };


                    tableLayoutPanel1.Controls.Add(lbl1, i, j);
                };

            }
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel1 = control as Label;
                if (iconLabel1 != null)
                {
                    int randomNumber = rnd.Next(icons.Count);
                    iconLabel1.Text = icons[randomNumber]; //loeb lehte, kui palju andmeid
                    icons.RemoveAt(randomNumber);
                }
                iconLabel1.ForeColor = iconLabel1.BackColor;
                iconLabel1.Click += label1_Click;
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (esimeneClicked == null)
                {
                    esimeneClicked = clickedLabel;
                    esimeneClicked.ForeColor = Color.Black;
                    return;
                }

                teineClicked = clickedLabel;
                teineClicked.ForeColor = Color.Black;
                timer1.Start();
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Opacity==0)
            {
                this.Close();
            }
            Opacity -= .2;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity==1)
            {
                timer2.Stop();
            }
            Opacity += .2;
        }
            private void timer1_Tick(object sender, EventArgs e)
        {

            if (esimeneClicked.Text == teineClicked.Text)
            {
                esimeneClicked.ForeColor = esimeneClicked.ForeColor;
                teineClicked.ForeColor = teineClicked.ForeColor;
            }
            else
            {
                esimeneClicked.ForeColor = esimeneClicked.BackColor;
                teineClicked.ForeColor = teineClicked.BackColor;
            }
            esimeneClicked = null;
            teineClicked = null;
            timer1.Stop(); //mäng lõpeb
            CheckForWinner();
        }
        private void AgainGame()
        {
            var vastus = MessageBox.Show("Kas sa tahad veel mängida? !!HARD!!", "küsimus", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (vastus == DialogResult.Yes)
            {
                timer3.Start();
                Close();
                PicGame2 ns = new PicGame2(); //avab hard režiimi
                ns.Show();
            }
            else
            {
                MessageBox.Show("Okey! :("); //kinnitab
                Close();
            }
        }
        private void CheckForWinner() //kogus kõik pildid kokku ja võitis
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"..\..\music13.wav");
            player.Play();
            MessageBox.Show("Sa sobitasid kõik ikoonid!", "Palju õnne",0,MessageBoxIcon.Information);
            AgainGame();
        }
    }
}
