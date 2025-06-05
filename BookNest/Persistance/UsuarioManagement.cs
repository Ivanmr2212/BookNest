using MyReads.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Persistance
{
    internal class UsuarioManagement
    {
        private List<Usuario> listUsuario { get; set; }
        private DataTable table { get; set; }
        public UsuarioManagement()
        {
            table = new DataTable();
        }
        public List<Usuario> ListUsuario { get { return listUsuario; } set { listUsuario = value; } }

        public Usuario readUsuario(int id)
        {
            Usuario u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM usuario WHERE idUsuario=" + id+ ";");
            foreach (List<Object> aux in lUser)
            {
                u = new Usuario(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setCorreo(aux[2].ToString());
                u.setPass(aux[3].ToString());
                u.setImg(aux[4].ToString());
            }
            return u;
        }
        public List<Usuario> readAll()
        {
            List<Usuario> lista = new List<Usuario>();
            Usuario u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM usuario;");
            foreach (List<Object> aux in lUser)
            {
                u = new Usuario(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setCorreo(aux[2].ToString());
                u.setPass(aux[3].ToString());
                u.setImg(aux[4].ToString());
                lista.Add(u);
            }
            return lista;
        }
        public List<Usuario> readAllMenosUno(Usuario user)
        {
            List<Usuario> lista = new List<Usuario>();
            Usuario u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM usuario WHERE idUsuario!="+user.id+ " AND idUsuario!=11;");
            foreach (List<Object> aux in lUser)
            {
                u = new Usuario(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setCorreo(aux[2].ToString());
                u.setPass(aux[3].ToString());
                u.setImg(aux[4].ToString());
                lista.Add(u);
            }
            return lista;
        }

        public Usuario readUsuarioByNombreYCorreo(String nombre)
        {
            Usuario u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM usuario WHERE nombre='" + nombre+ "' or correo='"+nombre+"';");
            foreach (List<Object> aux in lUser)
            {
                u = new Usuario(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setCorreo(aux[2].ToString());
                u.setPass(aux[3].ToString());
                u.setImg(aux[4].ToString());
            }
            return u;
        }

        public Usuario readUsuarioByNombre(String nombre)
        {
            Usuario u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM usuario WHERE nombre='" + nombre + "';");
            foreach (List<Object> aux in lUser)
            {
                u = new Usuario(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setCorreo(aux[2].ToString());
                u.setPass(aux[3].ToString());
                u.setImg(aux[4].ToString());
            }
            return u;
        }

        public Usuario readUsuarioByCorreo(String correo)
        {
            Usuario u = null;
            List<Object> lUser;
            lUser = DBBroker.obtenerAgente().leer("SELECT * FROM usuario WHERE correo='" + correo+ "';");
            foreach (List<Object> aux in lUser)
            {
                u = new Usuario(Int32.Parse(aux[0].ToString()));
                u.setNombre(aux[1].ToString());
                u.setCorreo(aux[2].ToString());
                u.setPass(aux[3].ToString());
                u.setImg(aux[4].ToString());
            }
            return u;
        }

        public void insertUsuario(Usuario u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into usuario(nombre,correo,pass,img) values ('" + u.getNombre() + "','" + u.getCorreo() + "','" + u.getPass() + "','"+u.getImg()+"');");
        }
        public void deleteUsuario(Usuario u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from usuario where idUsuario=" + u.getId() + ";");
        }

        public void updatePass(Usuario u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Update usuario set pass='" + u.getPass() + "' where idUsuario=" + u.getId() + ";");
        }
        public void updateImg(Usuario u)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Update usuario set img='" + u.img + "' where idUsuario=" + u.id + ";");
        }

        public List<Amigo> readAllAmigos()
        {
            List<Amigo> lista = new List<Amigo>();
            Amigo amg = null;
            List<Object> lAmigo;
            lAmigo = DBBroker.obtenerAgente().leer("SELECT * FROM amigo;");
            foreach (List<Object> aux in lAmigo)
            {
                amg = new Amigo(Int32.Parse(aux[0].ToString()), Int32.Parse(aux[1].ToString()));
                lista.Add(amg);
            }
            return lista;
        }
        public List<Amigo> readAmigos(string nombre)
        {
            List<Amigo> lista = new List<Amigo>();
            Amigo amg = null;
            List<Object> lAmigo;
            lAmigo = DBBroker.obtenerAgente().leer("SELECT * FROM amigo WHERE Usuario_idUsuario IN(SELECT idUsuario from usuario where nombre='" + nombre+"') OR Usuario_idUsuario1 IN(SELECT idUsuario from usuario where nombre='"+nombre+"');");
            foreach (List<Object> aux in lAmigo)
            {
                amg = new Amigo(Int32.Parse(aux[0].ToString()), Int32.Parse(aux[1].ToString()));
                lista.Add(amg);
            }
            return lista;
        }
        public void insertAmigo(Amigo amigo)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Insert into amigo(Usuario_idUsuario,Usuario_idUsuario1) values ("+amigo.idUser1+","+amigo.idUser2+");");
        }

        public void deleteAmigo(Amigo amigo)
        {
            DBBroker dBBroker = DBBroker.obtenerAgente();
            dBBroker.modificar("Delete from amigo where (Usuario_idUsuario="+amigo.idUser1+" AND Usuario_idUsuario1="+amigo.idUser2+ ") OR (Usuario_idUsuario="+amigo.idUser2+" AND Usuario_idUsuario1="+amigo.idUser1+");");
        }
    }
}
