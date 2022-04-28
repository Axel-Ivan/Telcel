using System;
using System.Collections.Generic;

namespace Telcel.R9.Estructura.AccesoDatos
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public int? IdPuesto { get; set; }
        public int? IdDepartamento { get; set; }

        public virtual Departamento? IdDepartamentoNavigation { get; set; }
        public virtual Puesto? IdPuestoNavigation { get; set; }

        public string PuestoNombre { get; set; } = null;
        public string DepartamentoNombre { get; set; } = null;
    }
}
