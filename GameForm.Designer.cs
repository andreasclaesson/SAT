namespace SAT
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblQuestion = new Label();
            rbOption1 = new RadioButton();
            rbOption2 = new RadioButton();
            rbOption3 = new RadioButton();
            rbOption4 = new RadioButton();
            btnSubmit = new Button();
            lblScore = new Label();
            btnRestart = new Button();
            questionTimer = new System.Windows.Forms.Timer(components);
            btnHint = new Button();
            label1 = new Label();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblQuestion.Location = new Point(26, 58);
            lblQuestion.Margin = new Padding(5, 0, 5, 0);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(666, 61);
            lblQuestion.TabIndex = 1;
            lblQuestion.Text = "Question goes here";
            // 
            // rbOption1
            // 
            rbOption1.Location = new Point(26, 123);
            rbOption1.Margin = new Padding(5, 4, 5, 4);
            rbOption1.Name = "rbOption1";
            rbOption1.Size = new Size(666, 37);
            rbOption1.TabIndex = 2;
            rbOption1.Text = "Option 1";
            // 
            // rbOption2
            // 
            rbOption2.Location = new Point(26, 169);
            rbOption2.Margin = new Padding(5, 4, 5, 4);
            rbOption2.Name = "rbOption2";
            rbOption2.Size = new Size(666, 37);
            rbOption2.TabIndex = 3;
            rbOption2.Text = "Option 2";
            // 
            // rbOption3
            // 
            rbOption3.Location = new Point(26, 216);
            rbOption3.Margin = new Padding(5, 4, 5, 4);
            rbOption3.Name = "rbOption3";
            rbOption3.Size = new Size(666, 37);
            rbOption3.TabIndex = 4;
            rbOption3.Text = "Option 3";
            // 
            // rbOption4
            // 
            rbOption4.Location = new Point(26, 261);
            rbOption4.Margin = new Padding(5, 4, 5, 4);
            rbOption4.Name = "rbOption4";
            rbOption4.Size = new Size(666, 37);
            rbOption4.TabIndex = 5;
            rbOption4.Text = "Option 4";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(26, 323);
            btnSubmit.Margin = new Padding(5, 4, 5, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(134, 47);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Submit";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblScore
            // 
            lblScore.Location = new Point(26, 374);
            lblScore.Margin = new Padding(5, 0, 5, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(266, 31);
            lblScore.TabIndex = 7;
            lblScore.Text = "Score: 0";
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(174, 323);
            btnRestart.Margin = new Padding(5, 4, 5, 4);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(134, 47);
            btnRestart.TabIndex = 0;
            btnRestart.Text = "Play Again";
            btnRestart.Click += btnRestart_Click;
            // 
            // questionTimer
            // 
            questionTimer.Interval = 1000;
            questionTimer.Tick += question_Tick;
            // 
            // btnHint
            // 
            btnHint.Location = new Point(578, 405);
            btnHint.Margin = new Padding(3, 4, 3, 4);
            btnHint.Name = "btnHint";
            btnHint.Size = new Size(114, 40);
            btnHint.TabIndex = 8;
            btnHint.Text = "Hint (3 left)";
            btnHint.UseVisualStyleBackColor = true;
            btnHint.Click += btnHint_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 9);
            label1.Name = "label1";
            label1.Size = new Size(375, 37);
            label1.TabIndex = 9;
            label1.Text = "Super Advanced Trivia (SAT)";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(623, 13);
            btnExit.Margin = new Padding(5, 4, 5, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(69, 33);
            btnExit.TabIndex = 10;
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 461);
            Controls.Add(btnExit);
            Controls.Add(label1);
            Controls.Add(btnHint);
            Controls.Add(btnRestart);
            Controls.Add(lblQuestion);
            Controls.Add(rbOption1);
            Controls.Add(rbOption2);
            Controls.Add(rbOption3);
            Controls.Add(rbOption4);
            Controls.Add(btnSubmit);
            Controls.Add(lblScore);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(5, 4, 5, 4);
            Name = "GameForm";
            Text = "Super Advanced Trivia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbOption1;
        private System.Windows.Forms.RadioButton rbOption2;
        private System.Windows.Forms.RadioButton rbOption3;
        private System.Windows.Forms.RadioButton rbOption4;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Timer questionTimer;
        private Button btnHint;
        private Label label1;
        private Button btnExit;
    }
}
