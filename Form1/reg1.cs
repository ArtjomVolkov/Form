using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Form1
{
    public class reg1 : Form
    {
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button2;
        private Button button1;

        public reg1()
        {
            Name = "reg1";
            Text = "Register";
            ClientSize = new System.Drawing.Size(284, 154);
            // 
            // label2
            // 
            label2 = new Label {
            AutoSize = true,
            Location = new System.Drawing.Point(10, 63),
            Name = "label2",
            Size = new System.Drawing.Size(37, 13),
            TabIndex = 11,
            Text = "Parool",
            };
            // 
            // label1
            // 
            label1 = new Label
            {
             AutoSize = true,
             Location = new System.Drawing.Point(10, 15),
             Name = "label1",
             Size = new System.Drawing.Size(66, 13),
             TabIndex = 10,
             Text = "Kasutajanimi",
            };
            // 
            // textBox2
            // 
            textBox2 = new TextBox {
            Location = new System.Drawing.Point(81, 60),
            Multiline = true,
            Name = "textBox2",
            PasswordChar = '*',
            Size = new System.Drawing.Size(165, 31),
            TabIndex = 9,
            };
            // 
            // textBox1
            // 
            textBox1 = new TextBox {
            Location = new System.Drawing.Point(82, 12),
            Multiline = true,
            Name = "textBox1",
            Size = new System.Drawing.Size(165, 31),
            TabIndex = 8,
            };
            // 
            // button2
            // 
            button2 = new Button
            {
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
                Location = new System.Drawing.Point(44, 108),
                Name = "button2",
                Size = new System.Drawing.Size(105, 33),
                TabIndex = 7,
                Text = "Cancel",
                UseVisualStyleBackColor = true,
            };
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1 = new Button {
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
            Location = new System.Drawing.Point(154, 108),
            Name = "button1",
            Size = new System.Drawing.Size(105, 33),
            TabIndex = 6,
            Text = "Register",
            UseVisualStyleBackColor = true,
            };
            button1.Click += button1_Click;
            // 
            // reg1
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            login1 login = new login1();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var sw = new System.IO.StreamWriter("@..\\..\\" + textBox1.Text + "\\login.ID");
                sw.Write(textBox1.Text + "\n" + textBox2.Text);
                sw.Close();
                Close();
                login1 login = new login1();
                login.Show();
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                System.IO.Directory.CreateDirectory("@..\\..\\" + textBox1.Text);
                var sw = new System.IO.StreamWriter("@..\\..\\" + textBox1.Text + "\\login.ID");
                sw.Write(textBox1.Text + "\n" + textBox2.Text);
                sw.Close();
                Close();
                login1 login = new login1();
                login.Show();
            }
        }
    }
}
