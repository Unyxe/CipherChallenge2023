using ErikCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ErikUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
#pragma warning disable CS8603 // Possible null reference return.
        MainWindowViewModel Logic => DataContext as MainWindowViewModel;
#pragma warning restore CS8603 // Possible null reference return.
        public MainWindow()
        {
            InitializeComponent();
        }
        private TextBox[] _keyInputs;
        private void LoadKeyField()
        {
        //    var container = new StackPanel { Orientation=Orientation.Horizontal };
        //    _keyInputs = new TextBox[26];
        //    for (int i = 0; i < 26; i++)
        //    {
        //        string letter = Utilities.GetCharFromIndex(i).ToString();
        //        StackPanel subContainer = new StackPanel
        //        {
        //            Margin=new Thickness(1),
        //            Width = 22,
        //            VerticalAlignment = VerticalAlignment.Center,
        //        };
        //        TextBlock text = new TextBlock { Text = $"{i}:{letter}", HorizontalAlignment = HorizontalAlignment.Center, FontSize=9 };
        //        TextBox textBox = new TextBox
        //        {
        //            TextAlignment = TextAlignment.Center,
        //            HorizontalAlignment = HorizontalAlignment.Center,
        //            Width = 16,
        //            MaxLength = 1,
        //            Text = letter
        //        };
                


        //        _keyInputs[i] = textBox;
        //        subContainer.Children.Add(text);
        //        subContainer.Children.Add(textBox);
        //        container.Children.Add(subContainer);
        //    }

        //    spKey.Children.Add(container);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadKeyField();
        }

        private void btDecrypt_Click(object sender, RoutedEventArgs e)
        {
            char[] key = new char[26];
            Logic.Decrypt();
        }
    }
}
