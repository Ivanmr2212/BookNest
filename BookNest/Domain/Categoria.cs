using MyReads.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Categoria
    {
        CategoriaManagement cm;
        public int idCategoria { get; set; }
        public string nombre { get; set; }
        public string desc { get; set; }
        public int idUsuario { get; set; }

        public Categoria() { this.cm = new CategoriaManagement(); }

        public Categoria(int id) { this.cm = new CategoriaManagement(); this.idCategoria = id; }

        public Categoria(string nombre, string desc, int id)
        {
            this.cm = new CategoriaManagement();
            this.nombre = nombre;
            this.desc = desc;
            this.idUsuario = id;
        }
        public int getIdCategoria() { return idCategoria; }
        public String getNombre() { return nombre; }
        public String getDesc() { return desc; }
        public int getIdUsuario() { return idUsuario; }
        public void setIdCategoria(int id) { this.idCategoria = id; }
        public void setNombre(String nombre) { this.nombre = nombre; }
        public void setDesc(String desc) { this.desc = desc; }
        public void setIdUsuario(int id) { this.idUsuario= id; }

        public Categoria read(int id)
        {
            Categoria u = null;
            u = cm.readCategoria(id);
            return u;
        }
        public Categoria readByUserYNombre(Usuario user, String nombre)
        {
            Categoria u = null;
            u = cm.readCategoriaByUserYNombre(user.id,nombre);
            return u;
        }
        public List<Categoria> readCategoriasUsuario(Usuario us)
        {
            List<Categoria> lista = new List<Categoria>();
            lista = cm.readCategoriasUsuario(us.id);
            return lista;
        }
        public List<Categoria> readAll()
        {
            List<Categoria> lista = new List<Categoria> ();
            lista = cm.readAll();
            return lista;
        }
        public void insert()
        {
            cm.insertCategoria(this);
        }

        public void delete()
        {
            cm.deleteCategoria(this);
        }

        override
        public string ToString()
        {
            string str = "Categoria. Nombre: " + this.nombre + ", Desc: " + this.desc;
            return str;
        }
    }
}
