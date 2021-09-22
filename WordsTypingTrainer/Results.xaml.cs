using System;
using System.Windows;

namespace WordsTypingTrainer
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        public Results()
        {
            InitializeComponent();
        }

        private void ToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            ResultsWindow.Close();
        }

        private void CongratsLabel_Initialized(object sender, EventArgs e)
        {
            CongratsLabel.Content = $"Congratulations, {Utilities.PlayerName}!";
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TotalTypedLabel_Initialized(object sender, EventArgs e)
        {
            TotalTypedLabel.Content = Utilities.TypedChars + " chars";
        }

        private void TotalMissedLabel_Initialized(object sender, EventArgs e)
        {
            TotalMissedLabel.Content = Utilities.Errors + " chars";
        }

        private void TypingSpeedLabel_Initialized(object sender, EventArgs e)
        {
            TypingSpeedLabel.Content = Math.Round(Utilities.TypedChars / Utilities.ElapsedTime.TotalSeconds, 2) + " CPS";
        }
    }
}
