using System.Windows;
using System.Linq;
using System.Windows.Documents;
using System.Collections.Generic;
using System;
using Diego_P2_AP1.UI.Registro;

namespace Diego_P2_AP1.UI.Registro
{
    public partial class rRegistro : Window 
    {
        Proyectos proyecto;
        public rRegistro(){
            InitializeComponent();
            proyecto = new proyectos();
            this.dataContext = proyecto;
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
                Convert.ToInt(CantidadTextBox.Text)
           );

            proyecto.Detalle.Add(detalle);
            proyecto.Total += detalle.Tiempo;

            Actualizar();

            CostoTextBox.Clear();
            CantidadTextBox.Clear();
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