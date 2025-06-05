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
    /// Lógica de interacción para AddColeccion.xaml
    /// </summary>
    public partial class AddColeccion : Window
    {
        Usuario us;
        public AddColeccion(Usuario user)
        {
            InitializeComponent();
            us = user;
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

        private void botonCancelar_Click(object sender, RoutedEventArgs e)
        {
            volver();
        }
        /// <summary>
        /// METODO PARA INSERTAR UNA COLECCION EN LA BBDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAddColec_Click(object sender, RoutedEventArgs e)
        {
            bool existe = false;
            Coleccion colec = new Coleccion();
            List<Coleccion> lista = colec.readColeccionesUser(us);
            foreach(Coleccion c in lista)
            {
                if (c.nombre.ToLower().Equals(txtColeccion.Text.ToLower()))
                {
                    existe = true;
                }
            }
            if (!existe)
            {
                colec.setNombre(txtColeccion.Text);
                colec.setIdCreador(us.id);
                colec.insert();
                MessageBox.Show("Coleccion agregada correctamente");
                volver();
            }
            else
            {
                MessageBox.Show("Esa coleccion ya existe. Colección no creada");
                volver();
            }
        }
        /// <summary>
        /// METODO PARA VOLVER A LA PANTALLA ANTERIOR
        /// </summary>
        private void volver()
        {
            Libreria libreria = new Libreria(us);
            libreria.Show();
            this.Close();
        }
    }
}
