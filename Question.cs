using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT
{
    public class Question
    {
        // om man kan engelska vet man vad man gör här
        public string Text { get; }
        public string[] Options { get; }
        public int CorrectAnswerIndex { get; }
        public string Hint { get; }

        public Question(string text, string[] options, int correctAnswerIndex, string hint = null)
        {
            Text = text;
            Options = options;
            CorrectAnswerIndex = correctAnswerIndex;

            // om det inte finns någon hint så sätter vi standardhint
            Hint = hint ?? "No hint available.";
        }
    }
}
