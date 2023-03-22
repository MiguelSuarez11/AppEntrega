using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_PruebaDulfran2023
{
    class cls_Anotaciones
    {
        private string str_ID_EA;
        private string str_FechaA;
        private string str_Anotaciones;

        public cls_Anotaciones(string ID_EA, string FechaA, string Anotaciones)
        {
            this.str_ID_EA = ID_EA;
            this.str_FechaA = FechaA;
            this.str_Anotaciones = Anotaciones;
        }
        public void setID_EA(string ID_EA) { this.str_ID_EA = ID_EA; }
        public string getID_EA() { return this.str_ID_EA; }
        public void setFechaA(string FechaA) { this.str_FechaA = FechaA; }
        public string getFechaA() { return this.str_FechaA; }
        public void setAnotaciones(string Anotaciones) { this.str_ID_EA = Anotaciones; }
        public string getAnotaciones() { return this.str_Anotaciones; }
    }
}
