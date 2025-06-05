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
    /// Lógica de interacción para Libreria.xaml
    /// </summary>
    public partial class Libreria : Window
    {
        string nombreColeccion;
        Coleccion colec = new Coleccion();
        Libro libro = new Libro();
        Usuario us;
        public List<Coleccion> listaColeccionesNoDefault;
        public List<Libro> listaLibrosColeccion;
        public Libreria(Usuario user)
        {
            InitializeComponent();
            us=user;

            listaColeccionesNoDefault = colec.readColeccionesUserMenosDefault(us.id); //Para obtener todas las colecciones que ha creado el user
            generarColecciones(listaColeccionesNoDefault, panelColecciones);
            
        }
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
        /// METODO PARA CERRAR LA APLICACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonCerrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show(
                "¿Seguro que quieres salir?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (resultado == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
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
        /// METODO QUE GENERA BOTONES SIMULANDO LIBROS EN UN STACK PANEL
        /// </summary>
        /// <param name="coleccion">COLECCION DE DONDE SE SACAN LOS LIBROS DE LA BBDD</param>
        /// <param name="panelPadre">STACK PANEL DONDE GENERAR LOS LIBROS</param>
        /// <param name="filtrar">TRUE O FALSE EN BASE A SI HAY UN FILTRADO POR TEXTO</param>
        private void generarLibrosColeccion(Coleccion coleccion, StackPanel panelPadre, bool filtrar)
        {
            List<Libro> libros = libro.leerLibrosColeccion(coleccion);
            if (filtrar)
            {
                libros = filtrarBusqueda(libros, txtBusqueda.Text);
            }
            double numFilas = (double)libros.Count / 4;
            numFilas = Math.Ceiling(numFilas);

            int filasFinales = (int)numFilas; //Numero de filas del stackPanel
            int librosFila = 4; //Numero de libros x fila
            int contLibros = 0; 
            int contLibrosTotal = 0;
            int contFilas = 0; //Contador de las filas que se han creado
            while (contLibros < libros.Count)
            {
                StackPanel panelHijo = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                };
                for (int i = 0; i < librosFila; i++)
                {
                    if (contLibros >=libros.Count)
                    {
                        break;
                    }
                    Libro libro2 = libros[contLibrosTotal];
                    string ruta = "pack://application:,,,/Images/portadas/" + libro2.img; 

                    StackPanel panelHijo2 = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        Margin = new Thickness(17, 10, 17, 10)
                    };
                    Button boton = new Button
                    {
                        Width = 110,
                        Height = 156,
                        BorderThickness=new Thickness(0)
                    };

                    Image imagen = new Image
                    {
                        Source = new BitmapImage(new Uri(ruta, UriKind.Absolute)) //Aquí se pondría el atributo del libro cuyo index en la lista sea contLibros 
                    };

                    boton.Content = imagen;

                    ContextMenu contextMenu = new ContextMenu();

                    MenuItem option1 = new MenuItem { Header = "Ver libro "};
                    MenuItem option2 = new MenuItem { Header = "Eliminar de la colección" };
                    MenuItem option3 = new MenuItem { Header = "Eliminar de todas las colecciones"};
                    int num = contLibrosTotal;
                    Libro libroElegido = libros[num];
                    // Agregar eventos de clic a las opciones
                    option1.Click += (s, e) => verLibro(us,libroElegido);
                    option2.Click += (s, e) => eliminarLibroUnaColeccion(coleccion, libroElegido);
                    option3.Click += (s, e) => eliminarLibroTodasColecciones(coleccion,libroElegido);

                    // Agregar opciones al menú
                    contextMenu.Items.Add(option1);
                    contextMenu.Items.Add(option2);
                    contextMenu.Items.Add(option3);

                    // Asignar el ContextMenu al botón
                    boton.ContextMenu = contextMenu;
                    boton.Click += (s, e) =>
                    {
                        boton.ContextMenu.IsOpen = true;
                    };

                    TextBlock labelTitulo = new TextBlock
                    {
                        Width = 110,
                        Text = libros[contLibros].titulo,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center
                    };
                    panelHijo2.Children.Add(boton);
                    panelHijo2.Children.Add(labelTitulo);
                    contLibros++;
                    contLibrosTotal++;
                    panelHijo.Children.Add(panelHijo2);
                }
                panelPadre.Children.Add(panelHijo);
                contFilas++;
            }
        }
        /// <summary>
        /// METODO QUE FILTRA LIBROS EN BASE A SI EL TITULO TIENE UN STRING
        /// </summary>
        /// <param name="lista">LISTA DE LA QUE SE FILTRA</param>
        /// <param name="busqueda">EN BASE A QUE SE FILTRA</param>
        /// <returns></returns>
        private List<Libro> filtrarBusqueda(List<Libro> lista, String busqueda)
        {
            List<Libro> listaFinal = new List<Libro>();
            foreach(Libro l in lista)
            {
                String tituloMayus = l.titulo.ToUpper();
                String tituloMinus= l.titulo.ToLower();
                if (tituloMayus.Contains(busqueda.ToUpper()) || tituloMinus.Contains(busqueda.ToLower()))
                {
                    listaFinal.Add(l);
                }
            }
            return listaFinal;
        }
        /// <summary>
        /// METODO PARA ELIMINAR UN LIBRO DE TODAS LAS COLECCIONES EN LAS QUE ESTÉ
        /// </summary>
        /// <param name="c">PARA GENERAR LUEGO LA MISMA COLECCIÓN EN LA QUE ESTABAMOS</param>
        /// <param name="l">LIBRO A ELIMINAR</param>
        private void eliminarLibroTodasColecciones(Coleccion c, Libro l)
        {
            List<Coleccion> lista = c.leerColeccionLibro(l);
            foreach(Coleccion colec in lista)
            {
                l.deleteLibroColeccion(l, colec);
            }
            generarLibros(c);
        }
        /// <summary>
        /// METODO PARA ELIMINAR UN LIBRO DE UNA ÚNICA COLECCION
        /// </summary>
        /// <param name="c">COLECCION DE LA QUE SE QUIERE BORRAR EL LIBRO</param>
        /// <param name="l">LIBRO A ELIMINAR</param>
        private void eliminarLibroUnaColeccion(Coleccion c, Libro l)
        {
            l.deleteLibroColeccion(l, colec);
            generarLibros(c); //PARA ACTUALIZAR EL PANEL
        }
        /// <summary>
        /// METODO QUE TE LLEVA A UNA VENTANA PARA VER TODA LA INFORMACIÓN DEL LIBRO
        /// </summary>
        /// <param name="us">USUARIO QUE SE ESTÁ USANDO</param>
        /// <param name="l">LIBRO A VER</param>
        private void verLibro(Usuario us, Libro l)
        {
            LibroInfo ventana = new LibroInfo(l, us,2);
            seeReviews see = new seeReviews(us, l);
            ventana.Show();
            see.Show();
            this.Close();
        }

        /// <summary>
        /// METODO QUE GENERA DINAMICAMENTE TODAS LAS COLECCIONES QUE ESTÉN EN UNA LISTA, SE CREAN EN UN PANEL A LA IZQUIERDA
        /// </summary>
        /// <param name="lista">LISTA DE COLECCIONES PARA GENERAR</param>
        /// <param name="panel">PANEL DONDE SE GENERAN LAS COLECCIONES</param>
        private void generarColecciones(List<Coleccion> lista, StackPanel panel)
        {
            panel.Children.Clear();
            foreach (Coleccion coleccion in lista)
            {
                Button boton = new Button
                {
                    Content = coleccion.nombre,
                    Margin = new Thickness(0, 0, 0, 10),
                    FontSize = 20,
                    FontStyle = FontStyles.Italic,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Width = 350,
                    Height = 30,
                    FontWeight = FontWeights.Bold,
                    BorderThickness = new Thickness(0),
                    Background = Brushes.Transparent,
                    Foreground = Brushes.White
                };
                boton.Click += (sender, e) => seleccionarColeccion(sender,e);
                panel.Children.Add(boton);
            }
        }
        /// <summary>
        /// METODO PARA VOLVER AL INICIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonVolver_Click(object sender, RoutedEventArgs e)
        {
            Home home= new Home(us);
            home.Show();
            this.Close();
        }
        /// <summary>
        /// METODO QUE TE LLEVA A UNA VENTANA PARA INSERTAR UNA COLECCION EN LA BBDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAddColeccion_Click(object sender, RoutedEventArgs e)
        {
            AddColeccion abrir= new AddColeccion(us);
            abrir.Show();
            this.Close();
        }
        /// <summary>
        /// METODO QUE TE LLEVA A LA VENTANA DE BÚSQUEDA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAddLibro_Click(object sender, RoutedEventArgs e)
        {
            Busqueda busq = new Busqueda(us);
            busq.Show();
            this.Close();
        }
        private void generarLibros(Coleccion colec)
        {
            panelLibros.Children.Clear();
            generarLibrosColeccion(colec, panelLibros,false);
        }
        /// <summary>
        /// METODO PARA SABER A QUE COLECCION SE HA HECHO CLICK Y ASÍ GENERAR LOS LIBROS QUE TENGA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seleccionarColeccion(object sender, RoutedEventArgs e)
        {
            nombreColeccion = (sender as Button).Content.ToString();
            Coleccion c = colec.readColeccionesUserYNombre(us,nombreColeccion);
            if (c == null)
            {
                MessageBox.Show("Colección vacia");
                panelLibros.Children.Clear();
            }
            else
            {
                colec = colec.read(c.idColeccion);
                generarLibros(colec);
                txtBusqueda.Text = null;
            }
        }
        /// <summary>
        /// BOTON PARA ELIMINAR UNA COLECCION Y LOS LIBROS QUE TENGA DENTRO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonEliminar_Click(object sender, RoutedEventArgs e)
        {
            bool borrar = false;
            Usuario userAdmin = new Usuario();
            userAdmin = userAdmin.readByNombre("Admin");
            List<Coleccion> coleccionesDefault = colec.readColeccionesUser(userAdmin);
            foreach(Coleccion c in coleccionesDefault)
            {
                if (c.nombre == nombreColeccion) { borrar = true;}
            }
            if (string.IsNullOrEmpty(nombreColeccion))
            {
                MessageBox.Show("Tienes que seleccionar una colección antes");
            }
            else if (borrar)
            {
                MessageBox.Show("Solo se pueden borrar colecciones que hayas creado tú mismo");
            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show(
                    "¿Eliminar colección?",
                    "Confirmación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (resultado == MessageBoxResult.Yes)
                {
                    Coleccion coleccion = colec.readColeccionesUserYNombre(us, nombreColeccion);
                    List<Libro> libros = libro.leerLibrosColeccion(coleccion);
                    foreach (Libro l in libros)
                    {
                        eliminarLibroTodasColecciones(coleccion, l);
                    }
                    coleccion.delete();
                    panelLibros.Children.Clear();
                    listaColeccionesNoDefault = colec.readColeccionesUserMenosDefault(us.id);
                    generarColecciones(listaColeccionesNoDefault, panelColecciones);
                    MessageBox.Show("Colección borrada correctamente");
                }
            }
        }
        /// <summary>
        /// METODO PARA FILTRAR LOS LIBROS EN BASE A UN TEXTO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonBusqueda_Click(object sender, RoutedEventArgs e)
        {
            panelLibros.Children.Clear();
            generarLibrosColeccion(colec, panelLibros,true);
        }
    }
}
