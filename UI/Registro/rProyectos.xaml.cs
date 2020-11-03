using System.Windows;
using System.Linq;
using System.Windows.Documents;
using System.Collections.Generic;
using System;
using Diego_P2_AP1.UI.Registro;
using Diego_P2_AP1.Entidades;
using Diego_P2_AP1.BLL;

namespace Diego_P2_AP1.UI.Registro
{
    public partial class rProyectos : Window 
    {
        Proyectos proyecto;
        public rProyectos(){
            InitializeComponent();
            proyecto = new Proyectos();
            this.DataContext = proyecto;

             TiposTareaComboBox.ItemsSource = TiposTareaBLL.GetList(p => true);
             TiposTareaComboBox.SelectedValuePath = "TipoID";
             TiposTareaComboBox.DisplayMemberPath = "Descripcion";
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
         {
            
        }

         private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            // if(!ValidarDetalle()){
            //     return;
            // }
                
                ProyectosDetalle detalle = new ProyectosDetalle(
                proyecto.ProyectoId,
                RequerimientoTextBox.Text,
                Convert.ToInt32(TiempoTextBox.Text),
                Convert.ToInt32(TiposTareaComboBox.SelectedValue.ToString())

           );

          

            proyecto.Detalle.Add(detalle);
            proyecto.Total += detalle.Tiempo;

            Actualizar();

            RequerimientoTextBox.Clear();
            TiempoTextBox.Clear();

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = proyecto.Detalle;
        }

         private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = proyecto;
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
        }
     }
}