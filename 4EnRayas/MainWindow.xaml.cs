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

namespace _4EnRayas
{
    public partial class MainWindow : Window
    {
        private int currentPlayer = 1;
        private Button[,] buttons = new Button[6, 7];
        private int count = 4;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Button button = new Button();
                    button.Background = Brushes.LightGray;
                    button.Click += new RoutedEventHandler(Button_Click);
                    buttons[i, j] = button;
                    gameGrid.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            for (int i = 5; i >= 0; i--)
            {
                if (buttons[i, column].Background == Brushes.LightGray)
                {
                    if (currentPlayer == 1)
                    {
                        buttons[i, column].Background = Brushes.Red;
                        if (ComprobarVictoria(i, column, Brushes.Red))
                        {
                            MessageBox.Show("Jugador rojo gana");
                            ReiniciarJuego();
                        }
                        currentPlayer = 2;
                    }
                    else
                    {
                        buttons[i, column].Background = Brushes.Yellow;
                        if (ComprobarVictoria(i, column, Brushes.Yellow))
                        {
                            MessageBox.Show("Jugador amarillo gana");
                            ReiniciarJuego();
                        }
                        currentPlayer = 1;
                    }
                    break;
                }
            }
        }

        private bool ComprobarVictoria(int row, int column, Brush color)
        {
            // Horizontal check
            int auxcount = 0;
            for (int i = Math.Max(0, column - 4); i <= Math.Min(6, column + 4); i++)
            {
                if (buttons[row, i].Background == color)
                {
                    auxcount++;
                    if (auxcount == count) return true;
                }
                else
                {
                    auxcount = 0;
                }
            }

            // Vertical check
            auxcount = 0;
            for (int i = Math.Max(0, row - 4); i <= Math.Min(5, row + 4); i++)
            {
                if (buttons[i, column].Background == color)
                {
                    auxcount++;
                    if (auxcount == count) return true;
                }
                else
                {
                    auxcount = 0;
                }
            }

            // Diagonal check (top-left to bottom-right)
            auxcount = 0;
            int j = column - Math.Min(row, column);
            for (int i = Math.Max(0, row - Math.Min(row, column)); i <= Math.Min(5, row + (6 - column)); i++)
            {
                if (buttons[i, j].Background == color)
                {
                    auxcount++;
                    if (auxcount == count) return true;
                }
                else
                {
                    auxcount = 0;
                }
                j++;
            }

            // Diagonal check (bottom-left to top-right)
            auxcount = 0;
            j = column - Math.Min(5 - row, column);
            for (int i = Math.Min(5, row + Math.Min(5 - row, column)); i >= Math.Max(0, row - (6 - column)); i--)
            {
                if (buttons[i, j].Background == color)
                {
                    auxcount++;
                    if (auxcount == count) return true;
                }
                else
                {
                    auxcount = 0;
                }
                j++;
            }

            return false;
        }


        private void ReiniciarJuego()
        {
            currentPlayer = 1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    buttons[i, j].Background = Brushes.LightGray;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ReiniciarJuego();
            count = 3;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ReiniciarJuego();
            count = 4;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ReiniciarJuego();
            count = 5;
        }

    }
}







