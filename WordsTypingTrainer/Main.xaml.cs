using System;
using System.Windows;

namespace WordsTypingTrainer
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        
        public Main()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer(System.Windows.Threading.DispatcherPriority.Send);
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
            InitializeComponent();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Utilities.ElapsedTime += TimeSpan.FromMilliseconds(100);
            TimerLabel.Content = (Utilities._defaultTimerInterval - Utilities.ElapsedTime).TotalSeconds + " sec";
            if (Utilities.ElapsedTime == Utilities._defaultTimerInterval)
            {
                dispatcherTimer.Stop();
                new Results().Show();
                MainWindow.Close();
            }
        }

        private void TextToTypeLabel_Initialized(object sender, EventArgs e)
        {
            TextToTypeLabel.Content = Utilities.TextToType;
        }

        private void TimerLabel_Initialized(object sender, EventArgs e)
        {
            TimerLabel.Content = Utilities._defaultTimerInterval.TotalSeconds + " sec";
        }        

        private void MainWindow_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            
            if (!dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Start();
                StartHintLabel.Visibility = Visibility.Hidden;
            }

            char firstChar = TextToTypeLabel.Content.ToString()[0];
            if (e.Text[0] == firstChar)
            {
                Utilities.TypedChars += 1;
                TotalTypedLabel.Content = Utilities.TypedChars + "chars";
            }
            else
            {
                Utilities.Errors += 1;
                TotalMissedLabel.Content = Utilities.Errors + "chars";
            }

            if (TextToTypeLabel.Content.ToString().Length > 1)
            {
                TextToTypeLabel.Content = TextToTypeLabel.Content.ToString().Substring(1);
            }
            else
            {
                dispatcherTimer.Stop();
                new Results().Show();
                MainWindow.Close();
            }
            
        }
    }
}