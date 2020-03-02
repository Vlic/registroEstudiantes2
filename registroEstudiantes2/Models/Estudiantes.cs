using System;
using System.Collections.Generic;

namespace registroEstudiantes2.Models
{
    public partial class Estudiantes
    {
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int? IdMateria { get; set; }

        public virtual Materias IdMateriaNavigation { get; set; }
    }
}
