using MyReads.Domain;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Lógica de interacción para Busqueda.xaml
    /// </summary>
    public partial class Busqueda : Window
    {
        Usuario us;
        int cont = 0; //Contador para el cambio en el comboBox
        int cont2 = 0; //Contador de libros añadidos checkboxs
        List<Libro> listaGenero=new List<Libro>(); //Lista con los generos de los libros
        List<Libro> listaBusquedaTexto = new List<Libro>(); //Lista que filtra en base al texto escrito
        List<Libro> listaFiltroGyT = new List<Libro>(); //Lista con filtro de los generos y texto
        List<Libro> listaFiltroPyP = new List<Libro>(); //Lista con filtro de paginas y año publicacion
        List<Libro> listaTodosLosLibros = new List<Libro>(); //Lista con todos los libros
        int minF; int maxF; int minP; int maxP; //Minimo y máxmimo de numPags y año publicacion
        public Busqueda(Usuario user)
        {
            InitializeComponent();
            us = user;

            //Para generar las listas y los generos desde la base de datos
            Libro libro = new Libro();
            listaTodosLosLibros = libro.readAll();
            gridBusqueda.ItemsSource = listaTodosLosLibros;

            Genero g=new Genero();
            List<Genero> listAll= new List<Genero>();
            listAll=g.readAll();
            foreach (Genero genero in listAll)
            {
                comboBoxGeneros.Items.Add(new ComboBoxItem { Content = genero.getNombre()});
            }
        }

        //Para mover la ventana
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        //Para cerrar la aplicacion
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
        //Para minimizar la aplicacion
        private void BotonMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void txtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            listaBusquedaTexto.Clear();
            if (check399.IsChecked == true || check400.IsChecked == true || check800.IsChecked == true || radioButton1999.IsChecked == true || radioButton2010.IsChecked == true || radioButton2000.IsChecked == true)
            {
                listaBusquedaTexto = busquedaGeneral(txtBusqueda, listaFiltroPyP, gridBusqueda);
            }
            else if (comboBoxGeneros.SelectedIndex != -1)
            {
                listaBusquedaTexto = busquedaGeneral(txtBusqueda, listaGenero, gridBusqueda);
            }
            else
            {
                listaBusquedaTexto = busquedaGeneral(txtBusqueda, listaTodosLosLibros, gridBusqueda);
            }
            if(string.IsNullOrEmpty(txtBusqueda.Text))
            {
                listaBusquedaTexto.Clear();
                gridBusqueda.ItemsSource = listaTodosLosLibros;
            }
            else
            {
                gridBusqueda.ItemsSource = listaBusquedaTexto;
            }
            gridBusqueda.Items.Refresh();
        }
        //Filtrar en base al content de un textBox
        private List<Libro> busquedaGeneral(TextBox texto, List<Libro> lst, DataGrid grid)
        {
            List<Libro> listaB = new List<Libro>();
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].getTitulo().ToLower().Contains(texto.Text.ToLower()) || lst[i].getAutor().ToLower().Contains(texto.Text.ToLower()) || lst[i].getEditorial().ToLower().Contains(texto.Text.ToLower())) 
                {
                    listaB.Add(lst[i]);
                }
            }
            grid.ItemsSource = listaB;
            return listaB;
        }
        private void comboBoxGeneros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaGenero.Clear();
            listaFiltroGyT.Clear();

            if (comboBoxGeneros.SelectedIndex == -1) return;
            string seleccionado = ((ComboBoxItem)comboBoxGeneros.SelectedItem).Content.ToString();
            Libro l = new Libro();
            listaGenero = l.readByGenero(seleccionado);
            if (listaFiltroPyP.Count > 0)
            {
                filtrarPorGenero(listaFiltroPyP, listaGenero);
            }
            else if (listaBusquedaTexto.Count > 0)
            {
                filtrarPorGenero(listaBusquedaTexto, listaGenero);
            }
            else
            {
                filtrarPorGenero(listaTodosLosLibros, listaGenero);
            }
            gridBusqueda.ItemsSource = listaFiltroGyT;
            gridBusqueda.Items.Refresh();
        }

        private void filtrarPorGenero(List<Libro> lista1, List<Libro> lista2)
        {
            foreach (Libro lib in lista1)
            {
                foreach (Libro lib2 in lista2)
                {
                    if (lib.idGenero == lib2.idGenero && lib.titulo == lib2.titulo) //Hago esta condición en vez de usar el idLibro por si existe el mismo libro en varias versiones
                    {
                        listaFiltroGyT.Add(lib);
                    }
                }
            }
        }

        //Filtrar en base al año de publicacion
        private void filtrarYear(List<Libro> lista)
        {
            listaFiltroPyP.Clear();
            foreach (Libro libro in lista)
            {
                if (libro.year >= minF && libro.year < maxF)
                {
                    listaFiltroPyP.Add(libro);
                }
            }
            gridBusqueda.ItemsSource = listaFiltroPyP;
            gridBusqueda.Items.Refresh();
        }
        //Filtrar en base al numero de paginas
        private void filtrarNumPags(List<Libro> lista)
        {
            foreach (Libro libro in lista)
            {
                if (libro.numPags >= minP && libro.numPags < maxP)
                {
                    listaFiltroPyP.Add(libro);
                    cont2++;
                }
            }
            gridBusqueda.ItemsSource = listaFiltroPyP;
            gridBusqueda.Items.Refresh();
        }
        //Filtro en caso de que un radio button y un checkbox están marcados
        private void filtrarYearYPags(List<Libro> lista)
        {
            if (cont == 0)
            {
                listaFiltroPyP.Clear();
                cont=1;
            }
            MessageBox.Show("MinP " + minP + " MaxP " + maxP + " MinF " + minF + " MaxF " + maxF);
            foreach (Libro libro in lista)
            {
                if (libro.numPags >= minP && libro.numPags < maxP && libro.year < maxF & libro.year >= minF)
                {
                    listaFiltroPyP.Add(libro);
                }
            }
                
            gridBusqueda.ItemsSource = listaFiltroPyP;
            gridBusqueda.Items.Refresh();
        }
        //Elige un tipo de filtro en base a que está marcado y que no
        private void comprobarChecks()
        {
            if ((check399.IsChecked == true || check400.IsChecked == true || check800.IsChecked == true) && (radioButton1999.IsChecked==false && radioButton2010.IsChecked == false && radioButton2000.IsChecked == false))
            {
                MessageBox.Show("filtrarNumPags "+minP+" "+maxP);
                if (listaFiltroGyT.Count > 0)
                {
                    MessageBox.Show("GYT");
                    filtrarNumPags(listaFiltroGyT);
                }
                else if (comboBoxGeneros.SelectedIndex != -1) 
                {
                    MessageBox.Show("Genero");
                    filtrarNumPags(listaGenero);
                }
                else if (listaBusquedaTexto.Count>0)
                {
                    MessageBox.Show("Texto");
                    filtrarNumPags(listaBusquedaTexto);
                }
                else
                {
                    MessageBox.Show("Todos");
                    filtrarNumPags(listaTodosLosLibros);
                }
            }else if ((radioButton1999.IsChecked == true || radioButton2010.IsChecked == true|| radioButton2000.IsChecked == true) && (check399.IsChecked == false && check400.IsChecked == false && check800.IsChecked == false))
            {
                MessageBox.Show("filtrarYear");
                if (listaFiltroGyT.Count>0)
                {
                    MessageBox.Show("GYT");
                    filtrarYear(listaFiltroGyT);
                }
                else if (comboBoxGeneros.SelectedIndex != -1)
                {
                    MessageBox.Show("Genero");
                    filtrarNumPags(listaGenero);
                }
                else if (listaBusquedaTexto.Count > 0)
                {
                    MessageBox.Show("Texto");
                    filtrarNumPags(listaBusquedaTexto);
                }
                else
                {
                    MessageBox.Show("Todos");
                    filtrarYear(listaTodosLosLibros);
                }
            }
            else
            {
                MessageBox.Show("filtrar Los dos");
                if (listaFiltroGyT.Count > 0)
                {
                    MessageBox.Show("GYT");
                    filtrarYearYPags(listaFiltroGyT);
                }
                else if (comboBoxGeneros.SelectedIndex != -1) 
                {
                    MessageBox.Show("Genero");
                    filtrarNumPags(listaGenero);
                }
                else if (listaBusquedaTexto.Count>0)
                {
                    MessageBox.Show("Texto");
                    filtrarNumPags(listaBusquedaTexto);
                }
                else
                {
                    MessageBox.Show("Todos");
                    filtrarYearYPags(listaTodosLosLibros);
                }
            }
        }
        //Seleccionar un libro y te manda a su página
        private void botonSelect_Click(object sender, RoutedEventArgs e)
        {
            if (gridBusqueda.SelectedItem == null)
            {
                MessageBox.Show("Tienes que seleccionar un libro");
            }
            else
            {
                Libro l=gridBusqueda.SelectedItem as Libro;
                LibroInfo view = new LibroInfo(l,us,1);
                seeReviews see=new seeReviews(us,l);
                view.Show();
                see.Show();
                this.Close();
            }
        }
        //Botón de vuelta al menú de inicio
        private void botonCancel_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home(us);
            home.Show();
            this.Close();
        }

        private void radioButton2010_Checked(object sender, RoutedEventArgs e)
        {
            minF = 2010;
            maxF = DateTime.Now.Year;
            comprobarChecks();
        }

        private void radioButton200_Checked(object sender, RoutedEventArgs e)
        {
            minF = 2000;
            maxF = 2009;
            comprobarChecks();
        }

        private void radioButton1999_Checked(object sender, RoutedEventArgs e)
        {
            minF = 0;
            maxF = 1999;
            comprobarChecks();
        }

        private void check800_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                minP = 800;
                maxP= 5000;
                comprobarChecks();
                if (cont2 == 0)
                {
                    listaFiltroGyT.Clear();
                    cont2 = 0;
                }
            }
            else
            {
                //No va
                quitarFiltroNumPags(listaFiltroPyP);
                quitarFiltroNumPags(listaFiltroGyT);
                quitarFiltroNumPags(listaBusquedaTexto);
                quitarFiltroNumPags(listaGenero);
                gridBusqueda.Items.Refresh();
            }
        }

        private void check400_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                minP = 400;
                maxP = 799;
                comprobarChecks();
                if (cont2 == 0)
                {
                    listaFiltroGyT.Clear();
                    cont2 = 0;
                }
            }
            else
            {
                //No va
                quitarFiltroNumPags(listaFiltroPyP);
                quitarFiltroNumPags(listaFiltroGyT);
                quitarFiltroNumPags(listaBusquedaTexto);
                quitarFiltroNumPags(listaGenero);
                gridBusqueda.Items.Refresh();
            }
        }

        private void check399_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                minP = 0;
                maxP = 399;
                comprobarChecks();
                if (cont2 == 0)
                {
                    listaFiltroGyT.Clear();
                    cont2 = 0;
                }
            }
            else
            {
                //No va
                quitarFiltroNumPags(listaFiltroPyP);
                quitarFiltroNumPags(listaFiltroGyT);
                quitarFiltroNumPags(listaBusquedaTexto);
                quitarFiltroNumPags(listaGenero);
                gridBusqueda.Items.Refresh();
            }
        }
        private void quitarFiltroNumPags(List<Libro> lista)
        {
            foreach (Libro libro in lista)
            {
                if (libro.numPags >= minP && libro.numPags < maxP)
                {
                    listaFiltroPyP.Remove(libro);
                }
            }
        }
        private void botonQuitarFiltro_Click(object sender, RoutedEventArgs e)
        {
            listaFiltroGyT.Clear();
            listaFiltroPyP.Clear();
            listaGenero.Clear();
            listaBusquedaTexto.Clear();
            radioButton1999.IsChecked = false;
            radioButton2000.IsChecked = false;
            radioButton2010.IsChecked = false;
            check399.IsChecked = false;
            check400.IsChecked = false;
            check800.IsChecked = false;
            comboBoxGeneros.SelectedIndex = -1;
            Libro l = new Libro();
            listaBusquedaTexto = l.readAll();
            gridBusqueda.ItemsSource = listaBusquedaTexto;
            gridBusqueda.Items.Refresh();
            txtBusqueda.Text = null;
            cont = 0;
        }

        private void botonGenerateLibros_Click(object sender, RoutedEventArgs e)
        {
            Libro l = new Libro();
            List<Libro> listaLibros = l.readAll();
            if (listaLibros.Count >0)
            {
                MessageBox.Show("Ya hay libros insertados en la base de datos");
            }
            else
            {
                l.generarTodos();
                MessageBox.Show("Libros añadidos con éxito");
            }
            
            listaTodosLosLibros= l.readAll();
            gridBusqueda.ItemsSource = listaTodosLosLibros;
            gridBusqueda.Items.Refresh();
        }
    }
}
