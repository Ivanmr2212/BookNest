using MyReads.Persistance;
using MyReads.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Frase
    {
        FraseManagement fm;
        public int idFrase { get; set; }
        public string contenido { get; set; }

        public Frase() { this.fm = new FraseManagement(); }

        public Frase(int id) { this.fm = new FraseManagement(); this.idFrase = id; }

        public Frase(string contenido)
        {
            this.fm = new FraseManagement();
            this.contenido = contenido;
        }
        public int getIdFrase() { return idFrase; }
        public String getContenido() { return contenido; }
        public void setIdFrase(int id) { this.idFrase= id; }
        public void setContenido(String contenido) { this.contenido= contenido; }

        public Frase read(int id)
        {
            Frase u = null;
            u = fm.readFrase(id);
            return u;
        }
        public List<Frase> readAll()
        {
            List<Frase> lista = new List<Frase>();
            lista = fm.readAll();
            return lista;
        }
        public void insert()
        {
            fm.insertFrase(this);
        }

        public void delete()
        {
            fm.deleteFrase(this);
        }

        override
        public string ToString()
        {
            string str = contenido;
            return str;
        }
    }
}
