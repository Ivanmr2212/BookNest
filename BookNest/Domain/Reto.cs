using MyReads.Persistance;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Reto
    {
        RetoManagement rm;
        public int Id { get; set; }
        public int leido {  get; set; }
        public int total { get; set; }
        public string fechaInicio {  get; set; }
        public string fechaFin{ get; set; }
        public int idUsuario {  get; set; }
        public bool completado { get; set; }

        public Reto()
        {
            rm=new RetoManagement();
        }
        public Reto(int id)
        {
            this.Id=id;
            rm = new RetoManagement();
        }
        public Reto(int leido, int total, string inicio, string final, int idUser, bool completado)
        {
            this.leido = leido;
            this.total = total;
            this.fechaInicio = inicio;
            this.fechaFin = final;
            this.idUsuario = idUser;
            this.completado = completado;
        }

        public int getId() { return Id; }
        public int getLeido() { return leido; }
        public int getTotal() { return total; }
        public String getInicio() { return fechaInicio; }
        public String getFin() { return fechaFin; }
        public int getIdUser() { return idUsuario; }
        public bool getComp() { return completado; }
        public void setId(int id) { this.Id = id; }
        public void setLeido(int leido) { this.leido= leido; }
        public void setTotal(int tot) { this.total= tot; }
        public void setInicio(String fecha) { this.fechaInicio= fecha; }
        public void setFin(String fecha) { this.fechaFin = fecha; }
        public void setIdU(int id) { this.idUsuario = id; }
        public void setComp(bool valor) { this.completado=valor; }

        public void insert()
        {
            rm.insertReto(this);
        }
        public void delete()
        {
            rm.deleteReto(this);
        }
        public void actualizar()
        {
            rm.actualizarReto(this);
        }
        public void sumar1Leido()
        {
            rm.sumar1Reto(this);
        }
        public void actualizarComp()
        {
            rm.actualizarCompletado(this);
        }
        public Reto read(int id)
        {
            Reto r = new Reto();
            r=rm.readReto(id);
            return r;
        }
        public Reto readNoComp(Usuario user)
        {
            Reto r = new Reto();
            r = rm.readRetoNoComp(user);
            return r;
        }
        public List<Reto> readAllUser(Usuario user)
        {
            List<Reto> list = new List<Reto>();
            list = rm.readAllRetosUser(user);
            return list;
        }
    }
}
