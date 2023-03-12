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
using System.Xml.Serialization;

namespace NenRaya
{

    public partial class Window1 : Window
    {
        public string numero;
        public string color;
        public string fondo;
        public Window1()
        {
            InitializeComponent();
            CambiarFondo();
        }

        private void Button_Click_Regresar(object sender, RoutedEventArgs e)
        {
            MainWindow regresar = new MainWindow();
            regresar.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow regresar = new MainWindow();
            regresar.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window2 juego = new Window2();
            juego.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            numero = "3";
            using (XmlWriter writer = XmlWriter.Create("numero.xml")) 
            {
                writer.WriteStartElement("root");

                writer.WriteElementString("miString", numero);

                writer.WriteEndElement();

                MessageBox.Show("Condición de victoria 3");

            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            numero = "4";
            using (XmlWriter writer = XmlWriter.Create("numero.xml"))
            {
                writer.WriteStartElement("root");

                writer.WriteElementString("miString", numero);

                writer.WriteEndElement();

                MessageBox.Show("Condición de victoria 4");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            numero = "5";
            using (XmlWriter writer = XmlWriter.Create("numero.xml"))
            {
                writer.WriteStartElement("root");

                writer.WriteElementString("miString", numero);

                writer.WriteEndElement();

                MessageBox.Show("Condición de victoria 5");
            }
        }

        private void Button_Click_RojoAmarillo(object sender, RoutedEventArgs e)
        {
            color = "1";
            using (XmlWriter writer = XmlWriter.Create("color.xml"))
            {
                writer.WriteStartElement("root");

                writer.WriteElementString("miString", color);

                writer.WriteEndElement();

                MessageBox.Show("Colores de fichas rojo y amarillo");

            }
        }

        private void Button_Click_AzulVerde(object sender, RoutedEventArgs e)
        {
            color = "2";
            using (XmlWriter writer = XmlWriter.Create("color.xml"))
            {
                writer.WriteStartElement("root");

                writer.WriteElementString("miString", color);

                writer.WriteEndElement();

                MessageBox.Show("Colores de fichas azul y verde");

            }
        }

        private void Button_Click_Fondo1(object sender, RoutedEventArgs e)
        {
            fondo = "1";
            using (XmlWriter writer = XmlWriter.Create("fondo.xml"))
            {
                writer.WriteStartElement("root");

                writer.WriteElementString("miString", fondo);

                writer.WriteEndElement();

                writer.Close();

                CambiarFondo();

                MessageBox.Show("Fondo rojo");

            }
        }

        private void Button_Click_Fondo2(object sender, RoutedEventArgs e)
        {
            fondo = "2";
            using (XmlWriter writer = XmlWriter.Create("fondo.xml"))
            {
                writer.WriteStartElement("root");

                writer.WriteElementString("miString", fondo);

                writer.WriteEndElement();

                writer.Close();

                CambiarFondo();

                MessageBox.Show("Fondo amarillo");
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

            if (fondo.Equals("1"))
            {
                this.Background = Brushes.PaleVioletRed;
            }
            else if (fondo.Equals("2"))
            {
                this.Background = Brushes.LightGoldenrodYellow;
            }
        }
    }
}
