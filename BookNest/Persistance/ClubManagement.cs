using MyReads.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Persistance
{
    internal class ClubManagement
    {
        private List<Club> listClub { get; set; }
        private DataTable table { get; set; }
        public ClubManagement()
        {
            table = new DataTable();
        }
        public List<Club> ListClub { get { return listClub; } set { listClub = value; } }

        public Club readClub(int id)
        {
            Club u = null;
            List<Object> lClub;
            lClub = DBBroker.obtenerAgente().leer("SELECT * FROM club WHERE idClub=" + id + ";");
            foreach (List<Object> aux in lClub)
            {
                u = new Club(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setDesc(aux[2].ToString());
                u.setImg(aux[3].ToString());
                u.setIdCreador(Int32.Parse(aux[4].ToString()));
                u.setIdLectura(Int32.Parse(aux[5].ToString()));
            }
            return u;
        }
        public Club readClubFull(Club club)
        {
            Club u = null;
            List<Object> lClub;
            lClub = DBBroker.obtenerAgente().leer("SELECT * FROM club WHERE nombre='" + club.nombre+ "' AND descripcion='"+club.desc+"' AND Usuario_idUsuario="+club.idCreador+" AND Libro_idLibro="+club.idLectura+";");
            foreach (List<Object> aux in lClub)
            {
                u = new Club(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setDesc(aux[2].ToString());
                u.setImg(aux[3].ToString());
                u.setIdCreador(Int32.Parse(aux[4].ToString()));
                u.setIdLectura(Int32.Parse(aux[5].ToString()));
            }
            return u;
        }
        public List<Club> readClubCreador(Usuario us)
        {
            List<Club> lista= new List<Club>();
            Club u = null;
            List<Object> lClub;
            lClub = DBBroker.obtenerAgente().leer("SELECT * FROM club WHERE Usuario_idUsuario=" + us.id+ ";");
            foreach (List<Object> aux in lClub)
            {
                u = new Club(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setDesc(aux[2].ToString());
                u.setImg(aux[3].ToString());
                u.setIdCreador(Int32.Parse(aux[4].ToString()));
                u.setIdLectura(Int32.Parse(aux[5].ToString()));
                lista.Add(u);
            }
            return lista;
        }
        public List<Club> readClubsUsuario(Usuario us)
        {
            List<Club> lista = new List<Club>();
            Club u = null;
            List<Object> lClub;
            lClub = DBBroker.obtenerAgente().leer("SELECT * FROM club WHERE idClub IN(SELECT Club_idClub from usuario_has_club WHERE Usuario_idUsuario="+us.id+");");
            foreach (List<Object> aux in lClub)
            {
                u = new Club(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setDesc(aux[2].ToString());
                u.setImg(aux[3].ToString());
                u.setIdCreador(Int32.Parse(aux[4].ToString()));
                u.setIdLectura(Int32.Parse(aux[5].ToString()));
                lista.Add(u);
            }
            return lista;
        }
        public void insertClub(Club u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into club(nombre,descripcion,img,Usuario_idUsuario,Libro_idLibro) values ('" + u.nombre + "','" + u.desc + "','"+u.img+"'," + u.idCreador + ","+u.idLectura+");");
        }
        public void insertClubUsuario(Club u, Usuario us)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into usuario_has_club(Usuario_idUsuario,Club_idClub) values (" + us.id + "," + u.idClub+ ");");
        }
        public void deleteClub(Club u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from club where idClub=" + u.getId() + ";");
        }

        public void deleteClubUsuario(Club u, Usuario user)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from usuario_has_club where Club_idClub=" + u.getId() + " AND Usuario_idUsuario="+user.id+";");
        }
        public int countUsuariosInClub(Club u)
        {
            int count = -1;
            DBBroker dBBroker = DBBroker.obtenerAgente();
            count=dBBroker.modificar("SELECT COUNT(Usuario_idUsuario) FROM usuario_has_club WHERE Club_idClub="+u.idClub+";");
            return count;
        }
    }
}
