using System;
using System.IO;
using System.Windows;

namespace WordsTypingTrainer
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            Utilities.ResetValues(PlayerNameTextBox.Text);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        { 
            Environment.Exit(0);
        }

        private void PlayerNameTextBox_Initialized(object sender, EventArgs e)
        {
            PlayerNameTextBox.Text = Environment.UserName;
        }

        private void TextPresetsComboBox_Initialized(object sender, EventArgs e)
        {
            InitializeCombobox();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Utilities.PlayerName = PlayerNameTextBox.Text;
            if (Utilities.ReadTextFile(TextPresetsComboBox.SelectedItem.ToString()))
            {
                new Main().Show();
                MenuWindow.Close();
            }
            else
            {
                InitializeCombobox();
            }
        }

        private void InitializeCombobox()
        {
            foreach (string item in Utilities.FindAllTextPresets())
            {
                TextPresetsComboBox.Items.Add(item);
            }
            TextPresetsComboBox.SelectedIndex = 0;
        }
    }
}
