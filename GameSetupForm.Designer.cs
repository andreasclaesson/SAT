namespace SAT
{
    partial class GameSetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblQuestions = new Label();
            lblTime = new Label();
            cmbQuestions = new ComboBox();
            cmbTime = new ComboBox();
            btnStart = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblQuestions
            // 
            lblQuestions.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblQuestions.Location = new Point(15, 93);
            lblQuestions.Margin = new Padding(5, 0, 5, 0);
            lblQuestions.Name = "lblQuestions";
            lblQuestions.Size = new Size(286, 31);
            lblQuestions.TabIndex = 0;
            lblQuestions.Text = "Number of Questions:";
            // 
            // lblTime
            // 
            lblTime.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTime.Location = new Point(15, 143);
            lblTime.Margin = new Padding(5, 0, 5, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(286, 31);
            lblTime.TabIndex = 1;
            lblTime.Text = "Time per Question (seconds):";
            // 
            // cmbQuestions
            // 
            cmbQuestions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQuestions.Font = new Font("Arial", 10F);
            cmbQuestions.Items.AddRange(new object[] { "5", "10", "15", "20", "All" });
            cmbQuestions.Location = new Point(338, 92);
            cmbQuestions.Margin = new Padding(5, 4, 5, 4);
            cmbQuestions.Name = "cmbQuestions";
            cmbQuestions.Size = new Size(114, 27);
            cmbQuestions.TabIndex = 2;
            // 
            // cmbTime
            // 
            cmbTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTime.Font = new Font("Arial", 10F);
            cmbTime.Items.AddRange(new object[] { "10", "15", "20", "30" });
            cmbTime.Location = new Point(339, 141);
            cmbTime.Margin = new Padding(5, 4, 5, 4);
            cmbTime.Name = "cmbTime";
            cmbTime.Size = new Size(114, 27);
            cmbTime.TabIndex = 3;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Arial", 10F);
            btnStart.Location = new Point(15, 188);
            btnStart.Margin = new Padding(5, 4, 5, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(439, 47);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start Game";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(375, 37);
            label1.TabIndex = 4;
            label1.Text = "Super Advanced Trivia (SAT)";
            // 
            // GameSetupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 252);
            Controls.Add(label1);
            Controls.Add(lblQuestions);
            Controls.Add(lblTime);
            Controls.Add(cmbQuestions);
            Controls.Add(cmbTime);
            Controls.Add(btnStart);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(5, 4, 5, 4);
            Name = "GameSetupForm";
            Text = "Super Advanced Trivia (Setup)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbQuestions;
        private ComboBox cmbTime;
        private Label lblQuestions;
        private Label lblTime;
        private Button btnStart;
        private Label label1;
    }
}