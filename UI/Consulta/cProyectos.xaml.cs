using System;
using System.Windows;
using Diego_P2_AP1.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Diego_P2_AP1.Entidades;
using Diego_P2_AP1.BLL;

namespace Diego_P2_AP1.UI.Consulta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class cConsulta : Window
    {
        public cConsulta()
        {
            InitializeComponent();
            
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Proyectos>();
            string criterio = CriterioTextBox.Text;

            if (criterio.Length != 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        list = ProyectosBLL.GetList(p => p.ProyectoId == Convert.ToInt32(criterio));
                        break;
                    case 1:
                        list = ProyectosBLL.GetList(p => p.Descripcion.ToLower().Contains(criterio.ToLower()));
                        break;
                    case 2:
                        list = ProyectosBLL.GetList(p => p.Total == Convert.ToInt32(criterio));
                        break;

                }
            }   

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = list;
             
        } 
    }
}
