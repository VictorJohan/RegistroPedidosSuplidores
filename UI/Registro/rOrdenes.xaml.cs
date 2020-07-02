using RegistroPedidosSuplidor.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroPedidosSuplidor.BLL;
using System.Text.RegularExpressions;

namespace RegistroPedidosSuplidor.UI.Registro
{
    /// <summary>
    /// Interaction logic for rOrdenes.xaml
    /// </summary>
    public partial class rOrdenes : Window
    {
        private Ordenes Orden = new Ordenes();
        public rOrdenes()
        {
            InitializeComponent();
            this.DataContext = Orden;
        }

        private void BucarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarOrdenId())
            {
                return;
            }

            Orden = OrdenesBLL.Buscar(int.Parse(OrdenIdTextBox.Text));
            Cargar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {

            var detalle = new OrdenesDetalle(int.Parse(OrdenIdDetalleTextBox.Text), int.Parse(IdTextBox.Text), 
                int.Parse(CantidadTextBox.Text), double.Parse(CostoTextBox.Text));

            Orden.OrdenesDetalles.Add(detalle);

            Cargar();

            OrdenIdDetalleTextBox.Clear();
            IdTextBox.Clear();
            CantidadTextBox.Clear();
            CostoTextBox.Clear();
            OrdenIdDetalleTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            Orden.OrdenesDetalles.RemoveAt(DetalleDataGrid.SelectedIndex);
            Cargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Limpiar()
        {
            this.Orden = new Ordenes();
            this.DataContext = Orden;
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Orden;
        }

        public bool ValidarOrdenId()
        {
            if (!OrdenesBLL.Existe(int.Parse(OrdenIdTextBox.Text)))
            {
                MessageBox.Show("Ese registro no existe.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if(!Regex.IsMatch(OrdenIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se admiten caracteres numericos.", "Campo OrdenId.", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }

       
    }   

}
