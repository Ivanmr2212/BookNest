using MyReads.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Genero
    {
        GeneroManagement gm;
        public int idGenero { get; set; }
        public string nombre { get; set; }
        public string desc { get; set; }

        public Genero() { this.gm = new GeneroManagement(); }

        public Genero(int id) { this.gm = new GeneroManagement(); this.idGenero = id; }

        public Genero(string nombre, string desc)
        {
            this.gm = new GeneroManagement();
            this.nombre = nombre;
            this.desc = desc;
        }
        public int getId() { return idGenero; }
        public String getNombre() { return nombre; }
        public String getDesc() { return desc; }
        public void setId(int id) { this.idGenero = id; }
        public void setNombre(String nombre) { this.nombre = nombre; }
        public void setDesc(String desc) { this.desc = desc; }

        public Genero read(int id)
        {
            Genero u = null;
            u = gm.readGenero(id);
            return u;
        }
        public List<Genero> readAll()
        {
            List<Genero> list = new List<Genero>();
            list = gm.readAll();
            return list;
        }
        public void insert()
        {
            gm.insertGenero(this);
        }

        public void delete()
        {
            gm.deleteGenero(this);
        }
        public void crearGeneros()
        {
            Genero g = new Genero("Fantasia", "Género literario que presenta mundos, seres y eventos sobrenaturales o mágicos que no siguen las leyes de la realidad.\nPuede incluir criaturas mitológicas, magia,, reinos y aventuras épicas");
            Genero g2 = new Genero("Thriller", "Género literario que se caracteriza por generar tensión y suspense en el lector.\nEl objetivo es mantener al lector expectante y preocupado por lo que le ocurrirá a los personajes. ");
            Genero g3 = new Genero("Ciencia ficción", "Género literario que se basa en la especulación racional sobre el impacto de avances científicos o sociales en la sociedad.\nSe desarrolla en escenarios imaginarios y diferentes a los de la realidad. ");
            Genero g4 = new Genero("Histórico", "Género narrativo que recrea un periodo histórico a través de la ficción");
            Genero g5 = new Genero("Terror", "Género que busca provocar miedo o terror en el lector.\nTambién se le conoce como literatura de horror o gótica. ");
            Genero g6 = new Genero("Romance", "Género literario que se caracteriza por retratar argumentos construidos de eventos y personajes relacionados con la expresión del amor y las relaciones románticas.");
            Genero g7 = new Genero("Drama", "Género literario que se caracteriza por narrar historias a través de los diálogos entre personajes, con el objetivo de ser representado en escena.");
            Genero g8 = new Genero("Distopia", "Género literario que se caracteriza por representar una sociedad futura con características negativas. En este tipo de obras, los personajes suelen luchar contra la opresión de la sociedad.");
            Genero g9 = new Genero("Realismo mágico", " Género literario y pictórico que se caracteriza por mostrar lo extraño o irreal como algo cotidiano.");
            Genero g10 = new Genero("Aventura", "Ggénero literario de aventuras es un relato que narra las hazañas de un personaje que se enfrenta a situaciones peligrosas o emocionantes. Las aventuras pueden ser físicas, emocionales o personales.");
            g.insert(); g2.insert(); g3.insert(); g4.insert(); g5.insert(); g6.insert(); g7.insert(); g8.insert(); g9.insert(); g10.insert();
        }

        override
        public string ToString()
        {
            string str = "Genero. Nombre: " + this.nombre + ", Desc: " + this.desc;
            return str;
        }
    }
}
