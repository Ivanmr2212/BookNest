using MyReads.Domain;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Persistance
{
    internal class NotaManagement
    {
        private List<Nota> listNota { get; set; }
        private DataTable table { get; set; }
        public NotaManagement()
        {
            table = new DataTable();
        }
        public List<Nota> ListNota { get { return listNota; } set { listNota = value; } }

        public Nota readNota(int id)
        {
            Nota u = null;
            List<Object> lNota;
            lNota = DBBroker.obtenerAgente().leer("SELECT * FROM nota WHERE idNota=" + id + ";");
            foreach (List<Object> aux in lNota)
            {
                u = new Nota(Int32.Parse(aux[0].ToString()));
                u.setTitulo(aux[1].ToString());
                u.setTexto(aux[2].ToString());
                u.setFecha(aux[3].ToString());
                u.setIdU(Int32.Parse(aux[6].ToString()));
                u.setIdL(Int32.Parse(aux[5].ToString()));
                u.setIdC(Int32.Parse(aux[4].ToString()));
            }
            return u;
        }
        public List<Nota> readNotasByUserLibro(Usuario user, Libro libro)
        {
            List<Nota> lista= new List<Nota>();
            Nota u = null;
            List<Object> lNota;
            lNota = DBBroker.obtenerAgente().leer("SELECT * FROM nota WHERE Usuario_idUsuario=" + user.id + " AND Libro_idLibro="+libro.idLibro+";");
            foreach (List<Object> aux in lNota)
            {
                u = new Nota(Int32.Parse(aux[0].ToString()));
                u.setTitulo(aux[1].ToString());
                u.setTexto(aux[2].ToString());
                u.setFecha(aux[3].ToString());
                u.setIdU(Int32.Parse(aux[6].ToString()));
                u.setIdL(Int32.Parse(aux[5].ToString()));
                u.setIdC(Int32.Parse(aux[4].ToString()));
                lista.Add(u);
            }
            return lista;
        }
        public List<Nota> readNotasByUserLibroCategoria(Usuario user, Libro libro, string nombreCategoria)
        {
            List<Nota> lista = new List<Nota>();
            Nota u = null;
            List<Object> lNota;
            lNota = DBBroker.obtenerAgente().leer("SELECT * FROM nota WHERE Usuario_idUsuario=" + user.id + " AND Libro_idLibro=" + libro.idLibro + " AND Categoria_idCategoria in(SELECT idCategoria from categoria where nombre='"+nombreCategoria+"');");
            foreach (List<Object> aux in lNota)
            {
                u = new Nota(Int32.Parse(aux[0].ToString()));
                u.setTitulo(aux[1].ToString());
                u.setTexto(aux[2].ToString());
                u.setFecha(aux[3].ToString());
                u.setIdU(Int32.Parse(aux[6].ToString()));
                u.setIdL(Int32.Parse(aux[5].ToString()));
                u.setIdC(Int32.Parse(aux[4].ToString()));
                lista.Add(u);
            }
            return lista;
        }
        public Nota readNotasByUserLibroTitulo(Usuario user, Libro libro, string titulo)
        {
            Nota u = null;
            List<Object> lNota;
            lNota = DBBroker.obtenerAgente().leer("SELECT * FROM nota WHERE Usuario_idUsuario=" + user.id + " AND Libro_idLibro=" + libro.idLibro + " AND titulo='"+titulo+"';");
            foreach (List<Object> aux in lNota)
            {
                u = new Nota(Int32.Parse(aux[0].ToString()));
                u.setTitulo(aux[1].ToString());
                u.setTexto(aux[2].ToString());
                u.setFecha(aux[3].ToString());
                u.setIdU(Int32.Parse(aux[6].ToString()));
                u.setIdL(Int32.Parse(aux[5].ToString()));
                u.setIdC(Int32.Parse(aux[4].ToString()));
            }
            return u;
        }
        public void insertNota(Nota u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into nota(titulo,texto,fecha,Categoria_idCategoria,Libro_idLibro,Usuario_idUsuario) values ('" + u.titulo+ "','" + u.texto+ "','"+u.fecha+"',"+u.idCategoria+","+u.idLibro+","+u.idUsuario+");");
        }
        public void deleteNota(Nota u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from nota where idNota=" + u.getId() + ";");
        }

        public Categoria readCategoria(Nota n)
        {
            int idCategoria = -1;
            Categoria cat = null;

            List<Object> categoria1= DBBroker.obtenerAgente().leer("SELECT Categoria_idCategoria from nota where idNota="+n.idNota+";");
            foreach (List<Object> aux in categoria1)
            {
                idCategoria =Int32.Parse(aux[0].ToString());
            }
            List<Object> categoria2 = DBBroker.obtenerAgente().leer("SELECT * from categoria where idCategoria=" + idCategoria+ ";");
            foreach (List<Object> aux in categoria2)
            {
                cat =new Categoria(Int32.Parse(aux[0].ToString()));
                cat.setNombre(aux[1].ToString());
                cat.setDesc(aux[2].ToString());
                cat.setIdUsuario(Int32.Parse(aux[3].ToString()));
            } 
            return cat;
        }
        public void modificarNota(Nota u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("UPDATE nota SET titulo='"+u.titulo+"',texto='"+u.texto+"',fecha='"+u.fecha+"',Categoria_idCategoria="+u.idCategoria+",Libro_idLibro="+u.idLibro+",Usuario_idUsuario="+u.idUsuario+" WHERE idNota="+u.idNota+";");
        }
    }
}
