using MyReads.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Nota
    {
        NotaManagement nm;
        public int idNota { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }
        public string fecha { get; set; }
        public int idUsuario { get; set; }
        public int idCategoria { get; set; }
        public int idLibro { get; set; }

        public Nota() { this.nm = new NotaManagement(); }

        public Nota(int id) { this.nm = new NotaManagement(); this.idNota = id; }

        public Nota(string titulo, string texto, string fecha, int idU, int idL, int idC)
        {
            this.nm = new NotaManagement();
            this.titulo = titulo;
            this.texto= texto;
            this.fecha = fecha;
            this.idUsuario = idU;
            this.idLibro = idL;
            this.idCategoria = idC;
        }
        public int getId() { return idNota; }
        public String getTitulo() { return titulo; }
        public String getTexto() { return texto; }
        public String getFecha() { return fecha; }
        public int getIdU() { return idUsuario; }
        public int getIdL() { return idLibro; }
        public int getIdC() { return idCategoria; }
        public void setIdN(int id) { this.idNota = id; }
        public void setTitulo(String titulo) { this.titulo= titulo; }
        public void setTexto(String texto) { this.texto= texto; }
        public void setFecha(String fecha) { this.fecha= fecha; }
        public void setIdU(int id) { this.idUsuario= id; }
        public void setIdL(int id) { this.idLibro = id; }
        public void setIdC(int id) { this.idCategoria = id; }

        public Nota read(int id)
        {
            Nota u = null;
            u = nm.readNota(id);
            return u;
        }
        public List<Nota> readNotasUsuarioYLibro(Usuario user,Libro libro)
        {
            List<Nota> lista = new List<Nota>();
            lista = nm.readNotasByUserLibro(user,libro);
            return lista;
        }
        public Categoria readCategoria(Nota nota)
        {
            Categoria categoria = null;
            categoria=nm.readCategoria(nota);
            return categoria;
        }
        public void insert()
        {
            nm.insertNota(this);
        }

        public void delete()
        {
            nm.deleteNota(this);
        }
        public void modificar()
        {
            nm.modificarNota(this);
        }

        override
        public string ToString()
        {
            string str = "Nota. Titulo: " + this.titulo+ ", Texto: " + this.texto+", Usuario: "+this.idUsuario+", Libro: "+this.idLibro+", Categoria: "+this.idCategoria;
            return str;
        }
    }
}
