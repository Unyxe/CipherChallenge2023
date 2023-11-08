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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Logic.OnLoad();
        }

        private void btDecrypt_Click(object sender, RoutedEventArgs e)
        {
            Logic.Decrypt();
            lvFreqAnalysis.Items.Refresh();
        }

        private void btGenKey_Click(object sender, RoutedEventArgs e)
        {
            Logic.GenKey();
        }

        private void btResetKey_Click(object sender, RoutedEventArgs e) => Logic.ResetKey();
    }
}
