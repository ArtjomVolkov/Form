using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public class login1 : Form
    {
        public string kasutajanimi, parool;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;

        public login1()
        {
            Size = new System.Drawing.Size(292, 200); //ekraani resolutsioon
            Text = "Login";
            Name = "login1";
            // 
            // button1
            // 
            button1 = new Button
            {
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
                Location = new System.Drawing.Point(44, 120),
                Name = "button1",
                Size = new System.Drawing.Size(105, 33),
                TabIndex = 0,
                Text = "Register",
                UseVisualStyleBackColor = true,
            };
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2 = new Button
            {
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
                Location = new System.Drawing.Point(154, 120),
                Name = "button2",
                Size = new System.Drawing.Size(105, 33),
                TabIndex = 1,
                Text = "Login",
                UseVisualStyleBackColor = true,
            };
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1 = new TextBox {
                Location = new System.Drawing.Point(84, 24),
                Multiline = true,
                Name = "textBox1",
                Size = new System.Drawing.Size(165, 31),
                TabIndex = 2,
            };
            // 
            // textBox2
            // 
            textBox2 = new TextBox {
                Location = new System.Drawing.Point(83, 72),
                Multiline = true,
                Name = "textBox2",
                PasswordChar = '*',
                Size = new System.Drawing.Size(165, 31),
                TabIndex = 3,
            };
            // 
            // label1
            // 
            label1 = new Label {
                AutoSize = true,
                Location = new System.Drawing.Point(12, 27),
                Name = "label1",
                Size = new System.Drawing.Size(66, 13),
                TabIndex = 4,
                Text = "Kasutajanimi",
            };
            // 
            // label2
            // 
            label2 = new Label {
            AutoSize = true,
            Location = new System.Drawing.Point(12, 75),
            Name = "label2",
            Size = new System.Drawing.Size(37, 13),
            TabIndex = 5,
            Text = "Parool",
            };
            // 
            // login1
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            reg1 register = new reg1();
            register.Show();
            Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var sr = new System.IO.StreamReader("@..\\..\\" + textBox1.Text + "\\login.ID");
                kasutajanimi = sr.ReadLine();
                parool = sr.ReadLine();
                sr.Close();

                if (kasutajanimi == textBox1.Text && parool==textBox2.Text)
                {
                    MinuOmaVorm minuOmaVorm = new MinuOmaVorm();
                    minuOmaVorm.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Vale", "Vale!",0,MessageBoxIcon.Stop);
                }
            }
            catch(System.IO.DirectoryNotFoundException ex)
            {
                MessageBox.Show("Vale parool või kasutajanimi!", "Vale!", 0, MessageBoxIcon.Stop);
            }
        }
    }
}
