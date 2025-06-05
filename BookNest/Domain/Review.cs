using MyReads.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Review
    {
        int idUsuario;
        int idLibro;
        string texto;
        int puntuacion;
        string fecha;
        ReviewManagement rm = new ReviewManagement();
        public Review() { rm=new ReviewManagement(); }
        public Review(int idU, int idL, string texto, int puntuacion, string fecha)
        {
            this.idUsuario = idU;
            this.idLibro = idL;
            this.texto = texto;
            this.puntuacion = puntuacion;
            this.fecha = fecha;
        }

        public int getIdU() { return idUsuario; }
        public int getIdL() { return idLibro; }
        public String getTexto() { return texto; }
        public int getPuntuacion() { return puntuacion; }
        public String getFecha() { return fecha; }
        public void setIdU(int id) { this.idUsuario = id; }
        public void setIdL(int id) { this.idLibro = id; }
        public void setTexto(String texto) { this.texto = texto; }
        public void setPuntuacion(int punt) { this.puntuacion= punt; }
        public void setFecha(String fecha) { this.fecha = fecha; }

        public Review read(int idU, int idL)
        {
            Review u = null;
            u = rm.readReview(idU,idL);
            return u;
        }
        public List<Review> readAllFromBook(Libro l)
        {
            List<Review> list;
            list = rm.readAllReviewsBook(l.idLibro);
            return list;
        }
        public List<Review> readAllFromUser(Usuario u)
        {
            List<Review> list;
            list = rm.readAllReviewsUser(u);
            return list;
        }
        public List<Review> readAllFromUserIntervalo(Usuario u, int dias)
        {
            List<Review> list;
            list = rm.readAllReviewsUserIntervalo(u,dias);
            return list;
        }
        public void insert()
        {
            rm.insertReview(this);
        }

        public void update()
        {
            rm.updateReview(this);
        }

        public void delete()
        {
            rm.deleteReview(this);
        }

        override
        public string ToString()
        {
            string str = "Review. IdUsuario: " + this.idUsuario+ ", IdLibro: " + this.idLibro+ ", Puntuacion: " + this.puntuacion+ ", Fecha: " + this.fecha;
            return str;
        }
    }
}
