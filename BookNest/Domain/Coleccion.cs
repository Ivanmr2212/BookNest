using MyReads.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Coleccion
    {
        ColeccionManagement cm;
        public int idColeccion { get; set; }
        public string nombre { get; set; }
        public int idCreador{ get; set; }

        public Coleccion() { this.cm = new ColeccionManagement(); }

        public Coleccion(int id) { this.cm = new ColeccionManagement(); this.idColeccion = id; }

        public Coleccion(string nombre, int idCreador)
        {
            this.cm = new ColeccionManagement();
            this.nombre = nombre;
            this.idCreador = idCreador;
        }
        public int getId() { return idColeccion; }
        public String getNombre() { return nombre; }
        public int getIdCreador() { return idCreador; }
        public void setId(int id) { this.idColeccion = id; }
        public void setNombre(String nombre) { this.nombre = nombre; }
        public void setIdCreador(int id) { this.idCreador = id; }

        public Coleccion read(int id)
        {
            Coleccion u = null;
            u = cm.readColeccion(id);
            return u;
        }

        public List<Coleccion> readColeccionesUser(Usuario user)
        {
            List<Coleccion> list;
            list=cm.readColeccionesUsuario(user.id);
            return list;
        }
        public Coleccion readColeccionesUserYNombre(Usuario user, string nombre)
        {
            Coleccion colec;
            colec= cm.busquedaColeccionesNombreYIdUsuario(user, nombre);
            return colec;
        }
        public List<Coleccion> readColeccionesUserNoTodos(Usuario user)
        {
            List<Coleccion> lista=new List<Coleccion> ();
            lista = cm.readColeccionesUsuarioNoTodos(user.id);
            return lista;
        }
        public List<Coleccion> readColeccionesUserMenosDefault(int id)
        {
            List<Coleccion> lista;
            lista = cm.readColeccionesUsuarioMenosDefault(id);
            return lista;
        }
        public List<Coleccion> leerColeccionLibro(Libro l)
        {
            List<Coleccion> lista;
            lista = cm.readColeccionesConLibro(l);
            return lista;
        }

        public void insert()
        {
            cm.insertColeccion(this);
        }
        public void insertUsuarioColeccion(Usuario u)
        {
            cm.insertUsuarioColeccion(u,this);
        }

        public void delete()
        {
            cm.deleteColeccion(this);
        }
        public void deleteAllLibrosColeccion()
        {
            cm.deleteLibrosColeccion(this);
        }
        public void deleteUsuarioColeccion(Usuario u)
        {
            cm.deleteUsuarioColeccion(u,this);
        }

        override
        public string ToString()
        {
            string str = "."+this.nombre + ", IdCreador: " + this.idCreador;
            return str;
        }
    }
}
