using MyReads.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Persistance
{
    internal class ColeccionManagement
    {
        private List<Coleccion> listColeccion { get; set; }
        private DataTable table { get; set; }
        public ColeccionManagement()
        {
            table = new DataTable();
        }
        public List<Coleccion> ListColeccion { get { return listColeccion; } set { listColeccion = value; } }

        public Coleccion readColeccion(int id)
        {
            Coleccion u = null;
            List<Object> lColeccion;
            lColeccion = DBBroker.obtenerAgente().leer("SELECT * FROM coleccion WHERE idColeccion=" + id + ";");
            foreach (List<Object> aux in lColeccion)
            {
                u = new Coleccion(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setIdCreador(Int32.Parse(aux[2].ToString()));
            }
            return u;
        }

        public List<Coleccion> readColeccionesUsuario(int id)
        {
            List<Coleccion>lista=new List<Coleccion>();
            Coleccion u= null;
            List<Object> lColeccion;
            lColeccion = DBBroker.obtenerAgente().leer("SELECT * FROM coleccion WHERE Usuario_idUsuario=" + id + " AND nombre!='Club de lectura';");
            foreach (List<Object> aux in lColeccion)
            {
                u = new Coleccion(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setIdCreador(Int32.Parse(aux[2].ToString()));
                lista.Add(u);
            }
            return lista;
        }
        public Coleccion busquedaColeccionesNombreYIdUsuario(Usuario user, string nombre)
        {
            Coleccion u = null;
            List<Object> lColeccion;
            lColeccion = DBBroker.obtenerAgente().leer("SELECT * FROM coleccion WHERE Usuario_idUsuario=" + user.id + " AND nombre='"+nombre+"';");
            foreach (List<Object> aux in lColeccion)
            {
                u = new Coleccion(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setIdCreador(Int32.Parse(aux[2].ToString()));
            }
            return u;
        }
        public List<Coleccion> readColeccionesUsuarioMenosDefault(int id)
        {
            List<Coleccion> lista = new List<Coleccion>();
            Coleccion u = null;
            List<Object> lColeccion;
            lColeccion = DBBroker.obtenerAgente().leer("SELECT * FROM coleccion WHERE Usuario_idUsuario=" + id + " AND nombre!='Leido' AND nombre!='Por leer' AND nombre!='Leyendo' AND nombre!='Favoritos'  AND nombre!='Todos';");
            foreach (List<Object> aux in lColeccion)
            {
                u = new Coleccion(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setIdCreador(Int32.Parse(aux[2].ToString()));
                lista.Add(u);
            }
            return lista;
        }
        public List<Coleccion> readColeccionesUsuarioNoTodos(int id)
        {
            List<Coleccion> lista = new List<Coleccion>();
            Coleccion u = null;
            List<Object> lColeccion;
            lColeccion = DBBroker.obtenerAgente().leer("SELECT * FROM coleccion WHERE Usuario_idUsuario=" + id + " AND nombre!='Todos';");
            foreach (List<Object> aux in lColeccion)
            {
                u = new Coleccion(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setIdCreador(Int32.Parse(aux[2].ToString()));
                lista.Add(u);
            }
            return lista;
        }
        public List<Coleccion> readColeccionesConLibro(Libro l)
        {
            List<Coleccion> lista = new List<Coleccion>();
            Coleccion c;
            List<Object> lObject;
            lObject = DBBroker.obtenerAgente().leer("SELECT * FROM coleccion WHERE idColeccion IN(SELECT Coleccion_idColeccion FROM libroscoleccion WHERE Libro_idLibro= " + l.idLibro + ");");
            foreach (List<Object> aux in lObject)
            {
                c = new Coleccion(Int32.Parse(aux[0].ToString()));
                c.setNombre(aux[1].ToString());
                c.setIdCreador(Int32.Parse(aux[2].ToString()));
                lista.Add(c);
            }
            return lista;
        }

        public void insertColeccion(Coleccion u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into coleccion(nombre,Usuario_idUsuario) values ('" + u.nombre + "','" + u.idCreador + "');");
        }
        public void insertUsuarioColeccion(Usuario u, Coleccion c)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into coleccion_has_usuario(Coleccion_idColeccion,Usuario_idUsuario) values (" + c.idColeccion+ "," + u.id+ ");");
        }
        public void deleteColeccion(Coleccion u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from coleccion where idColeccion=" + u.getId() + ";");
        }
        public void deleteLibrosColeccion(Coleccion c)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from libroscoleccion WHERE Coleccion_idColeccion=" + c.idColeccion + ";");
        }
        public void deleteUsuarioColeccion(Usuario u,Coleccion c)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from coleccion_has_usuario where Coleccion_idColeccion=" + c.idColeccion + " AND Usuario_idUsuario="+u.id+";");
        }
    }
}
