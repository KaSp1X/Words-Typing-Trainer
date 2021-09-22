using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace WordsTypingTrainer
{
    static class Utilities
    {
        private readonly static string _presetsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Words Typing Trainer\\";
        internal static string TextToType { get; private set; }
        
        internal readonly static TimeSpan _defaultTimerInterval = new TimeSpan(0,0,10);
        internal static TimeSpan ElapsedTime { get; set; }

        internal static string PlayerName { get; set; }
        internal static int Errors { get; set; }
        internal static int TypedChars { get; set; }


        internal static List<string> FindAllTextPresets()
        {
            var defaultFiles = Directory.GetFiles(Environment.CurrentDirectory + @"\Data\TextPresets", "*.txt");
            if (!Directory.Exists(_presetsFolderPath) || Directory.GetFiles(_presetsFolderPath, "*.txt").Length == 0)
            {
                foreach(var file in defaultFiles)
                {
                    File.Copy(file, Path.Combine(_presetsFolderPath,Path.GetFileName(file)), true);
                }
                
            }
            return Directory.GetFiles(_presetsFolderPath, "*.txt").Select(i => Path.GetFileNameWithoutExtension(i)).ToList();
        }
        
        internal static bool ReadTextFile(string fileName)
        {
            string fullPathFile = Path.Combine(_presetsFolderPath, fileName + ".txt");
            if (!File.Exists(fullPathFile))
            {
                MessageBox.Show("Can't access to this file!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                string text = File.ReadAllText(fullPathFile).Replace("\n", "").Replace("\r", "");
                if (String.IsNullOrWhiteSpace(text))
                {
                    MessageBox.Show("Text file is empty or only with white-spaces!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    TextToType = text;
                    return true;
                }
            }
        }

        internal static void ResetValues(string defaultPlayerName = "Player")
        {
            Errors = 0;
            TypedChars = 0;
            ElapsedTime = new TimeSpan(0,0,0);
            PlayerName = defaultPlayerName;
            TextToType = "";
        }
    }
}
