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
using System.Windows.Media.Animation;
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


    
        public MainWindow()
        {
            InitializeComponent();
            InitializeBtnArray();
            NewGame();
        }

        private void NewGame()
        {
            IsPlayerTurn = true;
        }

        private void InitializeBtnArray()
        {
            for (int i = 0; i < btns.Length; i++)
            {
                
                btns[i] = FindName($"btn{i}") as Button;
                btns[i].IsEnabled = true;
                btns[i].Background = Brushes.Tan;
                btns[i].Content = '?';

                
            }
        }
        
        char[,] lista = {{'0', '0', '0', '0'}, { '0', '0', '0', '0' }, { '0', '0', '0', '0' }, { '0', '0', '0', '0' }};
        int winx = 0;
        int wino = 0;

        private void btn_Click(object sender, RoutedEventArgs e)

        {
            var button = sender as Button;
            int x = Grid.GetRow(button);
            int y = Grid.GetColumn(button);
            button.IsEnabled = false;       
            char check = IsPlayerTurn ? 'O' : 'X';
            int wynik = 0;
            lista[x, y] = check;
            void Update(int i, int j)
            {
                if (lista[i, j] == check)
                {
                    wynik++;
                    if (wynik == 4)
                    {
                        label.Content = "wygrał: "+ check;
                        if (IsPlayerTurn)
                        {
                            winx++;
                        }
                        else
                        {
                            wino++;
                        }
                        licznik.Content = wino + ":" + winx;
                        InitializeBtnArray();
                        lista = new char[,] { { '0', '0', '0', '0'}, { '0', '0', '0', '0' }, { '0', '0', '0', '0' }, { '0', '0', '0', '0' } };
                    }
                }
            }
            button.Content = IsPlayerTurn ? 'O' : 'X';
            IsPlayerTurn = !IsPlayerTurn;
            for (int i = 0; i <= 3;i++)
            {
                wynik = 0;
                for (int j = 0; j <= 3; j++)
                {
                    Update(i, j);
                }
                wynik=0;
                for (int j = 0; j <= 3; j++)
                {
                    Update(j, j);
                }
                wynik = 0;
                for (int j = 0; j <= 3; j++)
                {
                    Update(j, i);
                }
            }
            int remis = 0;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (lista[i, j] != '0')
                    {
                        remis++;
                        if (remis == 16)
                        {
                            label.Content = "remis";
                        }
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeBtnArray();
            wino = 0;
            winx = 0;
            licznik.Content = "0:0";
            label.Content = "";
            lista = new char[,] { { '0', '0', '0', '0' }, { '0', '0', '0', '0' }, { '0', '0', '0', '0' }, { '0', '0', '0', '0' } };
        }
    }
}
