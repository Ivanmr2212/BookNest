using MyReads.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Club
    {
        ClubManagement cm;
        public int idClub { get; set; }
        public string nombre { get; set; }
        public string desc { get; set; }
        public string img{ get; set; }
        public int idCreador { get; set; }
        public int idLectura { get; set; }

        public Club() { this.cm = new ClubManagement(); }

        public Club(int id) { this.idClub = id; this.cm = new ClubManagement(); }

        public Club(string nombre, string desc, int idCreador, int idLibro)
        {
            this.cm = new ClubManagement();
            this.nombre = nombre;
            this.desc = desc;
            this.idCreador = idCreador;
            this.idLectura = idLibro;
            this.img = "grupo_perfil_defecto.png";
        }

        public int getId() { return idClub; }
        public String getNombre() { return nombre; }
        public String getDesc() { return desc; }
        public String getImg() { return img; }
        public int getIdCreador() { return idCreador; }
        public int getIdLectura() { return idLectura; }
        public void setId(int id) { this.idClub = id; }
        public void setNombre(String nombre) { this.nombre = nombre; }
        public void setDesc(String desc) { this.desc = desc; }
        public void setImg(String img) { this.img= img; }
        public void setIdCreador(int id) { this.idCreador = id; }
        public void setIdLectura(int id) { this.idLectura = id; }


        public Club read(int id)
        {
            Club u = null;
            u = cm.readClub(id);
            return u;
        }
        public Club readClubFull()
        {
            Club u = null;
            u = cm.readClubFull(this);
            return u;
        }
        public List<Club> readCreador(Usuario us)
        {
            List<Club> lista = null;
            lista = cm.readClubCreador(us);
            return lista;
        }
        public List<Club> readClubsUsuario(Usuario us)
        {
            List<Club> lista = null;
            lista = cm.readClubsUsuario(us);
            return lista;
        }
        public void insert()
        {
            cm.insertClub(this);
        }
        public void insertUser(Usuario us)
        {
            cm.insertClubUsuario(this,us);
        }

        public void delete()
        {
            cm.deleteClub(this);
        }
        public void deleteClubUser(Usuario user)
        {
            cm.deleteClubUsuario(this,user);
        }
        public int countUsuariosEnClub()
        {
            int count = -1;
            count=cm.countUsuariosInClub(this);
            return count;
        }

        override
        public string ToString()
        {
            string str = "Club. Nombre: " + this.nombre + ", Desc: " + this.desc + ", IdCreador: " + this.idCreador + ", IdLectura: " + this.idLectura;
            return str;
        }
    }
}
