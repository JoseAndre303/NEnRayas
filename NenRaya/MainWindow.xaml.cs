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
using System.Xml;

namespace NenRaya
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string fondo;

        public MainWindow()
        {
            InitializeComponent();
            CambiarFondo();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window2 juego = new Window2();
            juego.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Window1 opciones = new Window1();
            opciones.Show();
            this.Close();
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
            if (fondo.Equals("1"))
            {
                this.Background = Brushes.DarkRed;

                StackPanel miStackPanel = this.FindName("stackpanel") as StackPanel;
                SolidColorBrush colorFondo = new SolidColorBrush(Colors.PaleVioletRed);
                miStackPanel.Background = colorFondo;


            }
            else if (fondo.Equals("2"))
            {
                this.Background = Brushes.Yellow;

                StackPanel miStackPanel = this.FindName("stackpanel") as StackPanel;
                SolidColorBrush colorFondo = new SolidColorBrush(Colors.LightGoldenrodYellow);
                miStackPanel.Background = colorFondo;
            }
        }
    }
}
