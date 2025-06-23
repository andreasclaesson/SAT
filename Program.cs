namespace SAT { 
    static class Program { 

        [STAThread] 
        static void Main() { 
            Application.EnableVisualStyles(); 
            Application.SetCompatibleTextRenderingDefault(false);
            var setupForm = new GameSetupForm("questions.satf"); 
            if (setupForm.ShowDialog() == DialogResult.OK) 
            { Application.Run(new GameForm(setupForm.NumberOfQuestions, setupForm.TimePerQuestion)); } 
        } 
    } 
}