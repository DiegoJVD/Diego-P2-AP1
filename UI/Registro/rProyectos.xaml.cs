using System.Windows;
using System.Linq;
using System.Windows.Documents;
using System.Collections.Generic;
using System;
using Diego_P2_AP1.UI.Registro;
using Diego_P2_AP1.Entidades;
using Diego_P2_AP1.BLL;
using Diego_P2_AP1.DAL;


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
             TiposTareaComboBox.SelectedValuePath = "TipoId";
             TiposTareaComboBox.DisplayMemberPath = "Descripcion";
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
           Proyectos proyectos = ProyectosBLL.Buscar(Convert.ToInt32(IdTextBox.Text));

            if(proyectos != null)
            {
                proyecto = proyectos;
                Actualizar();
            }
            else
            {
                MessageBox.Show("Proyecto no encontrado.", "Error al buscar Proyecto");
            } 
        }

        private void Limpiar()
        {
            proyecto = new Proyectos();
            Actualizar();
        }

         private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            TiposTarea tiposTarea = new TiposTarea();

           tiposTarea = TiposTareaBLL.Buscar( Convert.ToInt32(TiposTareaComboBox.SelectedValue.ToString()));


            if(!ValidarDetalle()){
                return;
            }
                
                ProyectosDetalle detalle = new ProyectosDetalle(
                proyecto.ProyectoId,
                RequerimientoTextBox.Text,
                Convert.ToInt32(TiempoTextBox.Text),
                Convert.ToInt32(TiposTareaComboBox.SelectedValue.ToString()),
                tiposTarea.Descripcion
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

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = proyecto.Detalle;
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
             if(DataGrid.Items.Count > 0 && DataGrid.SelectedIndex <= DataGrid.Items.Count - 1)
            {
                ProyectosDetalle detalle = (ProyectosDetalle)DataGrid.SelectedItem;

                proyecto.Total -= detalle.Tiempo;
                proyecto.Detalle.Remove(detalle);
                
                Actualizar();
            }
          
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
             Limpiar();
        }

        // private bool ExisteDB()
        // {
        //     proyecto = ProyectosBLL.Buscar(proyecto.ProyectoId);

        //     return (proyecto != null);
        // }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            // if(!ValidarProyecto())
            //     return;

            bool paso = false;

            if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                paso = ProyectosBLL.Guardar(proyecto);

           
             else
             {
                // if(!ExisteDB())
                // {
                //     MessageBox.Show("Ya existe .", "Error  ", MessageBoxButton.OK, MessageBoxImage.Error);
                //     return;
                // }

                paso = ProyectosBLL.Modificar(proyecto);
            }

            if(paso)
            {
                Limpiar();
                MessageBox.Show("Proyecto guardado ", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Revise los datos e intente de nuevo", "Error al Guardar", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(IdTextBox.Text);

            Limpiar();

            if (ProyectosBLL.Eliminar(id))
                MessageBox.Show("Proyecto eliminado", "Registro de Proyectos", MessageBoxButton.OK, MessageBoxImage.Information);
             else
                MessageBox.Show("No se pudo eliminar la orden", "Registro de Proyeectos", MessageBoxButton.OK, MessageBoxImage.Error);
        }

         private bool ValidarDetalle()
        {
            if(!TiempoTextBox.Text.All(char.IsNumber))
            {
                MessageBox.Show("Ingrese un valor válido e intente de nuevo", "Registro de Proyectos", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if(TiposTareaComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un Tipo de tarea  e intente de nuevo", "Registro de Proyectos", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if(TiempoTextBox.Text.Length == 0){
                MessageBox.Show("Ingrese un tiempo e intente de nuevo", "Registro de Proyectos", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

             if(TiempoTextBox.Text.Length == 0){
                MessageBox.Show("Ingrese un tiempo e intente de nuevo", "Registro de Proyectos", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

             if(DescripcionTextBox.Text.Length == 0){
                MessageBox.Show("Ingrese una descripcion e intente de nuevo", "Registro de Proyectos", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if(RequerimientoTextBox.Text.Length == 0){
                MessageBox.Show("Ingrese un requerimiento e intente de nuevo", "Registro de Proyectos", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(FechaDatePicker.SelectedDate < DateTime.Today){
                MessageBox.Show("Ingrese una fecha actual o mayor e intente de nuevo", "Registro de Proyectos", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            

            return true;
        }

        private bool ValidarProyecto()
        {
            if(proyecto.Detalle.Count == 0)
            {
                MessageBox.Show("Ingrese  un proyecto e intente de nuevo", "Registro de Proyectos", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

     }
}