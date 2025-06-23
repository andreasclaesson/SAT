namespace SAT
{
    public partial class GameForm : Form
    {
        // här är variabler
        private List<Question> questions;
        private int currentQuestionIndex;
        private int score;
        private int timeLeft;
        private Random random;
        private int hintsLeft = GameConfig.DefaultHints;
        private int maxQuestions;
        private int questionsAnswered;
        private int timePerQuestion;

        // konstruktorn, tar in antal frågor och tid per fråga
        public GameForm(int numberOfQuestions, int timePerQuestion)
        {
            InitializeComponent();
            this.timePerQuestion = timePerQuestion;
            maxQuestions = numberOfQuestions;
            timeLeft = timePerQuestion;

            // starta efter att ha gjort variablerna
            InitializeGame();
        }

        // starta upp själva spelet
        private void InitializeGame()
        {
            // nollställ allt
            score = 0;
            questionsAnswered = 0;
            hintsLeft = GameConfig.DefaultHints;
            btnHint.Text = $"Hint ({hintsLeft} left)";
            random = new Random();

            // ladda in frågor
            InitializeQuestions();

            // kolla så vi ens har frågor
            if (questions.Count == 0)
            {
                MessageBox.Show(GameConfig.NoQuestionsMessage, "Trivia Game");
                btnSubmit.Enabled = false;
                btnHint.Enabled = false;
                return;
            }

            // ta bara så många frågor som man ska köra
            questions = questions.Take(maxQuestions).ToList();

            // ladda första frågan
            LoadQuestion();
            UpdateScoreLabel();
            SetupTimer();
        }

        // hämta frågor från fil
        private void InitializeQuestions()
        {
            questions = QuestionLoader.LoadFromSatf(GameConfig.QuestionFilePath);
        }

        // starta timern och visa tid/poäng
        private void SetupTimer()
        {
            lblScore.Text = $"Score: {score} | Time: {timeLeft}s";
            questionTimer.Start();
        }

        // ladda en ny fråga
        private void LoadQuestion()
        {
            if (questions.Count == 0) return;

            // slumpa en fråga
            currentQuestionIndex = random.Next(questions.Count);
            var question = questions[currentQuestionIndex];

            // visa frågetext + svarsalternativ
            lblQuestion.Text = $"Question {questionsAnswered + 1} of {maxQuestions}: {question.Text}";
            rbOption1.Text = question.Options[0];
            rbOption2.Text = question.Options[1];
            rbOption3.Text = question.Options[2];
            rbOption4.Text = question.Options[3];

            // nollställ val
            rbOption1.Checked = false;
            rbOption2.Checked = false;
            rbOption3.Checked = false;
            rbOption4.Checked = false;
        }

        // tick för timern
        private void question_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblScore.Text = $"Score: {score} | Time: {timeLeft}s";

            // om tiden är slut
            if (timeLeft <= 0)
            {
                questionTimer.Stop();
                MessageBox.Show(GameConfig.TimeUpMessage, "Trivia Game");
                questions.RemoveAt(currentQuestionIndex);
                questionsAnswered++;

                // kolla om spelet ska ta slut
                if (questionsAnswered >= maxQuestions || questions.Count == 0)
                {
                    MessageBox.Show(string.Format(GameConfig.GameOverMessage, score), "Trivia Game");
                    btnSubmit.Enabled = false;
                    btnHint.Enabled = false;
                    return;
                }

                LoadQuestion();
                ResetTimer();
            }
        }

        // när man klickar på "submit"
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            questionTimer.Stop();
            var question = questions[currentQuestionIndex];
            int selectedOption = -1;

            // kolla vilket alternativ som är valt
            RadioButton[] radioButtons = { rbOption1, rbOption2, rbOption3, rbOption4 };
            if (rbOption1.Checked) selectedOption = 0;
            else if (rbOption2.Checked) selectedOption = 1;
            else if (rbOption3.Checked) selectedOption = 2;
            else if (rbOption4.Checked) selectedOption = 3;

            // inget valt
            if (selectedOption == -1)
            {
                MessageBox.Show(GameConfig.NoAnswerSelectedMessage, "Trivia Game");
                questionTimer.Start();
                return;
            }

            // visa rätt/fel färg
            radioButtons[question.CorrectAnswerIndex].BackColor = Color.LightGreen;
            if (selectedOption != question.CorrectAnswerIndex)
                radioButtons[selectedOption].BackColor = Color.Pink;

            // visa meddelande beroende på rätt/fel
            if (selectedOption == question.CorrectAnswerIndex)
            {
                score++;
                MessageBox.Show(GameConfig.CorrectAnswerMessage, "Trivia Game");
            }
            else
            {
                MessageBox.Show(string.Format(GameConfig.WrongAnswerMessage, question.Options[question.CorrectAnswerIndex]), "Trivia Game");
            }

            UpdateScoreLabel();
            questionsAnswered++;
            questions.RemoveAt(currentQuestionIndex);

            // slut på frågor eller uppnått max
            if (questionsAnswered >= maxQuestions || questions.Count == 0)
            {
                questionTimer.Stop();
                MessageBox.Show(string.Format(GameConfig.GameOverMessage, score), "Trivia Game");
                btnSubmit.Enabled = false;
                btnHint.Enabled = false;
                return;
            }

            // nollställ färger
            foreach (var rb in radioButtons)
                rb.BackColor = SystemColors.Control;

            LoadQuestion();
            ResetTimer();
        }

        // när man klickar på "restart"
        private void btnRestart_Click(object sender, EventArgs e)
        {
            InitializeGame();
            btnSubmit.Enabled = true;
            btnHint.Enabled = true;
        }

        // klickar på hint-knappen
        private void btnHint_Click(object sender, EventArgs e)
        {
            // inga hints kvar
            if (hintsLeft <= 0)
            {
                MessageBox.Show(GameConfig.NoHintsLeftMessage, "Trivia Game");
                return;
            }

            // visa hint och minska antal kvar
            var question = questions[currentQuestionIndex];
            MessageBox.Show($"Hint: {question.Hint}", "Trivia Game");
            hintsLeft--;
            btnHint.Text = $"Hint ({hintsLeft} left)";
        }

        // starta om timern för nästa fråga
        private void ResetTimer()
        {
            timeLeft = timePerQuestion;
            lblScore.Text = $"Score: {score} | Time: {timeLeft}s";
            questionTimer.Start();
        }

        // uppdatera texten längst upp
        private void UpdateScoreLabel()
        {
            lblScore.Text = $"Score: {score} | Time: {timeLeft}s";
        }

        // klicka på "exit"
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
