using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PasswordGeneratorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PasswordGeneratorApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Started Password Generation");
            string genPassword = ""; 
            Random random = new Random();
            string allLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string allNumbers = "0123456789";
            string allSymbols = "!@#$%^&*?";
            int lenght = 12; 
            int Symbols = 2;
            int Numbers = 3;
            int Letters = lenght - Symbols - Numbers;
            int typeIndex;
            for (int i = 0; i < lenght; i++) 
            {
                Debug.WriteLine("Started Round  " + (i+1));
                typeIndex = random.Next(0, 3);
                if(typeIndex == 0 && Symbols > 0 ) 
                {
                    genPassword += allSymbols[random.Next(0, allSymbols.Length)];
                } else if (typeIndex == 1 && Numbers > 0)
                {
                    genPassword += allNumbers[random.Next(0, allNumbers.Length)];
                } else if (typeIndex == 2 && Letters > 0)
                {
                    genPassword += allLetters[random.Next(0, allLetters.Length)];
                }
            }
            Debug.WriteLine("Password is: " + genPassword);
            ViewModel.ChangePassword(genPassword);
        }

        private void CopyText_Click(object sender, RoutedEventArgs args)
        {
            var package = new DataPackage();
            package.SetText(ViewModel.Password);
            Clipboard.SetContent(package);
        }
    }
}
