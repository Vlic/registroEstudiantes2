using System;
using System.Collections.Generic;

namespace registroEstudiantes2.Models
{
    public partial class Materias
    {
        public Materias()
        {
            Estudiantes = new HashSet<Estudiantes>();
        }

        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public int? Nivel { get; set; }

        public virtual ICollection<Estudiantes> Estudiantes { get; set; }
    }
}
