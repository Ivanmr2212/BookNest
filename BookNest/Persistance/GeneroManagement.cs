using MyReads.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Persistance
{
    internal class GeneroManagement
    {
        private List<Genero> listGenero { get; set; }
        private DataTable table { get; set; }
        public GeneroManagement()
        {
            table = new DataTable();
        }
        public List<Genero> ListGenero { get { return listGenero; } set { listGenero = value; } }

        public Genero readGenero(int id)
        {
            Genero u = null;
            List<Object> lGen;
            lGen = DBBroker.obtenerAgente().leer("SELECT * FROM genero WHERE idGenero=" + id + ";");
            foreach (List<Object> aux in lGen)
            {
                u = new Genero(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setDesc(aux[2].ToString());
            }
            return u;
        }
        public List<Genero> readAll()
        {
            List<Genero> list = new List<Genero>();
            Genero u = null;
            List<Object> lGen;
            lGen = DBBroker.obtenerAgente().leer("SELECT * FROM genero;");
            foreach (List<Object> aux in lGen)
            {
                u = new Genero(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setDesc(aux[2].ToString());
                list.Add(u);
            }
            return list;
        }
        public void insertGenero(Genero u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into genero(nombre,descripcion) values ('" + u.nombre + "','" + u.desc + "');");
        }
        public void deleteGenero(Genero u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from genero where idGenero=" + u.getId() + ";");
        }
    }
}
