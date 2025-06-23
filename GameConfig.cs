namespace SAT
{
    public static class GameConfig
    {
        // ja du jag undrar vad detta är till för
        public const string QuestionFilePath = "questions.satf";
        public const int DefaultHints = 3;
        public const string GameOverMessage = "Game Over! Your final score is {0}.";
        public const string TimeUpMessage = "Time's up!";
        public const string NoQuestionsMessage = "No questions available. Please check the SATF file.";
        public const string NoValidQuestionsMessage = "No valid questions found in the SATF file!";
        public const string CorrectAnswerMessage = "Correct!";
        public const string WrongAnswerMessage = "Wrong! The correct answer was {0}.";
        public const string NoAnswerSelectedMessage = "Please select an answer!";
        public const string NoHintsLeftMessage = "No hints left!";
    }
}