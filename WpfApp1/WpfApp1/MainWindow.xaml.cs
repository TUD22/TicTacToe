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

        private Button[] btns = new Button[16];
        private bool IsPlayerTurn { get; set; }


        private int Counter { get; set; }
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
        char[,] lista = { {'0', '0', '0', '0'}, { '0', '0', '0', '0' }, { '0', '0', '0', '0' }, { '0', '0', '0', '0' }};
        private void btn_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            int x = Grid.GetRow(button);
            int y = Grid.GetColumn(button);
            button.IsEnabled = false;
            //label = FindName("label") as Label;
            char check = IsPlayerTurn ? 'o' : 'x';
            lista[x, y] = check;
            for (int i = 0; i <= 3;i++)
            {
                int wynik = 0;
                for (int j = 0; j <= 3; j++)
                {
                    if (lista[i, j] ==check)
                    {
                        wynik ++;
                        if (wynik == 4)
                        {
                      
                           // label.Content = "wygrał "+ check;
                         
                            break;
                        }
                    }
                }
                wynik = 0;
                for (int j = 0; j <= 3; j++)
                {
                    if (lista[j, i] == check)
                    {
                        wynik++;
                        if (wynik == 4)
                        {
                            //label.Content = "wygrał " + check;
                            break;
                        }
                    }
                    
                }
                wynik = 0;
                for (int j = 0; j <= 3; j++)
                {
                    if (lista[j, j] == check)
                    {
                        wynik++;
                        if (wynik == 4)
                        {
                           // label.Content = "wygrał " + check;
                            break;
                        }
                    }
                    
                }
            }
            
            button.Content = IsPlayerTurn ? 'O' : 'X';
            IsPlayerTurn = !IsPlayerTurn;
        }
    }
}
