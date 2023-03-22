    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_PruebaDulfran2023
{
    class cls_Docentes
    {
        private string str_IdDoc;
        private string str_NombresDoc;
        private string str_ContactoDoc;
        private string str_CorreoDoc;


        public cls_Docentes(string IdDoc, string NomDoc, string ContDoc, string corrDoc)
        {
            this.str_IdDoc = IdDoc;
            this.str_NombresDoc = NomDoc;
            this.str_ContactoDoc = ContDoc;
            this.str_CorreoDoc = corrDoc;
        }
        public void setIdDoc(string IdDoc) { this.str_IdDoc = IdDoc; }
        public string getIdDoc() { return this.str_IdDoc; }
        public void setNombresDoc(string nomDoc) { this.str_NombresDoc = nomDoc; }
        public string getNombresDoc() { return this.str_NombresDoc; }
        public void setContactoDoc(string contactoDoc) { this.str_ContactoDoc = contactoDoc; }
        public string getContactoDoc() { return this.str_ContactoDoc; }
        public void setCorreoDoc(string correoDoc) { this.str_CorreoDoc = correoDoc; }
        public string getCorreoDoc() { return this.str_CorreoDoc; } 
       
    }
}
