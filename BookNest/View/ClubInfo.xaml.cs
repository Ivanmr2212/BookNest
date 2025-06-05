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
    /// Lógica de interacción para ClubInfo.xaml
    /// </summary>
    public partial class ClubInfo : Window
    {
        Usuario us;
        Usuario creador;
        Club club;
        Coleccion c=new Coleccion();
        public ClubInfo(Usuario user, Club clu)
        {
            us = user; //Usuario que ha iniciado sesión
            club = clu; 

            creador = us.read(club.idCreador); //Usuario creador del club
            c = c.readColeccionesUserYNombre(creador, "Club de lectura"); //Esta es la colección compartida del club de lectura

            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
