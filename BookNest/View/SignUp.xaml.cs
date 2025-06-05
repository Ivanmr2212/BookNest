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
    /// Lógica de interacción para SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BotonMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void checkBoxMostrar_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                txtVerPassSign.Text = txtPassSign.Password;
                txtVerPassSign.Visibility = Visibility.Visible;
                txtPassSign.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPassSign.Password = txtVerPassSign.Text;
                txtVerPassSign.Visibility = Visibility.Collapsed;
                txtPassSign.Visibility = Visibility.Visible;
            }
        }

        private void botonCancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void botonRegistrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (comprobarUsuario())
            {
                MessageBox.Show("Ha habido un error");
            }
            else
            {
                String nombre = txtUsuarioSign.Text;
                String correo = txtCorreoSign.Text;
                String pass = txtPassSign.Password;
                Usuario usuario = new Usuario(nombre, correo, pass);
                usuario.setImg("perfil_defecto.png");
                usuario.insert();
                Usuario u=usuario.readByNombre(nombre);
                MessageBox.Show(u.id.ToString());

                //Insertar colecciones default, las saca de la base de datos del usuario Admin
                Usuario userAdmin = new Usuario();
                userAdmin = userAdmin.readByNombre("Admin");
                Coleccion coleccion1 = new Coleccion();
                 List<Coleccion> coleccionesDefault = coleccion1.readColeccionesUser(userAdmin);
                foreach(Coleccion c in coleccionesDefault)
                {
                    c.setIdCreador(u.id);
                    c.insert();
                }
                //Insertar categorias default, las saca de la base de datos del usuario Admin
                Categoria c1 = new Categoria();
                List<Categoria> categoriasDefault = c1.readCategoriasUsuario(userAdmin);
                foreach (Categoria c in categoriasDefault)
                {
                    c.setIdUsuario(u.id);
                    MessageBox.Show(c.ToString());
                    c.insert();
                }
                MessageBox.Show("Usuario registrado");
            }
            txtUsuarioSign.Text = null;
            txtCorreoSign.Text = null;
            txtPassSign.Password = null;
            txtVerPassSign.Text = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private bool comprobarUsuario()
        {
            bool existeUser = false;
            bool existeCorreo = false;
            bool existe = false;

            String correo = txtCorreoSign.Text;
            String user = txtUsuarioSign.Text;

            Usuario u = new Usuario(null, null, null);

            Usuario usuarioPorCorreo = u.readByCorreo(correo);
            if (usuarioPorCorreo != null && usuarioPorCorreo.correo != null && usuarioPorCorreo.correo != "")
            {
                existeCorreo = true;
                MessageBox.Show("Correo existe");
            }
            else
            {
                MessageBox.Show("Correo no existe");
            }

            Usuario usuarioPorNombre = u.readByNombre(user);
            if (usuarioPorNombre != null && usuarioPorNombre.nombre != null && usuarioPorNombre.nombre != "")
            {
                existeUser = true;
                MessageBox.Show("Usuario existe");
            }
            else
            {
                MessageBox.Show("Usuario no existe");
            }

            if (existeUser || existeCorreo)
            {
                existe = true;
            }

            return existe;
        }
    }
}
