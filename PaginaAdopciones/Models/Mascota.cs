using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaAdopciones.Models
{
    public class Mascota
    {

        public int idMascota { get; }

        public string Nombre { get; set; }

        public int Edad { get; set; }

        public string Descrip { get; set; }

        public string Correo { get; set; }

        public bool Adoptado { get; set; }
    }

}