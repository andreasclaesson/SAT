namespace SAT
{
    public partial class GameForm : Form
    {
        // h�r �r variabler
        private List<Question> questions;
        private int currentQuestionIndex;
        private int score;
        private int timeLeft;
        private Random random;
        private int hintsLeft = GameConfig.DefaultHints;
        private int maxQuestions;
        private int questionsAnswered;
        private int timePerQuestion;

        // konstruktorn, tar in antal fr�gor och tid per fr�ga
        public GameForm(int numberOfQuestions, int timePerQuestion)
        {
            InitializeComponent();
            this.timePerQuestion = timePerQuestion;
            maxQuestions = numberOfQuestions;
            timeLeft = timePerQuestion;

            // starta efter att ha gjort variablerna
            InitializeGame();
        }

        // starta upp sj�lva spelet
        private void InitializeGame()
        {
            // nollst�ll allt
            score = 0;
            questionsAnswered = 0;
            hintsLeft = GameConfig.DefaultHints;
            btnHint.Text = $"Hint ({hintsLeft} left)";
            random = new Random();

            // ladda in fr�gor
            InitializeQuestions();

            // kolla s� vi ens har fr�gor
            if (questions.Count == 0)
            {
                MessageBox.Show(GameConfig.NoQuestionsMessage, "Trivia Game");
                btnSubmit.Enabled = false;
                btnHint.Enabled = false;
                return;
            }

            // ta bara s� m�nga fr�gor som man ska k�ra
            questions = questions.Take(maxQuestions).ToList();

            // ladda f�rsta fr�gan
            LoadQuestion();
            UpdateScoreLabel();
            SetupTimer();
        }

        // h�mta fr�gor fr�n fil
        private void InitializeQuestions()
        {
            questions = QuestionLoader.LoadFromSatf(GameConfig.QuestionFilePath);
        }

        // starta timern och visa tid/po�ng
        private void SetupTimer()
        {
            lblScore.Text = $"Score: {score} | Time: {timeLeft}s";
            questionTimer.Start();
        }

        // ladda en ny fr�ga
        private void LoadQuestion()
        {
            if (questions.Count == 0) return;

            // slumpa en fr�ga
            currentQuestionIndex = random.Next(questions.Count);
            var question = questions[currentQuestionIndex];

            // visa fr�getext + svarsalternativ
            lblQuestion.Text = $"Question {questionsAnswered + 1} of {maxQuestions}: {question.Text}";
            rbOption1.Text = question.Options[0];
            rbOption2.Text = question.Options[1];
            rbOption3.Text = question.Options[2];
            rbOption4.Text = question.Options[3];

            // nollst�ll val
            rbOption1.Checked = false;
            rbOption2.Checked = false;
            rbOption3.Checked = false;
            rbOption4.Checked = false;
        }

        // tick f�r timern
        private void question_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblScore.Text = $"Score: {score} | Time: {timeLeft}s";

            // om tiden �r slut
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

        // n�r man klickar p� "submit"
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            questionTimer.Stop();
            var question = questions[currentQuestionIndex];
            int selectedOption = -1;

            // kolla vilket alternativ som �r valt
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

            // visa r�tt/fel f�rg
            radioButtons[question.CorrectAnswerIndex].BackColor = Color.LightGreen;
            if (selectedOption != question.CorrectAnswerIndex)
                radioButtons[selectedOption].BackColor = Color.Pink;

            // visa meddelande beroende p� r�tt/fel
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

            // slut p� fr�gor eller uppn�tt max
            if (questionsAnswered >= maxQuestions || questions.Count == 0)
            {
                questionTimer.Stop();
                MessageBox.Show(string.Format(GameConfig.GameOverMessage, score), "Trivia Game");
                btnSubmit.Enabled = false;
                btnHint.Enabled = false;
                return;
            }

            // nollst�ll f�rger
            foreach (var rb in radioButtons)
                rb.BackColor = SystemColors.Control;

            LoadQuestion();
            ResetTimer();
        }

        // n�r man klickar p� "restart"
        private void btnRestart_Click(object sender, EventArgs e)
        {
            InitializeGame();
            btnSubmit.Enabled = true;
            btnHint.Enabled = true;
        }

        // klickar p� hint-knappen
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

        // starta om timern f�r n�sta fr�ga
        private void ResetTimer()
        {
            timeLeft = timePerQuestion;
            lblScore.Text = $"Score: {score} | Time: {timeLeft}s";
            questionTimer.Start();
        }

        // uppdatera texten l�ngst upp
        private void UpdateScoreLabel()
        {
            lblScore.Text = $"Score: {score} | Time: {timeLeft}s";
        }

        // klicka p� "exit"
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
