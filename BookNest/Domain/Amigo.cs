using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReads.Domain
{
    public class Amigo
    {
        public int idUser1 {  get; set; }
        public int idUser2 { get; set; }

        public Amigo(int id1, int id2)
        {
            idUser1=id1;
            idUser2=id2;
        }
        public int getId1() { return idUser2; }
        public int getId2() { return idUser2; }
        public void setIdUser1(int id) { this.idUser1 = id; }
        public void setIdUser2(int id) { this.idUser2 = id; }
    }
}
