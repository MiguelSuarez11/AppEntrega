using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_PruebaDulfran2023
{
    class cls_Cursos
    {
        private string str_Codigo;
        private string str_NombreCur;
        private string str_Creditos;
        private string str_Valor;
        private string str_Horario;
        
        public cls_Cursos(string Codigo, string NombreCur ,string Creditos ,string Valor , string Horario)
        {
            this.str_Codigo = Codigo;
            this.str_NombreCur = NombreCur;
            this.str_Creditos = Creditos;
            this.str_Valor = Valor;
            this.str_Horario = Horario;
        }
        public void setCodigo(string Codigo) { this.str_Codigo = Codigo; }
        public string getCodigo() { return this.str_Codigo; }
        public void setNombreCur(string NombreCur) { this.str_NombreCur = NombreCur; }
        public string getNombreCur() { return this.str_NombreCur; }
        public void setCreditos(string Creditos) { this.str_Creditos = Creditos; }
        public string getCreditos() { return this.str_Creditos; }
        public void setValor(string Valor) { this.str_Valor = Valor; }
        public string getValor() { return this.str_Valor; }
        public void setHorario(string Horario) { this.str_Horario = Horario; }
        public string getHorario() { return this.str_Horario; }
    }
}
