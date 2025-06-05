using MyReads.Domain;
using Mysqlx.Crud;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MyReads.Persistance
{
    internal class ReviewManagement
    {
        private List<Review> listReview { get; set; }
        private DataTable table { get; set; }
        public ReviewManagement()
        {
            table = new DataTable();
        }
        public List<Review> ListReview { get { return listReview; } set { listReview = value; } }

        public Review readReview(int idUser, int idLibro)
        {
            Review u = null;
            List<Object> lReview;
            lReview = DBBroker.obtenerAgente().leer("SELECT * FROM review WHERE Usuario_idUsuario=" + idUser + " AND Libro_idLibro="+idLibro+";");
            foreach (List<Object> aux in lReview)
            {
                u = new Review();
                u.setIdU(Int32.Parse(aux[0].ToString()));
                u.setIdL(Int32.Parse(aux[1].ToString()));
                u.setTexto(aux[2].ToString());
                u.setPuntuacion(Int32.Parse(aux[3].ToString()));
                u.setFecha(aux[4].ToString());
            }
            return u;
        }

        public List<Review> readAllReviewsBook(int idLibro)
        {
            List<Review> list = new List<Review>();
            Review u = null;
            List<Object> lReview;
            lReview = DBBroker.obtenerAgente().leer("SELECT * FROM review WHERE Libro_idLibro=" + idLibro + " ORDER BY fecha DESC;");
            foreach (List<Object> aux in lReview)
            {
                u = new Review();
                u.setIdU(Int32.Parse(aux[0].ToString()));
                u.setIdL(Int32.Parse(aux[1].ToString()));
                u.setTexto(aux[2].ToString());
                u.setPuntuacion(Int32.Parse(aux[3].ToString()));
                u.setFecha(aux[4].ToString());
                list.Add(u);
            }
            return list;
        }
        public List<Review> readAllReviewsUser(Usuario user)
        {
            List<Review> list = new List<Review>();
            Review u = null;
            List<Object> lReview;
            lReview = DBBroker.obtenerAgente().leer("SELECT * FROM review WHERE Usuario_idUsuario=" + user.id + ";");
            foreach (List<Object> aux in lReview)
            {
                u = new Review();
                u.setIdU(Int32.Parse(aux[0].ToString()));
                u.setIdL(Int32.Parse(aux[1].ToString()));
                u.setTexto(aux[2].ToString());
                u.setPuntuacion(Int32.Parse(aux[3].ToString()));
                u.setFecha(aux[4].ToString());
                list.Add(u);
            }
            return list;
        }
        public List<Review> readAllReviewsUserIntervalo(Usuario user, int dias)
        {
            List<Review> list = new List<Review>();
            Review u = null;
            List<Object> lReview;
            lReview = DBBroker.obtenerAgente().leer("SELECT * FROM review WHERE fecha BETWEEN DATE_SUB(CURDATE(), INTERVAL " + (dias - 1) + " DAY) AND CURDATE() AND Usuario_idUsuario=" + user.id + ";");
            foreach (List<Object> aux in lReview)
            {
                u = new Review();
                u.setIdU(Int32.Parse(aux[0].ToString()));
                u.setIdL(Int32.Parse(aux[1].ToString()));
                u.setTexto(aux[2].ToString());
                u.setPuntuacion(Int32.Parse(aux[3].ToString()));
                u.setFecha(aux[4].ToString());
                list.Add(u);
            }
            return list;
        }

        public void insertReview(Review u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into review(Usuario_idUsuario,Libro_idLibro,texto,puntuacion,fecha) values (" + u.getIdU() + "," + u.getIdL() + ",'" + u.getTexto() + "'," + u.getPuntuacion() + ",'"+ u.getFecha() + "');");
        }
        public void updateReview(Review u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Update review SET texto='"+u.getTexto()+"',puntuacion="+u.getPuntuacion()+",fecha='"+u.getFecha()+"' WHERE Usuario_idUsuario="+u.getIdU()+" AND Libro_idLibro="+u.getIdL()+";");
        }

        public void deleteReview(Review u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from review where Usuario_idUsuario=" + u.getIdU() + " AND Libro_idLibro="+u.getIdL()+";");
        }
    }
}
