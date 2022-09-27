using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public class MathQuiz:Form
    {
        Random rnd = new Random();
        string[] Maths = { "Add", "Subtract", "Multiply" };
        int total;
        int score;
        private Label lblScore;
        private Label lblSymbol;
        private Label lblNumB;
        private Label label4;
        private Label lblAnswer;
        private TextBox txtAnswer;
        private Button button1;
        private Label lblNumA;

        public MathQuiz()
        {
            InitializeComponent();
            SetUpGame();
        }
        internal void InitializeComponent()
        {
            this.lblScore = new System.Windows.Forms.Label();
            this.lblNumA = new System.Windows.Forms.Label();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.lblNumB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.ForeColor = System.Drawing.Color.Maroon;
            this.lblScore.Location = new System.Drawing.Point(12, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(47, 13);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score: 0";
            // 
            // lblNumA
            // 
            this.lblNumA.AutoSize = true;
            this.lblNumA.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumA.Location = new System.Drawing.Point(14, 40);
            this.lblNumA.Name = "lblNumA";
            this.lblNumA.Size = new System.Drawing.Size(49, 33);
            this.lblNumA.TabIndex = 1;
            this.lblNumA.Text = "00";
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSymbol.Location = new System.Drawing.Point(69, 40);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(33, 33);
            this.lblSymbol.TabIndex = 2;
            this.lblSymbol.Text = "+";
            // 
            // lblNumB
            // 
            this.lblNumB.AutoSize = true;
            this.lblNumB.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumB.Location = new System.Drawing.Point(108, 40);
            this.lblNumB.Name = "lblNumB";
            this.lblNumB.Size = new System.Drawing.Size(49, 33);
            this.lblNumB.TabIndex = 3;
            this.lblNumB.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(163, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 33);
            this.label4.TabIndex = 4;
            this.label4.Text = "=";
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAnswer.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblAnswer.Location = new System.Drawing.Point(13, 102);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(47, 13);
            this.lblAnswer.TabIndex = 5;
            this.lblAnswer.Text = "correct";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAnswer.Location = new System.Drawing.Point(202, 40);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(82, 33);
            this.txtAnswer.TabIndex = 6;
            this.txtAnswer.TextChanged += new System.EventHandler(this.CheckAnswer);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(290, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CheckButtonClickEvent);
            // 
            // MathQuiz
            // 
            this.ClientSize = new System.Drawing.Size(378, 139);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblNumB);
            this.Controls.Add(this.lblSymbol);
            this.Controls.Add(this.lblNumA);
            this.Controls.Add(this.lblScore);
            this.Name = "MathQuiz";
            this.Text = "Maths Quiz Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void CheckAnswer(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAnswer.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers!");
                txtAnswer.Text = txtAnswer.Text.Remove(txtAnswer.Text.Length - 1);
            }
        }

        private void CheckButtonClickEvent(object sender, EventArgs e)
        {

            int userEntered = Convert.ToInt32(txtAnswer.Text);

            if (userEntered == total)
            {
                lblAnswer.Text = "Correct";
                lblAnswer.ForeColor = Color.Green;
                score += 1;
                lblScore.Text = "Score: " + score;
                SetUpGame();

            }
            else
            {
                lblAnswer.Text = "Incorrect";
                lblAnswer.ForeColor = Color.Red;
            }

        }

        private void SetUpGame()
        {
            int numA = rnd.Next(10, 20);
            int numB = rnd.Next(0, 9);

            txtAnswer.Text = null;

            switch (Maths[rnd.Next(0, Maths.Length)])
            {
                case "Add":
                    total = numA + numB;
                    lblSymbol.Text = "+";
                    lblSymbol.ForeColor = Color.DarkGreen;
                    break;

                case "Subtract":
                    total = numA - numB;
                    lblSymbol.Text = "-";
                    lblSymbol.ForeColor = Color.Maroon;
                    break;

                case "Multiply":
                    total = numA * numB;
                    lblSymbol.Text = "x";
                    lblSymbol.ForeColor = Color.Purple;
                    break;
            }

            lblNumA.Text = numA.ToString();
            lblNumB.Text = numB.ToString();
        }

    }
}
