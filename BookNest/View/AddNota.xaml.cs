using MyReads.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyReads.View
{
    /// <summary>
    /// Lógica de interacción para AddNota.xaml
    /// </summary>
    public partial class AddNota : Window
    {
        Usuario us;
        Libro lib;
        int tipo;
        Nota nt;
        Categoria c;
        String seleccionado;
        public AddNota(Usuario user, Libro libro, int tip, Nota nota)
        {
            InitializeComponent();
            us = user;
            lib = libro;
            tipo = tip;
            nt = nota;

            c = new Categoria();
            List<Categoria> listAll = new List<Categoria>();
            listAll = c.readCategoriasUsuario(us);
            //Dependiendo del int tip, hace una cosa y otra
            if (tipo == 1)
            {
                botonAddNota.Visibility = Visibility.Visible;
                labelCrear.Visibility = Visibility.Visible;
            }
            else if (tipo == 2)
            {
                Height = 750;
                botonModNota.Visibility = Visibility.Visible;
                labelModificar.Visibility = Visibility.Visible;
                panelCatActual.Visibility = Visibility.Visible;
                txtTitulo.Text = nota.titulo;
                txtContenido.Text = nota.texto;
                c = nota.readCategoria(nota);
                labelCatActual.Content = c.nombre;
            }

            foreach (Categoria categoria in listAll)
            {
                comboBoxCategorias.Items.Add(new ComboBoxItem { Content = categoria.getNombre() });
            }
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
        /// METODO PARA IR A LA VENTANA DE ADDCATEGORIA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAddCategoria_Click(object sender, RoutedEventArgs e)
        {
            AddCategoria aC = new AddCategoria(us,lib,tipo,nt);
            aC.Show();
            this.Close();
        }

        private void botonCancelar_Click(object sender, RoutedEventArgs e)
        {
            volver();
        }
        /// <summary>
        /// METODO PARA INSERTAR UNA NOTA EN LA BBDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAddNota_Click(object sender, RoutedEventArgs e)
        {
            if(seleccionado==null || seleccionado.Equals("")){
                MessageBox.Show("Tienes que seleccionar una categoria");
            }
            else
            {
                Categoria c = new Categoria();
                c = c.readByUserYNombre(us, seleccionado);
                Nota n = new Nota(txtTitulo.Text.ToString(), txtContenido.Text, DateTime.Now.ToString(), us.id, lib.idLibro, c.idCategoria);
                n.insert();
                MessageBox.Show("Nota creada con éxito");
                volver();
            }
        }
        /// <summary>
        /// METODO PARA RECOGER EL TIPO DE CATEGORIA DE UN COMBOBOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionado = ((ComboBoxItem)comboBoxCategorias.SelectedItem).Content.ToString();
        }
        /// <summary>
        /// METODO PARA VOLVER A LA PANTALLA ANTERIOR
        /// </summary>
        private void volver()
        {
            LibroInfo l = new LibroInfo(lib, us,2);
            l.Show();
            this.Close();
        }

        /// <summary>
        /// METODO PARA MODIFICAR LA NOTA, SOLO APARECE EN LA VERSIÓN 2 DE LA VENTANA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonModNota_Click(object sender, RoutedEventArgs e)
        {
            Nota nuevaNota = nt;
            nuevaNota.setTitulo(txtTitulo.Text);
            nuevaNota.setFecha(DateTime.Now.ToString());
            nuevaNota.setTexto(txtContenido.Text);
            Categoria c = new Categoria();
            c = c.readByUserYNombre(us, seleccionado);
            nuevaNota.setIdC(c.idCategoria);
            nuevaNota.modificar();
            MessageBox.Show("Se ha modificado la nota con éxito");
            volver();
        }
    }
}
