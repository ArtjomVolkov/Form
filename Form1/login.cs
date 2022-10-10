using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Form1
{
    public partial class login : Form
    {
        TextBox txtuname, txtpass;
        Button logins;
        Label name, pass;
        public login() {
            Height = 500; //высота
            Width = 400; //ширина
            Text = "Login"; //название формы
            BackColor = Color.Gray;
            txtuname = new TextBox
            {
                Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 200),
                Width = 150,
                Location = new Point(110, 80),
                Enabled = true
            };
            txtpass = new TextBox
            {
                Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 200),
                Width = 150,
                Location = new Point(110, 200),
                Enabled = true
            };
            logins = new Button
            {
                Text = "Login!",
                Height = 50,
                Width = 150,
                Location = new Point(110, 300),
            };
            name = new Label
            {
                Text = "Sisestage TAR",
                Width = 150,
                Location = new Point(110, 60),
            };
            pass = new Label
            {
                Text = "Sisestage 123",
                Width = 150,
                Location = new Point(110, 180),
            };
            this.Controls.Add(txtuname);
            this.Controls.Add(txtpass);
            this.Controls.Add(logins);
            this.Controls.Add(pass);
            this.Controls.Add(name);
            logins.Click += Logins_Click;
        }

        private void Logins_Click(object sender, EventArgs e)
        {
            if (txtuname.Text == "")
            {
                MessageBox.Show("Sisestage TAR !!", "Kasutajanimi");
            }
            else if (txtpass.Text == "")
            {
                MessageBox.Show("Sisestage 123 !!", "Parool");
            }
            else if (txtuname.Text == "TAR" && txtpass.Text == "123")
            {
                this.Hide();
                Form forms = new MinuOmaVorm();
                forms.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Credential", "Meera Academy");
            }
        }
    }
}
