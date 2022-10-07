using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public class Viewer : Form
    {
        TableLayoutPanel tableLayoutPanel;
        PictureBox picturebox;
        CheckBox checkBox;
        Button close, backgroundcolor, clear, showapicture, picture, colorsa;
        ColorDialog colordialog;
        OpenFileDialog openfiledialog1;
        FlowLayoutPanel flowlayoutpanel;

        public Viewer()
        {
            Size = new System.Drawing.Size(600, 400); //ekraani resolutsioon
            Text = "Pildivaatur";
            tableLayoutPanel = new TableLayoutPanel //ekraan
            {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 2,
                Location = new Point(0, 0),
                Size = new Size(534, 311),
                TabIndex = 0,
                BackColor = Color.White,
            };
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
                (SizeType.Percent, 15F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
                (SizeType.Percent, 85F));
            tableLayoutPanel.ColumnStyles.Add(new RowStyle
                (SizeType.Percent, 90F));
            tableLayoutPanel.ColumnStyles.Add(new RowStyle
                (SizeType.Percent, 5F));
            tableLayoutPanel.ResumeLayout(false);

            this.Controls.Add(tableLayoutPanel);


            picturebox = new System.Windows.Forms.PictureBox //ekraan, kus pilti kuvatakse
            {
                BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(2, 2),
                Size = new System.Drawing.Size(528, 269),
                TabIndex = 0,
                TabStop = false,
            };
            tableLayoutPanel.Controls.Add(picturebox, 0, 0);
            tableLayoutPanel.SetCellPosition(picturebox, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel.SetColumnSpan(picturebox, 2);

            checkBox = new CheckBox //venitada pilt
            {
                AutoSize = true,
                Location = new System.Drawing.Point(3, 278),
                Size = new System.Drawing.Size(117, 30),
                TabIndex = 1,
                UseVisualStyleBackColor = true,
                Text = "Venitada",
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            checkBox.CheckedChanged += new System.EventHandler(checkBox_CheckedChanged);
            tableLayoutPanel.Controls.Add(checkBox, 1, 0);
            this.Controls.Add(tableLayoutPanel);


            close = new Button //sulgeb vorm
            {
                AutoSize = true,
                Location = new System.Drawing.Point(3, 3),
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 0,
                Text = "Sulge",
                UseVisualStyleBackColor = true,


            };
            this.close.Click += new System.EventHandler(this.close_Click);
            tableLayoutPanel.Controls.Add(close);

            colordialog = new ColorDialog
            {
                AllowFullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Color.Red,
            };
            backgroundcolor = new Button //selja värvi muutmine
            {
                AutoSize = true,
                Location = new System.Drawing.Point(84, 3),
                Size = new System.Drawing.Size(121, 23),
                TabIndex = 1,
                Text = "BackgroundColor",
                UseVisualStyleBackColor = true,

            };
            tableLayoutPanel.Controls.Add(backgroundcolor);
            this.backgroundcolor.Click += new System.EventHandler(this.backgroundcolor_Click);


            clear = new Button //eemalda pilt
            {
                AutoSize = true,
                Location = new System.Drawing.Point(211, 3),
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 2,
                Text = "Kustuta",
                UseVisualStyleBackColor = true,
            };
            tableLayoutPanel.Controls.Add(clear);
            this.clear.Click += new System.EventHandler(this.clear_Click);

            showapicture = new Button //näita pilti
            {
                AutoSize = true,
                Location = new System.Drawing.Point(292, 3),
                Size = new System.Drawing.Size(102, 23),
                TabIndex = 3,
                Text = "Näita pilti",
                UseVisualStyleBackColor = true,

            };
            tableLayoutPanel.Controls.Add(showapicture);
            this.showapicture.Click += new System.EventHandler(this.showapicture_Click);

            openfiledialog1 = new OpenFileDialog //laiendus, mille abil saab fotosid üles laadida
            {
                RestoreDirectory = true,
                Title = "Sirvige tekstifaile",
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" + "s (*.*)|*.*",
            };
            picture = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(200, 3),
                Size = new System.Drawing.Size(102, 23),
                TabIndex = 0,
                Text = "TTHK",
                UseVisualStyleBackColor = true,
            };
            this.picture.Click += Picture_Click;
            tableLayoutPanel.Controls.Add(picture);
            colorsa = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(250, 3),
                Size = new System.Drawing.Size(102, 23),
                TabIndex = 0,
                Text = "Rnd Color",
                UseVisualStyleBackColor = true,
            };
            this.colorsa.Click += Colorsa_Click;
            tableLayoutPanel.Controls.Add(colorsa);
            Button[] buttons = { clear, showapicture, close, backgroundcolor };
            flowlayoutpanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Size = new Size(200, 50),
            };
            flowlayoutpanel.Controls.AddRange(buttons);
            tableLayoutPanel.Controls.Add(flowlayoutpanel, 1, 1);
            this.Controls.Add(tableLayoutPanel);
        }

        private void Colorsa_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            picturebox.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), 0);
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            picturebox.Load("tthk.jpg");
        }

        private void clear_Click(object sender, EventArgs e) //kustuta
        {
            picturebox.Image = null;
        }

        private void backgroundcolor_Click(object sender, EventArgs e) //värvi muuta
        {
            if (colordialog.ShowDialog() == DialogResult.OK)
            {
                picturebox.BackColor = colordialog.Color;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e) //kinnita
        {
            this.Close();
        }

        private void showapicture_Click(object sender, EventArgs e) //ava pilt
        {
            if (openfiledialog1.ShowDialog() == DialogResult.OK)
            {
                picturebox.Load(openfiledialog1.FileName);
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e) //muudab režiime
        {
            if (checkBox.Checked)
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                picturebox.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}
