using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAT
{
    public partial class GameSetupForm : Form
    {
        // variabler för hur många frågor och hur lång tid per fråga
        public int NumberOfQuestions { get; private set; }
        public int TimePerQuestion { get; private set; }

        // spara filvägen till frågedatan
        private readonly string _satfFilePath;

        // konstruktorn, tar in filvägen till SATF-filen
        public GameSetupForm(string satfFilePath)
        {
            _satfFilePath = satfFilePath;
            InitializeComponent();
            InitializeDefault(); // sätt default-värden direkt
        }

        // välj standardalternativ när fönstret öppnas
        private void InitializeDefault()
        {
            cmbQuestions.SelectedItem = "20"; // default 20 frågor
            cmbTime.SelectedItem = "15"; // default 15 sekunder per fråga
        }

        // när man klickar på startknappen
        private void btnStart_Click(object sender, EventArgs e)
        {
            // om man valt "All" i rullistan
            if (cmbQuestions.SelectedItem.ToString() == "All")
            {
                // ladda in alla frågor från filen och använd hela listan
                var questions = QuestionLoader.LoadFromSatf(_satfFilePath);
                NumberOfQuestions = questions.Count;
            }
            else
            {
                // annars, ta det man valt som antal
                NumberOfQuestions = int.Parse(cmbQuestions.SelectedItem.ToString());
            }

            // hämta tid per fråga från rullistan
            TimePerQuestion = int.Parse(cmbTime.SelectedItem.ToString());

            // säg att användaren klickade OK, så huvudformuläret vet att det ska startas
            DialogResult = DialogResult.OK;

            // stäng det här setupfönstret
            Close();
        }
    }
}
