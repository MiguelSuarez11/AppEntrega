using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_PruebaDulfran2023
{
    class cls_Calificaciones
    {
        private string str_ID_EC;
        private string str_FechaC;
        private string str_Notas;

        public cls_Calificaciones(string ID_EC, string FechaC, string Notas)
        {
            this.str_ID_EC = ID_EC;
            this.str_FechaC = FechaC;
            this.str_Notas = Notas;
        }
        public void setID_EC(string ID_EC) { this.str_ID_EC = ID_EC; }
        public string getID_EC() { return this.str_ID_EC; }
        public void setFechaC(string FechaC) { this.str_FechaC = FechaC; }
        public string getFechaC() { return this.str_FechaC; }
        public void setNotas(string Notas) { this.str_Notas = Notas; }
        public string getNotas() { return this.str_Notas; } 
    }
    }

