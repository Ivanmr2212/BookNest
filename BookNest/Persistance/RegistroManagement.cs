using Microsoft.Win32;
using MyReads.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Persistance
{
    internal class RegistroManagement
    {
        private List<Registro> listRegistro { get; set; }
        private DataTable table { get; set; }
        public RegistroManagement()
        {
            table = new DataTable();
        }
        public List<Registro> ListRegistro { get { return listRegistro; } set { listRegistro = value; } }

        public Registro readRegistro(int id)
        {
            Registro u = null;
            List<Object> lRegistro;
            lRegistro = DBBroker.obtenerAgente().leer("SELECT * FROM registro WHERE idRegistro=" + id + ";");
            foreach (List<Object> aux in lRegistro)
            {
                u = new Registro(Int32.Parse(aux[0].ToString()));
                u.setIdU(Int32.Parse(aux[1].ToString()));
                u.setIdL(Int32.Parse(aux[2].ToString()));
                u.setNombre(aux[3].ToString());
                u.setIdC(Int32.Parse(aux[4].ToString()));
            }
            return u;
        }
        public void insertRegistro(Registro u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into regitro(Usuario_idUsuario,Libro_idLibro,nombre,cantidad) values (" + u.idUsuario+ "," + u.idLibro+ ",'" + u.nombre+ "'," + u.cantidad+ ");");
        }
        public void deleteRegistro(Registro u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from registro where idRegistro=" + u.getId() + ";");
        }
    }
}
