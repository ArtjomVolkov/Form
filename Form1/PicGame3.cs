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
    public partial class PicGame3 : Form
    {
        Random rnd = new Random();
        TableLayoutPanel tableLayoutPanel1;
        Label esimeneClicked = null;
        Label teineClicked = null;
        Timer timer1 = new Timer { Interval = 750 };
        List<string> icons = new List<string>()
        {
            "1", "1", "2", "2", "3", "3", "4", "4","5", "5", "6", "6", "7", "7", "8", "8","9", "9",
            "0", "0", "+", "+", "q", "q", "w", "w","e", "e", "r", "r", "t", "t", "y", "y","u", "u",
            "a", "a", "c", "c", "g", "g", "x", "x","p", "p", "j", "j", "n", "n", "b", "b","k", "k",
            "m", "m", "h", "h", "d", "d", "v", "v","l", "l",
        };
        public PicGame3()
        {
            CenterToScreen(); //ekraani keskel
            timer1.Tick += timer1_Tick; //taimer
            Text = "Matching game";
            ClientSize = new Size(800, 800);
            tableLayoutPanel1 = new TableLayoutPanel
            {
                BackColor = System.Drawing.Color.Cornsilk,
                Dock = System.Windows.Forms.DockStyle.Fill,
                CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset,
                RowCount = 8,
                ColumnCount = 8
            };
            this.Controls.Add(tableLayoutPanel1);
            for (int i = 0; i < 8; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                for (int j = 0; j < 8; j++)
                {

                    Label lbl1 = new Label
                    {
                        BackColor = Color.DarkRed,
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
                    iconLabel1.Text = icons[randomNumber];
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
            timer1.Stop();
            CheckForWinner();
        }
        private void AgainGame()
        {
            var vastus = MessageBox.Show("Kas sa tahad veel mängida? !!EASY!!", "küsimus", MessageBoxButtons.YesNo);

            if (vastus == DialogResult.Yes)
            {
                Close();
                PicGame ns = new PicGame();
                ns.Show();
            }
            else
            {
                MessageBox.Show(":(");
                Close();
            }
        }
        private void CheckForWinner()
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
            MessageBox.Show("Sa sobitasid kõik ikoonid!", "Palju õnne", 0, MessageBoxIcon.Information);
            AgainGame();
        }
    }
}
