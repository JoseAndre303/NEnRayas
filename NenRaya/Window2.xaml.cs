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
using System.Windows.Shapes;
using System.Xml;

namespace NenRaya
{

    public partial class Window2 : Window
    {
        public string numero;
        public string color;
        public string fondo;
     
        private int currentPlayer = 1;
        private Button[,] buttons = new Button[6, 7];
        private int count = 4;

        public Window2()
        {
            InitializeComponent();
            InitializeBoard();
            CambiarFondo();

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
            CambiarVictoria();
            CambiarColores();
            

            if (color.Equals("1")) { 
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
            } else if (color.Equals("2"))
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
                            buttons[i, column].Background = Brushes.Aqua;
                            if (ComprobarVictoria(i, column, Brushes.Aqua))
                            {
                                MessageBox.Show("Jugador Azul gana");
                                ReiniciarJuego();
                            }
                            currentPlayer = 2;
                        }
                        else
                        {
                            buttons[i, column].Background = Brushes.GreenYellow;
                            if (ComprobarVictoria(i, column, Brushes.GreenYellow))
                            {
                                MessageBox.Show("Jugador Verde gana");
                                ReiniciarJuego();
                            }
                            currentPlayer = 1;
                        }
                        break;
                    }
                }
            }
        }

        private bool ComprobarVictoria(int row, int column, Brush color)
        {
            // check Horizontal
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

            // check Vertical 
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

            // check Diagonal 
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

            // 2 check Diagonal 
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
        private void CambiarColores()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("color.xml");

            XmlNode colorNode = xmlDocument.SelectSingleNode("/root/miString");
            color = colorNode.InnerText;

            if (color == null)
            {
                color = "1";

            }
        }

        private void CambiarFondo()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("fondo.xml");

            XmlNode fondoNode = xmlDocument.SelectSingleNode("/root/miString");
            fondo = fondoNode.InnerText;

            if (fondo == null)
            {
                fondo = "1";
            }

            if (fondo.Equals("1")) {
                this.Background = Brushes.PaleVioletRed;
            } else if (fondo.Equals("2"))
            {
                this.Background = Brushes.LightGoldenrodYellow;
            }
        }

        private void CambiarVictoria()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("numero.xml");

            XmlNode numeroNode = xmlDocument.SelectSingleNode("/root/miString");
            string strNumero = numeroNode.InnerText;
            count = int.Parse(strNumero);

            if (count == null)
            {
                count = 4;

            }
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
            
            numero = "3";
            using (XmlWriter writer = XmlWriter.Create("numero.xml"))
            {
                writer.WriteStartElement("root");

                writer.WriteElementString("miString", numero);

                writer.WriteEndElement();

                MessageBox.Show("Condición de victoria 3");
            }
            ReiniciarJuego();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            numero = "4";
            using (XmlWriter writer = XmlWriter.Create("numero.xml"))
            {
                writer.WriteStartElement("root");

                writer.WriteElementString("miString", numero);

                writer.WriteEndElement();

                MessageBox.Show("Condición de victoria 4");

            }
            ReiniciarJuego();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            numero = "5";
            using (XmlWriter writer = XmlWriter.Create("numero.xml"))
            {
                writer.WriteStartElement("root");

                writer.WriteElementString("miString", numero);

                writer.WriteEndElement();

                MessageBox.Show("Condición de victoria 5");
            }
            ReiniciarJuego();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow regresar = new MainWindow();
            regresar.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Window1 opciones = new Window1();
            opciones.Show();
            this.Close();
        }
    }
}
