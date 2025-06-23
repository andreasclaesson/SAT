using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace SAT
{
    public static class QuestionLoader
    {
        // laddar frågor från en SATF-fil (super advanced trivia format)
        public static List<Question> LoadFromSatf(string path)
        {
            var questions = new List<Question>();

            // om filen inte finns, visa felmeddelande och returnera tom lista
            if (!File.Exists(path))
            {
                MessageBox.Show($"Question file not found: {path}", "Error");
                return questions;
            }

            var lines = File.ReadAllLines(path);

            // temporära variabler för varje fråga som läses in
            string questionText = null;
            var answers = new List<string>();
            int correctIndex = -1;
            string hint = null;

            // gå igenom varje rad i filen
            foreach (var line in lines)
            {
                if (line.StartsWith("#"))
                {
                    // ny fråga börjar – spara den gamla om den var giltig
                    if (questionText != null && answers.Count >= 2 && correctIndex >= 0 && correctIndex < answers.Count)
                    {
                        questions.Add(new Question(questionText, answers.ToArray(), correctIndex, hint));
                    }

                    // nollställ för nästa fråga
                    questionText = null;
                    answers.Clear();
                    correctIndex = -1;
                    hint = null;
                }
                else if (line.StartsWith("- "))
                {
                    // ett svarsalternativ
                    answers.Add(line.Substring(2).Trim());
                }
                else if (line.StartsWith("= "))
                {
                    // index för rätt svar (bör vara ett heltal)
                    int.TryParse(line.Substring(2).Trim(), out correctIndex);
                }
                else if (line.StartsWith("Hint: "))
                {
                    // hint till den här frågan
                    hint = line.Substring(6).Trim();
                }
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    // själva frågetexten
                    questionText = line.Trim();
                }
            }

            // glöm inte sista frågan om den inte avslutas med "#"
            if (questionText != null && answers.Count >= 2 && correctIndex >= 0 && correctIndex < answers.Count)
            {
                questions.Add(new Question(questionText, answers.ToArray(), correctIndex, hint));
            }

            // om vi inte lyckades ladda in något alls, säg till!
            if (questions.Count == 0)
            {
                MessageBox.Show("No valid questions found in the SATF file!", "Error");
            }

            return questions;
        }
    }
}
