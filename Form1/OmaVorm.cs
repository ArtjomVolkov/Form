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
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Text = Pealkiri;
            Button nupp = new Button
            {
                Text = Nupp,
                Location = new System.Drawing.Point(50,50),
                Size = new System.Drawing.Size(100,50),
                BackColor = System.Drawing.Color.DimGray,
            };
            nupp.Click += Nupp_Click;
            CheckBox failinimi = new CheckBox
            {
                Text = File,
                Location = new System.Drawing.Point(50, 150),
                Size = new System.Drawing.Size(50, 60),
                BackColor = System.Drawing.Color.DimGray,
            };
            //dsadasd
            CheckBox failinimi1 = new CheckBox
            {
                Text = File,
                Location = new System.Drawing.Point(50, 200),
                Size = new System.Drawing.Size(50, 60),
                BackColor = System.Drawing.Color.DimGray,
            };
            this.Controls.Add(nupp);
            this.Controls.Add(failinimi);
            this.Controls.Add(failinimi1);
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
