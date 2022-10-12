using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class SplashScreen : Form
    {
        PictureBox pictureBox1;
        ProgressBar progressBar1;
        public SplashScreen()
        {
            Size = new System.Drawing.Size(401, 302); //ekraani resolutsioon
            Text = "SplashScreen";
            Name = "SplashScreen1";
            pictureBox1 = new PictureBox {
                Location = new System.Drawing.Point(-84, 12),
                Name = "pictureBox1",
                Size = new System.Drawing.Size(563, 209),
                ImageLocation = @"..\..\monkey.gif",
                TabIndex = 0,
                TabStop = false,
            };
            
            // 
            // progressBar1
            // 
            progressBar1 = new ProgressBar
            {
                Location = new System.Drawing.Point(23, 227),
                MarqueeAnimationSpeed = 50,
                Name = "progressBar1",
                Size = new System.Drawing.Size(350, 16),
                Style = System.Windows.Forms.ProgressBarStyle.Marquee,
                TabIndex = 1,
            };
            this.Controls.Add(pictureBox1);
            this.Controls.Add(progressBar1);
        }
    }
}
