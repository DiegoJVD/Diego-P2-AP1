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
using Diego_P2_AP1.UI.Registro;
using Diego_P2_AP1.UI.Consulta;

namespace Diego_P2_AP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

         public void rMenuItem_CLick(object render, RoutedEventArgs e)
        {
            rProyectos registro = new rProyectos();
            registro.Show();
        }
         public void cMenuItem_CLick(object render, RoutedEventArgs e)
        {
            cConsulta Consulta = new cConsulta();
            Consulta.Show();
        }
    }

    
}
