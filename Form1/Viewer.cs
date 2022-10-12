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
        CheckBox checkBox,checkBox1;
        Button close, backgroundcolor, clear, showapicture, picture, colorsa,start,stop,invert;
        ColorDialog colordialog;
        OpenFileDialog openfiledialog1;
        FlowLayoutPanel flowlayoutpanel,flowlayoutpanel1;
        Timer timer1;
        int imgNum = 1;
        FolderBrowserDialog fbd;

        public Viewer()
        {
            Size = new System.Drawing.Size(700, 460); //ekraani resolutsioon
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
            checkBox1 = new CheckBox //venitada pilt
            {
                AutoSize = true,
                Location = new System.Drawing.Point(3, 278),
                Size = new System.Drawing.Size(117, 30),
                TabIndex = 1,
                UseVisualStyleBackColor = true,
                Text = "Zoom",
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            tableLayoutPanel.Controls.Add(checkBox1, 1, 1);
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
            tableLayoutPanel.Controls.Add(picture, 2, 3);
            colorsa = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(250, 2),
                Size = new System.Drawing.Size(102, 23),
                TabIndex = 0,
                Text = "Rnd Color",
                UseVisualStyleBackColor = true,
            };
            this.colorsa.Click += Colorsa_Click;
            tableLayoutPanel.Controls.Add(colorsa);
            tableLayoutPanel.Controls.Add(colorsa, 2, 2);
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
            start = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(250, 2),
                Size = new System.Drawing.Size(102, 23),
                TabIndex = 0,
                Text = "SlideShow start",
                UseVisualStyleBackColor = true,
            };
            this.start.Click += Start_Click;
            tableLayoutPanel.Controls.Add(start);
            tableLayoutPanel.Controls.Add(start, 2, 4);
            invert = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(250, 2),
                Size = new System.Drawing.Size(102, 23),
                TabIndex = 0,
                Text = "Invert",
                UseVisualStyleBackColor = true,
            };
            this.invert.Click += Button1_Click;
            

            stop = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(250, 2),
                Size = new System.Drawing.Size(102, 23),
                TabIndex = 0,
                Text = "SlideShow stop",
                UseVisualStyleBackColor = true,
            };
            this.stop.Click += Stop_Click;
            tableLayoutPanel.Controls.Add(stop);
            tableLayoutPanel.Controls.Add(stop, 2, 5);
            Button[] buttonsi = { colorsa,start,stop,picture,invert };
            flowlayoutpanel1 = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Size = new Size(200, 50),
            };
            flowlayoutpanel1.Controls.AddRange(buttonsi);
            tableLayoutPanel.Controls.Add(flowlayoutpanel1, 2, 1);
            this.Controls.Add(tableLayoutPanel);
            tableLayoutPanel.Controls.Add(invert);
            tableLayoutPanel.Controls.Add(invert, 2, 6);
            timer1 = new Timer
            {
                Interval = 1000,
            };
            timer1.Tick += timer1_Tick;
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            Bitmap pic = new Bitmap(picturebox.Image);
            for (int y = 0; (y
                        <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x
                            <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                    picturebox.Image = pic;
                }

            }

        }
        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            picturebox.Image = null;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            picturebox.ImageLocation = string.Format(fbd.SelectedPath + "\\img{0}.jpg", imgNum);
            imgNum++;
            if (imgNum == 3)
                imgNum = 1;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                picturebox.SizeMode = PictureBoxSizeMode.Zoom;
            else
                picturebox.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void Colorsa_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            picturebox.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), 0);
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            picturebox.ImageLocation= @"..\..\tthk.jpg";
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
