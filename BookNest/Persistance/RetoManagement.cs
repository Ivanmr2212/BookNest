using MyReads.Domain;
using MyReads.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Persistance
{
    internal class RetoManagement
    {
        private List<Reto> listReto{ get; set; }
        private DataTable table { get; set; }
        public RetoManagement()
        {
            table = new DataTable();
        }
        public List<Reto> ListReto { get { return listReto; } set { listReto= value; } }

        public Reto readReto(int idReto)
        {
            Reto u = null;
            List<Object> lReto;
            lReto= DBBroker.obtenerAgente().leer("SELECT * FROM reto WHERE idReto=" + idReto+ ";");
            foreach (List<Object> aux in lReto)
            {
                u = new Reto();
                u.setId(Int32.Parse(aux[0].ToString()));
                u.setLeido(Int32.Parse(aux[1].ToString()));
                u.setTotal(Int32.Parse(aux[2].ToString()));
                u.setInicio(aux[3].ToString());
                u.setFin(aux[4].ToString());
                int comp = Int32.Parse(aux[5].ToString());
                if (comp == 1) { u.setComp(true); } else { u.setComp(false); }
                u.setIdU(Int32.Parse(aux[6].ToString()));
            }
            return u;
        }
        public Reto readRetoNoComp(Usuario user)
        {
            Reto u = null;
            List<Object> lReto;
            lReto = DBBroker.obtenerAgente().leer("SELECT * FROM reto WHERE Usuario_idUsuario=" + user.id+ " AND completado=0;");
            foreach (List<Object> aux in lReto)
            {
                u = new Reto();
                u.setId(Int32.Parse(aux[0].ToString()));
                u.setLeido(Int32.Parse(aux[1].ToString()));
                u.setTotal(Int32.Parse(aux[2].ToString()));
                u.setInicio(aux[3].ToString());
                u.setFin(aux[4].ToString());
                int comp = Int32.Parse(aux[5].ToString());
                if (comp == 1) { u.setComp(true); } else { u.setComp(false); }
                u.setIdU(Int32.Parse(aux[6].ToString()));
            }
            return u;
        }

        public List<Reto> readAllRetosUser(Usuario user)
        {
            List<Reto> list = new List<Reto>();
            Reto u = null;
            List<Object> lReto;
            lReto = DBBroker.obtenerAgente().leer("SELECT * FROM reto WHERE Usuario_idUsuario=" + user.id+ ";");
            foreach (List<Object> aux in lReto)
            {
                u = new Reto();
                u.setId(Int32.Parse(aux[0].ToString()));
                u.setLeido(Int32.Parse(aux[1].ToString()));
                u.setTotal(Int32.Parse(aux[2].ToString()));
                u.setInicio(aux[3].ToString());
                u.setFin(aux[4].ToString());
                int comp=Int32.Parse(aux[5].ToString());
                if (comp == 1) { u.setComp(true); } else { u.setComp(false); }
                u.setIdU(Int32.Parse(aux[6].ToString()));
                list.Add(u);
            }
            return list;
        }

        public void insertReto(Reto u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into reto(idReto,leido,total,inicio,fin,completado,Usuario_idUsuario) values (" + u.getId() + "," + u.getLeido() + "," + u.getTotal() + ",'" + u.getInicio() + "','" + u.getFin() + "',"+u.getComp()+","+u.getIdUser()+");");
        }
        public void actualizarReto(Reto u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Update reto SET completado=" + u.getComp() + ",leido=" + u.getLeido() + ",fin='"+u.getFin()+"' WHERE idReto=" + u.getId() + ";");
        }
        public void sumar1Reto(Reto u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Update reto SET leido=" + u.getLeido() + " WHERE idReto=" + u.getId() + ";");
        }
        public void actualizarCompletado(Reto u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Update reto SET completado=" + u.getComp() + " WHERE idReto=" + u.getId() + ";");
        }

        public void deleteReto(Reto u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from reto where idReto=" + u.getId() + ";");
        }
    }
}
