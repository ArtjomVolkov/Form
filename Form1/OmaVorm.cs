using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public class OmaVorm:Form
    {
        public OmaVorm()
        {

        }

        public OmaVorm(string Pealkiri,string Nupp,string File)
        {
            this.ClientSize = new System.Drawing.Size(250, 300);
            this.Text = Pealkiri;
            Button nupp = new Button
            {
                Text = Nupp,
                Location = new System.Drawing.Point(70,50),
                Size = new System.Drawing.Size(100,50),
                BackColor = System.Drawing.Color.DimGray,
            };
            nupp.Click += Nupp_Click;
            Label failinimi = new Label
            {
                Text = String.Format("Кайф ты поймала"),
                Location = new System.Drawing.Point(50, 150),
                Size = new System.Drawing.Size(50, 30),
                BackColor = System.Drawing.Color.DimGray,
            };
            failinimi.Click += Failinimi_Click;
            //dsadasd
            Label failinimi1 = new Label
            {
                Text = String.Format("Дискотека"),
                Location = new System.Drawing.Point(50, 200),
                Size = new System.Drawing.Size(50, 30),
                BackColor = System.Drawing.Color.DimGray,
            };
            failinimi1.Click += Failinimi1_Click;
            Label failinimi4 = new Label
            {
                Text = String.Format("Спят усталые"),
                Location = new System.Drawing.Point(150, 150),
                Size = new System.Drawing.Size(50, 30),
                BackColor = System.Drawing.Color.DimGray,
            };
            failinimi4.Click += Failinimi4_Click;
            Label failinimi5 = new Label
            {
                Text = String.Format("Ашот"),
                Location = new System.Drawing.Point(150, 200),
                Size = new System.Drawing.Size(50, 30),
                BackColor = System.Drawing.Color.DimGray,
            };
            failinimi5.Click += Failinimi5_Click;
            this.Controls.Add(nupp);
            this.Controls.Add(failinimi);
            this.Controls.Add(failinimi1);
            this.Controls.Add(failinimi4);
            this.Controls.Add(failinimi5);
        }

        private void Failinimi5_Click(object sender, EventArgs e)
        {
            Label fail_sender = (Label)sender;
            var vastus = MessageBox.Show("Kas tahad muusikat kuulata?", "küsimus", MessageBoxButtons.YesNo);

            if (vastus == DialogResult.Yes)
            {
                using (var muusika = new SoundPlayer(@"..\..\music5.wav"))
                {
                    muusika.Play();
                }
            }
            else
            {
                MessageBox.Show(":(");
            }
        }

        private void Failinimi4_Click(object sender, EventArgs e)
        {
            Label fail_sender = (Label)sender;
            var vastus = MessageBox.Show("Kas tahad muusikat kuulata?", "küsimus", MessageBoxButtons.YesNo);

            if (vastus == DialogResult.Yes)
            {
                using (var muusika = new SoundPlayer(@"..\..\music4.wav"))
                {
                    muusika.Play();
                }
            }
            else
            {
                MessageBox.Show(":(");
            }
        }

        private void Failinimi1_Click(object sender, EventArgs e)
        {
            Label fail_sender = (Label)sender;
            var vastus = MessageBox.Show("Kas tahad muusikat kuulata?", "küsimus", MessageBoxButtons.YesNo);

            if (vastus == DialogResult.Yes)
            {
                using (var muusika = new SoundPlayer(@"..\..\music.wav"))
                {
                    muusika.Play();
                }
            }
            else
            {
                MessageBox.Show(":(");
            }
        }

        private void Failinimi_Click(object sender, EventArgs e)
        {
            Label fail_sender = (Label)sender;
            var vastus = MessageBox.Show("Kas tahad muusikat kuulata?", "küsimus", MessageBoxButtons.YesNo);

            if (vastus == DialogResult.Yes)
            {
                using (var muusika = new SoundPlayer(@"..\..\music1.wav"))
                {
                    muusika.Play();
                }
            }
            else
            {
                MessageBox.Show(":(");
            }
        }

        private void Nupp_Click(object sender, EventArgs e)
        {
            Button nupp_sender = (Button)sender;
            var vastus = MessageBox.Show("Kas tahad muuikat kuulata?","Küsimus",MessageBoxButtons.YesNo,MessageBoxIcon.Hand);
            if (vastus == DialogResult.Yes)
            {
                using (var muusika = new SoundPlayer(@"..\..\music5.wav"))
                {
                    muusika.Play();
                }
            }
            else
            {
                MessageBox.Show(":I");
            }
        }
    }
}
