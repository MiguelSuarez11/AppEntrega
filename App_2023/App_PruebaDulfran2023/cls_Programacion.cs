using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_PruebaDulfran2023
{
    class cls_Programacion
    {
        private string str_fecha;
        private string str_Id_Docen;
        private string str_Id_Est;
        private string str_cod_Cur;

        public cls_Programacion(string fecha, string Id_Docen, string Id_Est, string cod_Cur)
        {
            this.str_fecha = fecha;
            this.str_Id_Docen = Id_Docen;
            this.str_Id_Est = Id_Est; 
            this.str_cod_Cur = cod_Cur;
        }
        public void setfecha(string fecha) { this.str_fecha = fecha; }
        public string getfecha() { return this.str_fecha;}
        public void setId_Docen(string Id_Docen) { this.str_Id_Docen = Id_Docen; }
        public string getId_Docen() { return this.str_Id_Docen; }
        public void setId_Est(string Id_Est) { this.str_Id_Est = Id_Est; }
        public string getId_Est() { return this.str_Id_Est; }
        public void setcod_Cur(string cod_Cur) { this.str_cod_Cur = cod_Cur; }
        public string getcod_Cur() { return this.str_cod_Cur; }
    }
}
