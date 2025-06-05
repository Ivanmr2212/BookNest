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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyReads.View
{
    /// <summary>
    /// Lógica de interacción para LibroInfo.xaml
    /// </summary>
    public partial class LibroInfo : Window
    {
        Libro l;
        Usuario us;
        int tipo = -1;
        String nombreColeccion;
        Coleccion c = new Coleccion();
        Nota nt = new Nota();
        List<Coleccion> listColecUser = new List<Coleccion>();
        List<Coleccion> listColecUserYNombre = new List<Coleccion>();
        List<Coleccion> listFiltradoColec = new List<Coleccion>();
        List<Nota> listNotas = new List<Nota>();
        bool coleccionSelec = false;
        /// <summary>
        /// Constructor de la ventana
        /// </summary>
        /// <param name="libro">Libro de la que se va a ver la informacion</param>
        /// <param name="user">Usuario</param>
        /// <param name="info">Tipo de ventana generada 1/2. 1.Búsqueda, 2. Para cuando se haya añadido el libro a una colección</param>
        public LibroInfo(Libro libro, Usuario user, int info)
        {
            InitializeComponent();
            us = user;
            l = libro;
            tipo = info;

            labelTitulo.Content = l.titulo.ToUpper();
            labelAutor.Content = l.autor;
            labelEd.Content = l.editorial;
            labelPags.Content = l.numPags;
            labelYear.Content = l.year;
            textSinopsis.Text = l.sinopsis;

            string ruta = "pack://application:,,,/Images/portadas/" + libro.img;
            portada.Source = new BitmapImage(new Uri(ruta, UriKind.Absolute)); //Para generar la portada del libro, se saca de la bbdd

            //En base a en que momento se abre esta ventana se generan unos elementos u otros
            if (info == 1)
            {
                listColecUser = c.readColeccionesUser(us);
                generarColecciones(listColecUser, panelColecciones);
                version1();
            }
            else
            {
                this.Height = 750;
                listColecUser = c.readColeccionesUserNoTodos(us);
                generarColecciones(listColecUser, panelColecciones2);

                listNotas = nt.readNotasUsuarioYLibro(us, l);
                panelNotas.Children.Clear();
                generarNotas(listNotas, panelNotas);
                
                version2();
            }
            

        }

        /// <summary>
        /// METODO PARA MOVER LA VENTANA
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
        /// METODO PARA CERRAR LA APLICACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// METODO PARA MINIMIZAR LA APLICACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        /// <summary>
        /// METODO PARA VOLVER A LA PANTALLA ANTERIOR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (tipo != 3)
            {
                Busqueda busqueda = new Busqueda(us);
                busqueda.Show();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        /// <summary>
        /// METODO PARA AÑADIR EL LIBRO A UNA COLECCION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAdd_Click(object sender, RoutedEventArgs e)
        {
            bool insertable = true;
            //Se comprueba si el metodo de registro está hecho y si se ha hecho click en alguna coleccion
            if (radioButtonCap.IsChecked == false && radioButtonPag.IsChecked == false && radioButtonPor.IsChecked == false)
            {
                MessageBox.Show("Tienes que seleccionar un método de registro");
                insertable = false;
            }
            if (coleccionSelec == false)
            {
                MessageBox.Show("Tienes que seleccionar una colección donde guardar el libro");
                insertable = false;
            }
            if (insertable)
            {
                bool existe = false;
                Coleccion coleccion = new Coleccion();
                coleccion = coleccion.readColeccionesUserYNombre(us, nombreColeccion); //Para seleccionar la coleccion donde el usuario quiere guardar el libro
                Coleccion coleccionTotal = coleccion.readColeccionesUserYNombre(us, "Todos"); //Para guardar el libro en la coleccion "Todos"
                existe = comprobarLibroExiste(l, coleccion);
                if (existe)
                {
                    MessageBox.Show("Este libro ya está en la colección "+coleccion.nombre);
                    nombreColeccion = null;
;                    coleccionSelec = false;
                }
                else
                {
                    l.insertarLibroEnColeccion(l, coleccion);
                    Reto r = new Reto();
                    r = r.readNoComp(us);
                    if (coleccion.nombre == "Leido" && r!=null)
                    {
                        sumarLibroReto(us);
                    }
                    existe = comprobarLibroExiste(l, coleccionTotal);
                    if (!existe)
                    {
                        //Si el libro ya existía de antes te lo inserta solo en la coleccion que le has dicho, si no lo inserta tambien en "Todos"
                        l.insertarLibroEnColeccion(l, coleccionTotal);
                    }
                    MessageBox.Show("Libro añadido correctamente");
                    if (nombreColeccion == "Leido")
                    {
                        hacerReseña();
                    }
                }
                if (tipo != 3)
                {
                    Busqueda busqueda = new Busqueda(us);
                    busqueda.Show();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void sumarLibroReto(Usuario user)
        {
            Reto r= new Reto();
            r = r.readNoComp(user);
            r.leido++;
            r.sumar1Leido();
            MessageBox.Show("Se ha sumado uno al reto actual");
            if (r.leido >= r.total)
            {
                r.completado = true;
                r.actualizarComp();
                MessageBox.Show("Has completado el reto, enhorabuena");
            }
        }

        /// <summary>
        /// METODO QUE COMPRUEBA SI UN LIBRO YA EXISTE EN UNA COLECICON
        /// </summary>
        /// <param name="libro">LIBRO QUE SE QUIERE AÑADIR</param>
        /// <param name="coleccion">COLECCION EN LA QUE VER SI YA ESTÁ</param>
        /// <returns></returns>
        public bool comprobarLibroExiste(Libro libro, Coleccion coleccion)
        {
            bool existe = false;
            List<Libro> librosColeccion = l.leerLibrosColeccion(coleccion);
            foreach (Libro libro2 in librosColeccion)
            {
                if (libro2.idLibro == l.idLibro)
                {
                    existe = true;
                }
            }
            return existe;
        }
        /// <summary>
        /// METODO QUE GENERA LAS COLECCIONES DISPONIBLES PARA GUARDAR LIBROS
        /// </summary>
        /// <param name="lista">LISTA QUE CONTIENE LAS COLECCIONES A GENERAR</param>
        /// <param name="panel">PANEL DONDE SE GENERAN</param>
        private void generarColecciones(List<Coleccion> lista, StackPanel panel)
        {
            panel.Children.Clear(); // Limpia los elementos previos

            int cont = 0;
            foreach (Coleccion coleccion in lista)
            {
                Color color = (cont % 2 == 0)
                    ? (Color)ColorConverter.ConvertFromString("#FFB8A36D")
                    : (Color)ColorConverter.ConvertFromString("#FFD6C37D");
                cont++;

                Button boton = new Button
                {
                    Background = new SolidColorBrush(color),
                    Content = coleccion.nombre,
                    Margin = new Thickness(0, 0, 0, 10), // Espacio entre botones
                    FontSize = 16,
                    FontStyle = FontStyles.Italic,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Width = 350, // Ancho ajustado al ScrollViewer
                    Height = 30  // Tamaño fijo
                };

                boton.Click += elegirColeccion;
                panel.Children.Add(boton);
            }
        }
        /// <summary>
        /// METODO PARA SABER EN QUE COLECCION SE HA HECHO CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elegirColeccion(object sender, RoutedEventArgs e)
        {
            nombreColeccion = (sender as Button).Content.ToString();
            MessageBox.Show("Has elegido la colección: " + nombreColeccion);
            coleccionSelec = true;
        }
        /// <summary>
        /// VERSIÓN 1 DE LA VENTANA. MOMENTO DONDE SELECCIONAS UN LIBRO DESDE LA VENTANA DE BÚSQUEDA
        /// </summary>
        private void version1()
        {
            this.Height = 650;
            #region Filas
            //Se ajusta el tamaño de las filas según me conviene
            gridPrincipal.RowDefinitions[0].Height = new GridLength(0.7, GridUnitType.Star);
            gridPrincipal.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
            gridPrincipal.RowDefinitions[2].Height = new GridLength(1.5, GridUnitType.Star);
            gridPrincipal.RowDefinitions[3].Height = new GridLength(1.5, GridUnitType.Star);
            gridPrincipal.RowDefinitions[4].Height = new GridLength(0.6, GridUnitType.Star);
            gridPrincipal.RowDefinitions[5].Height = new GridLength(0.5, GridUnitType.Star);
            #endregion
            //Los paneles de su respectiva version se hacen visibles
            panelV1Coleccion.Visibility = Visibility.Visible;
            panelV1Registro.Visibility = Visibility.Visible;
            panelV1Botones.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// VERSION 2 DE LA VENTANA. MOMENTO DONDE SELECCIONAS UN LIBRO DESDE LA VENTANA DE LIBRERÍA
        /// </summary>
        private void version2()
        {
            this.Height = 750;
            #region Filas
            //Se ajusta el tamaño de las filas según me conviene
            gridPrincipal.RowDefinitions[0].Height = new GridLength(0.7, GridUnitType.Star);
            gridPrincipal.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
            gridPrincipal.RowDefinitions[2].Height = new GridLength(1.5, GridUnitType.Star);
            gridPrincipal.RowDefinitions[3].Height = new GridLength(1.5, GridUnitType.Star);
            gridPrincipal.RowDefinitions[4].Height = new GridLength(1.2, GridUnitType.Star);
            gridPrincipal.RowDefinitions[5].Height = new GridLength(0.5, GridUnitType.Star);
            #endregion
            //Los paneles de su respectiva version se hacen visibles
            panelV2Coleccion.Visibility = Visibility.Visible;
            radioCortar.Visibility = Visibility.Visible;
            panelV2Notas.Visibility = Visibility.Visible;
            panelV2Botones.Visibility = Visibility.Visible;
        }


        //METODOS VERSION 2
        /// <summary>
        /// METODO PARA VOLVER A LA VENTANA DE LA LIBRERIA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonVolver_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == 2)
            {
                Libreria libreria = new Libreria(us);
                libreria.Show();
                this.Close();
            }else if (tipo == 3)
            {
                
                this.Close();
            }
            if (tipo == 3)
            {
                this.Close();
            }
        }
        //COLECCIONES
        /// <summary>
        /// METODO QUE COPIA O CORTA UNA COLECCION A OTRA EN BASE AL RADIO BUTTON MARCADO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCambiarColeccion_Click(object sender, RoutedEventArgs e)
        {
            if ((radioCopiar.IsChecked == false || radioCortar.IsChecked == false) && nombreColeccion == null)
            {
                MessageBox.Show("Hay que seleccionar una coleccion y marcar uno de los botones copiar/cortar");
            }
            else
            {
                if (radioCopiar.IsChecked == true)
                {
                    //Lo copia directamente a otra coleccion sin borrar nada
                    Coleccion coleccion = c.readColeccionesUserYNombre(us, nombreColeccion);
                    l.insertarLibroEnColeccion(l, coleccion);
                    Reto r = new Reto();
                    r = r.readNoComp(us);
                    if (coleccion.nombre == "Leido" && r != null)
                    {
                        sumarLibroReto(us);
                    }
                    MessageBox.Show("Se ha copiado el libro en la coleccion " + coleccion.nombre);
                }
                else if (radioCortar.IsChecked == true)
                {
                    //Borra el libro de todas las colecciones en las que está y luego lo pega en la que ha indicado el usuario
                    List<Coleccion> lista = c.readColeccionesUser(us);
                    foreach (Coleccion colec in lista)
                    {
                        if (colec.nombre != "Todos")
                        {
                            l.deleteLibroColeccion(l, colec);
                        }
                    }
                    Coleccion coleccion = c.readColeccionesUserYNombre(us, nombreColeccion);
                    l.insertarLibroEnColeccion(l, coleccion);
                    Reto r = new Reto();
                    r = r.readNoComp(us);
                    if (coleccion.nombre == "Leido" && r != null)
                    {
                        sumarLibroReto(us);
                    }
                    MessageBox.Show("Se ha cortado el libro a la coleccion " + coleccion.nombre);
                }
                if (nombreColeccion == "Leido")
                {
                    hacerReseña();
                }
            }
            if (tipo == 3)
            {
                this.Close();
            }
            else
            {
                Libreria libreria = new Libreria(us);
                libreria.Show();
                this.Close();
            }
        }

        //NOTAS
        /// <summary>
        /// METODO QUE TE LLEVA A UNA VENTANA PARA INSERTAR UNA NOTA EN LA BBDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAddNota_Click(object sender, RoutedEventArgs e)
        {
            AddNota aN = new AddNota(us, l,1, null);
            aN.Show();
            this.Close();
        }
        private void verNota(Usuario us, Nota n)
        {
            AddNota aN = new AddNota(us, l, 2, n);
            aN.Show();
            this.Close();
        }
        /// <summary>
        /// METODO QUE ELIMINA UNA NOTA DE LA BBDD
        /// </summary>
        /// <param name="n"></param>
        private void eliminarNota(Nota n)
        {
            n.delete();
            MessageBox.Show("Nota eliminada");
            //Una vez borrada la nota, se actualiza el panel
            listNotas = nt.readNotasUsuarioYLibro(us, l);
            panelNotas.Children.Clear();
            generarNotas(listNotas, panelNotas);
        }
        /// <summary>
        /// METODO QUE GENERA UNA LISTA DE NOTAS EN EL STACK PANEL QUE SE LE HAYA PASADO
        /// </summary>
        /// <param name="lista">NOTAS A GENERAR</param>
        /// <param name="panel">STACK PANEL DONDE GENERARLAS</param>
        private void generarNotas(List<Nota> lista, StackPanel panel)
        {
            foreach (Nota nota in lista)
            {

                TextBlock texto = new TextBlock
                {
                    Text = nota.titulo,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(5)
                };

                Button boton = new Button
                {
                    Background = Brushes.WhiteSmoke,
                    Content = texto,
                    Margin = new Thickness(10, 0, 0, 0),
                    FontSize = 16,
                    FontStyle = FontStyles.Italic,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Width = 80,
                    Height = 80
                };
                ContextMenu contextMenu = new ContextMenu();

                MenuItem option1 = new MenuItem { Header = "Ver Nota " };
                MenuItem option2 = new MenuItem { Header = "Eliminar" };
                // Agregar eventos de clic a las opciones
                option1.Click += (s, e) => verNota(us, nota);
                option2.Click += (s, e) => eliminarNota(nota);

                // Agregar opciones al menú
                contextMenu.Items.Add(option1);
                contextMenu.Items.Add(option2);

                // Asignar el ContextMenu al botón
                boton.ContextMenu = contextMenu;
                boton.Click += (s, e) =>
                {
                    boton.ContextMenu.IsOpen = true;
                };
                panel.Children.Add(boton);
            }
        }
        //RESEÑAS
        private void hacerReseña()
        {
            MessageBoxResult resultado = MessageBox.Show(
                "¿Quieres hacer una reseña del libro?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (resultado == MessageBoxResult.Yes)
            {
                AddReview aR = new AddReview(us, l,1);
                aR.Show();
            }
        }
        private void verReview(object sender, RoutedEventArgs e)
        {
            Review r = new Review();
            r = r.read(us.id, l.idLibro);
            if (r == null)
            {
                MessageBox.Show("No has hecho ninguna review sobre este libro.\nPara hacerla debes mover el libro a la colección leido");
            }
            else
            {
                AddReview aR = new AddReview(us, l, 2);
                aR.Show();
            }
        }
    }
}
