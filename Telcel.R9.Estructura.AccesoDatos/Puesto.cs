using System;
using System.Collections.Generic;

namespace Telcel.R9.Estructura.AccesoDatos
{
    public partial class Puesto
    {
        public Puesto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdPuesto { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
