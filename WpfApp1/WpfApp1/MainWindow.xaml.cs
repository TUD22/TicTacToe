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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        private Button[] btns = new Button[9];
        private bool IsPlayerTurn { get; set; }


        private int Counter {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializeBtnArray();
            NewGame();
        }

        private void NewGame()
        {
            IsPlayerTurn = true;
            Counter = 0;
        }

        private void InitializeBtnArray()
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i] = FindName($"btn{i}") as Button;
                btns[i].Background = Brushes.Tan;
                btns[i].Content = '?';
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
          
            button.Background = IsPlayerTurn ? Brushes.DeepSkyBlue : Brushes.Firebrick;
            button.IsEnabled = false;

            button.Content = IsPlayerTurn ? 'O' : 'X';
            IsPlayerTurn = !IsPlayerTurn;
        }
    }
}
