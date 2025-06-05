using MyReads.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Libro
    {
        LibroManagement lm;
        public int idLibro { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string sinopsis { get; set; }
        public string editorial { get; set; }
        public int numPags{ get; set; }
        public int year {  get; set; }
        public string img {  get; set; }
        public int idGenero {  get; set; }

        public Libro() { this.lm = new LibroManagement(); }

        public Libro(int id) { this.lm = new LibroManagement(); this.idLibro = id; }

        public Libro(string titulo, string autor, string sinopsis, string editorial, int pags, int year, int idGenero)
        {
            this.lm = new LibroManagement();
            this.titulo = titulo;
            this.autor = autor;
            this.sinopsis = sinopsis;
            this.editorial = editorial;
            this.numPags = pags;
            this.year = year;
            this.idGenero = idGenero;
        }
        public Libro(string titulo, string autor, string sinopsis, string editorial, int pags, int year, int idGenero, String img)
        {
            this.lm = new LibroManagement();
            this.titulo = titulo;
            this.autor = autor;
            this.sinopsis = sinopsis;
            this.editorial = editorial;
            this.numPags = pags;
            this.year = year;
            this.idGenero = idGenero;
            this.img = img;
        }
        public int getId() { return idLibro; }
        public String getTitulo() { return titulo; }
        public String getAutor() { return autor; }
        public String getSinopsis() { return sinopsis; }
        public String getEditorial() { return editorial; }
        public int getPags() { return numPags; }
        public int getYear() { return year; }
        public String getImg() { return img; }
        public int getIdGenero() { return idGenero; }
        public void setId(int id) { this.idLibro= id; }
        public void setTitulo(String titulo) { this.titulo= titulo; }
        public void setAutor(String autor) { this.autor = autor; }
        public void setSinopsis(String sin) { this.sinopsis = sin; }
        public void setEditorial(String ed) { this.editorial = ed; }
        public void setPags(int p) { this.numPags= p; }
        public void setYear(int y) { this.year= y; }
        public void setImg(String img) { this.img = img; }
        public void setIdGenero(int idG) { this.idGenero = idG; }


        public Libro read(int id)
        {
            Libro u = null;
            u = lm.readLibro(id);
            return u;
        }
        public Libro readByTitulo(String titulo)
        {
            Libro u = null;
            u = lm.readLibroByNombre(titulo);
            return u;
        }
        public List<Libro> readAll()
        {
            List<Libro> list=new List<Libro> ();
            list = lm.readAll();
            return list;
        }
        public List<Libro> readByGenero(String nombre)
        {
            List<Libro> list = new List<Libro>();
            list = lm.readByGenero(nombre);
            return list;
        }
        public void insert()
        {
            lm.insertLibro(this);
        }

        public void delete()
        {
            lm.deleteLibro(this);
        }

        public List<Libro> leerLibrosColeccion(Coleccion c)
        {
            List<Libro> lista;
            lista = lm.leerLibrosColeccion(c);
            return lista;
        }
        
        public void insertarLibroEnColeccion(Libro l, Coleccion c)
        {
            lm.insertarLibroColeccion(l, c);
        }
        public void deleteLibroColeccion(Libro l,Coleccion c)
        {
            lm.deleteLibroColeccion(l,c);
        }

        public void generarTodos()
        {
            lm.generarLibros();
        }

        override
        public string ToString()
        {
            string str = "Libro. Titulo: " + this.titulo+ ", Autor: " + this.autor+", Ed: "+this.editorial+", NumPags: "+this.numPags+", Publicacion: "+this.year+", IdGenero: "+this.idGenero;
            return str;
        }
    }
}
