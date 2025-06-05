using MyReads.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Persistance
{
    internal class CategoriaManagement
    {
        private List<Categoria> listCategoria { get; set; }
        private DataTable table { get; set; }
        public CategoriaManagement()
        {
            table = new DataTable();
        }
        public List<Categoria> ListCategoria { get { return listCategoria; } set { listCategoria = value; } }

        public Categoria readCategoria(int id)
        {
            Categoria u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM categoria WHERE idCategoria=" + id + ";");
            foreach (List<Object> aux in lUser)
            {
                u = new Categoria(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setDesc(aux[2].ToString());
            }
            return u;
        }
        public Categoria readCategoriaByUserYNombre(int id, string nombre)
        {
            Categoria u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM categoria WHERE Usuario_idUsuario=" + id + " AND nombre='"+nombre+"';");
            foreach (List<Object> aux in lUser)
            {
                u = new Categoria(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setDesc(aux[2].ToString());
            }
            return u;
        }
        public List<Categoria> readCategoriasUsuario(int id)
        {
            List<Categoria> lista = new List<Categoria>();
            Categoria u = null;
            List<Object> lColeccion;
            lColeccion = DBBroker.obtenerAgente().leer("SELECT * FROM categoria WHERE Usuario_idUsuario=" + id + ";");
            foreach (List<Object> aux in lColeccion)
            {
                u = new Categoria(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setDesc(aux[2].ToString());
                u.setIdUsuario(Int32.Parse(aux[3].ToString()));
                lista.Add(u);
            }
            return lista;
        }
        public List<Categoria> readAll()
        {
            List<Categoria> lista= new List<Categoria>();
            Categoria u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM categoria;");
            foreach (List<Object> aux in lUser)
            {
                u = new Categoria(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setDesc(aux[2].ToString());
                lista.Add(u);
            }
            return lista;
        }
        public void insertCategoria(Categoria u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into categoria(nombre,descripcion,Usuario_idUsuario) values ('" + u.nombre + "','" + u.desc + "',"+u.idUsuario+");");
        }
        public void deleteCategoria(Categoria u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from categoria where idCategoria=" + u.idCategoria + ";");
        }
    }
}
