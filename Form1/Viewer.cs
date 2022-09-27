using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public class Viewer : Form
    {
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button close;
        private Button bgcolor;
        private Button picclear;
        private Button show;
        private CheckBox cb1;
        private OpenFileDialog openFileDialog1;
        private ColorDialog colorDialog1;
        private TableLayoutPanel tableLayoutPanel1;
        public Viewer()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.close = new System.Windows.Forms.Button();
            this.bgcolor = new System.Windows.Forms.Button();
            this.picclear = new System.Windows.Forms.Button();
            this.show = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.66292F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.33708F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cb1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.49518F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.50482F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(534, 311);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(528, 263);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.18F);
            this.cb1.Location = new System.Drawing.Point(3, 272);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(60, 17);
            this.cb1.TabIndex = 1;
            this.cb1.Text = "Stretch";
            this.cb1.UseVisualStyleBackColor = true;
            this.cb1.CheckedChanged += new System.EventHandler(this.cb1_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.close);
            this.flowLayoutPanel1.Controls.Add(this.bgcolor);
            this.flowLayoutPanel1.Controls.Add(this.picclear);
            this.flowLayoutPanel1.Controls.Add(this.show);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(108, 272);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(423, 36);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Location = new System.Drawing.Point(3, 3);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 0;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // bgcolor
            // 
            this.bgcolor.AutoSize = true;
            this.bgcolor.Location = new System.Drawing.Point(84, 3);
            this.bgcolor.Name = "bgcolor";
            this.bgcolor.Size = new System.Drawing.Size(75, 23);
            this.bgcolor.TabIndex = 1;
            this.bgcolor.Text = "Color Bg";
            this.bgcolor.UseVisualStyleBackColor = true;
            this.bgcolor.Click += new System.EventHandler(this.bgcolor_Click);
            // 
            // picclear
            // 
            this.picclear.AutoSize = true;
            this.picclear.Location = new System.Drawing.Point(165, 3);
            this.picclear.Name = "picclear";
            this.picclear.Size = new System.Drawing.Size(99, 23);
            this.picclear.TabIndex = 2;
            this.picclear.Text = "Clear The Picture";
            this.picclear.UseVisualStyleBackColor = true;
            this.picclear.Click += new System.EventHandler(this.picclear_Click);
            // 
            // show
            // 
            this.show.AutoSize = true;
            this.show.Location = new System.Drawing.Point(270, 3);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(102, 23);
            this.show.TabIndex = 3;
            this.show.Text = "Show The Picture";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png\";";
            this.openFileDialog1.Title = "Select a Picture";
            // 
            // Viewer
            // 
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Viewer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgcolor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void picclear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void show_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void cb1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Viewer
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Viewer";
            this.Text = "Viewer The Picture";
            this.ResumeLayout(false);

        }
    }
}
