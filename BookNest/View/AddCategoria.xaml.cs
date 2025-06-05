using MyReads.Domain;
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

namespace MyReads.View
{
    /// <summary>
    /// Lógica de interacción para AddCategoria.xaml
    /// </summary>
    public partial class AddCategoria : Window
    {
        Usuario us;
        Libro lib;
        int tipo;
        Nota nt;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Usuario que ha iniciado sesión</param>
        /// <param name="libro">Libro al que se añade una nota</param>
        /// <param name="tipo">Referente a AddNota, dejar el que está. 1= Crear Nota, 2=Modificar Nota</param>
        /// <param name="nt">Nota a la que volver una vez se cierre la ventana</param>
        public AddCategoria(Usuario user, Libro libro, int tipo, Nota nt)
        {
            InitializeComponent();
            us = user;
            lib = libro;
            this.tipo = tipo;
            this.nt = nt;
        }
        //METODOS GENERALES
        /// <summary>
        /// METODO PARA MOVER LA PANTALLA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        /// <summary>
        /// METODO PARA VOLVER A LA PANTALLA ANTERIOR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCancelar_Click(object sender, RoutedEventArgs e)
        {
            volver();
        }
        /// <summary>
        /// METODO PARA INSERTAR UNA CATEGORIA EN LA BBDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAddCategoria_Click(object sender, RoutedEventArgs e)
        {
            bool existe = false;
            Categoria cat= new Categoria();
            List<Categoria> lista = cat.readCategoriasUsuario(us);
            foreach (Categoria c in lista)
            {
                if (c.nombre.ToLower().Equals(txtNombre.Text.ToLower()))
                {
                    existe = true;
                }
            }
            if (!existe)
            { 
                cat.setNombre(txtNombre.Text.ToString());
                cat.setDesc(txtContenido.Text.ToString());
                cat.setIdUsuario(us.id);
                cat.insert();
                MessageBox.Show("Categoría creada correctamente");
                AddNota aN= new AddNota(us, lib,tipo,nt);
                aN.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Esa categoría ya existe. Categoria no creada");
                volver();
            }
        }
        private void volver()
        {
            AddNota aN= new AddNota(us,lib,tipo,nt);
            aN.Show();
            this.Close();
        }
    }
}
