using MyReads.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Usuario
    {
        UsuarioManagement um;
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo {  get; set; }
        public string pass { get; set; }
        public string img {  get; set; }

        public Usuario() { this.um = new UsuarioManagement(); }
        public Usuario(int id) { this.um = new UsuarioManagement(); this.id = id; }

        public Usuario(string nombre, string correo,string pass)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.pass = pass;
            this.um = new UsuarioManagement();
        }
        public int getId() { return id; }
        public String getNombre() { return nombre; }
        public String getCorreo() { return correo; }
        public String getPass() { return pass; }
        public String getImg() { return img; }
        public void setId(int id) { this.id = id; }
        public void setNombre(String nombre) { this.nombre = nombre; }
        public void setCorreo(String correo) { this.correo = correo; }
        public void setPass(String pass) { this.pass= pass; }
        public void setImg(String img) { this.img= img; }

        public void updatePass()
        {
            um.updatePass(this);
        }
        public void updateImg()
        {
            um.updateImg(this);
        }

        public Usuario read(int id)
        {
            Usuario u = null;
            u = um.readUsuario(id);
            return u;
        }
        public List<Usuario> readAll()
        {
            List<Usuario> list = null;
            list = um.readAll();
            return list;
        }
        public List<Usuario> readAllMenosUno(Usuario user)
        {
            List<Usuario> list = null;
            list = um.readAllMenosUno(user);
            return list;
        }

        public Usuario readByNombre(String nombre)
        {
            Usuario u = null;
            u = um.readUsuarioByNombre(nombre);
            return u;
        }

        public Usuario readByNombreYCorreo(String nombre)
        {
            Usuario u = null;
            u = um.readUsuarioByNombreYCorreo(nombre);
            return u;
        }
        public Usuario readByCorreo(String correo)
        {
            Usuario u = null;
            u = um.readUsuarioByCorreo(correo);
            return u;
        }

        public void insert()
        {
            um.insertUsuario(this);
        }

        public void delete()
        {
            um.deleteUsuario(this);
        }

        public List<Amigo> readAllAmigos()
        {
            List<Amigo> lista = new List<Amigo>();
            lista = um.readAmigos(nombre);
            return lista;
        }
        public List<Amigo> readAmigos(String nombre)
        {
            List<Amigo> lista = new List<Amigo>();
            lista=um.readAmigos(nombre);
            return lista;
        }
        public void insertAmigo(Amigo amigo)
        {
            um.insertAmigo(amigo);
        }
        public void deleteAmigo(Amigo amigo)
        {
            um.deleteAmigo(amigo);
        }

        override
        public String ToString()
        {
            String str="Usuario. Nombre: "+this.nombre+", Correo: "+this.correo+", Password: "+this.pass;
            return str;
        }
    }
}
