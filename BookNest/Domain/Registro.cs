using MyReads.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Registro
    {
        RegistroManagement nm;
        public int idRegistro { get; set; }
        public int idUsuario { get; set; }
        public int idLibro { get; set; }
        public string nombre {  get; set; }
        public int cantidad {  get; set; }

        public Registro() { this.nm = new RegistroManagement(); }

        public Registro(int id) { this.nm = new RegistroManagement(); this.idRegistro = id; }

        public Registro(int idU, int idL, string nombre, int cantidad)
        {
            this.nm = new RegistroManagement();
            this.idUsuario = idU;
            this.idLibro = idL;
            this.nombre= nombre;
            this.cantidad = cantidad;
        }
        public int getId() { return idRegistro; }
        public String getNombre() { return nombre; }
        public int getCantidad() { return cantidad; }
        public int getIdU() { return idUsuario; }
        public int getIdL() { return idLibro; }
        public void setIdN(int id) { this.idRegistro = id; }
        public void setNombre(String nombre) { this.nombre= nombre; }
        public void setIdU(int id) { this.idUsuario = id; }
        public void setIdL(int id) { this.idLibro = id; }
        public void setIdC(int cant) { this.cantidad = cant; }

        public Registro read(int id)
        {
            Registro u = null;
            u = nm.readRegistro(id);
            return u;
        }
        public void insert()
        {
            nm.insertRegistro(this);
        }

        public void delete()
        {
            nm.deleteRegistro(this);
        }

        override
        public string ToString()
        {
            string str = "Registro. Nombre: " + this.nombre+ ", IdU: " + this.idUsuario+ ", IdL: " + this.idLibro+ ", Cantidad: " + this.cantidad;
            return str;
        }
    }
}
