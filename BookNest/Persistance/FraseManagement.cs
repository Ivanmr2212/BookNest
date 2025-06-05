using MyReads.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Persistance
{
    internal class FraseManagement
    {
        private List<Categoria> listCategoria { get; set; }
        private DataTable table { get; set; }
        public FraseManagement()
        {
            table = new DataTable();
        }
        public List<Frase> listFrase { get { return listFrase; } set { listFrase = value; } }

        public Frase readFrase(int id)
        {
            Frase u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM frase WHERE idFrase=" + id + ";");
            foreach (List<Object> aux in lUser)
            {
                u = new Frase(Int32.Parse(aux[0].ToString()));
                u.setContenido(aux[1].ToString());
            }
            return u;
        }
        public List<Frase> readAll()
        {
            List<Frase> lista = new List<Frase>();
            Frase u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM frase;");
            foreach (List<Object> aux in lUser)
            {
                u = new Frase(Int32.Parse(aux[0].ToString()));
                u.setContenido(aux[1].ToString());
                lista.Add(u);
            }
            return lista;
        }
        public void insertFrase(Frase u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into frase(contenido) values ('" + u.contenido+ "');");
        }
        public void deleteFrase(Frase u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from frase where idFrase=" + u.idFrase + ";");
        }
    }
}
