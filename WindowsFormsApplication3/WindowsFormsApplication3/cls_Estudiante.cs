using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class cls_Estudiantes
    {
        private string str_id;
        private string str_nombres;
        private string str_apellidos;
        private string str_Contacto;
        private string str_Correo;
        private string str_rutaFoto;

        public cls_Estudiantes(
            string id, string n, string a, string cot, string corr, string rfot)
        {
            this.str_id = id;
            this.str_nombres = n;
            this.str_apellidos = a;
            this.str_Contacto = cot;
            this.str_Correo = corr;
            this.str_rutaFoto = rfot;
        }
        public void setID(string id) { this.str_id = id; }
        public string getID() { return this.str_id; }
        public void setNombres(string nombres) { this.str_nombres = nombres; }
        public string getNombres() { return this.str_nombres; }
        public void setApellidos(string apellidos) { this.str_apellidos = apellidos; }
        public string getApellidos() { return this.str_apellidos; }
        public void setContacto(string contacto) { this.str_Contacto = contacto; }
        public string getContacto() { return this.str_Contacto; }
        public void setCorreo(string correo) { this.str_Correo = correo; }
        public string getCorreo() { return this.str_Correo; }
        public void setFoto(string foto) { this.str_rutaFoto = foto; }
        public string getFoto() { return this.str_rutaFoto; }
    }
}
