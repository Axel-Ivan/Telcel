using Microsoft.EntityFrameworkCore;

namespace Telcel.R9.Estructura.Negocio
{
    public class Empleado
    {
        // Inicia capa ML - Propiedades de la clase
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public List<object> Empleados { get; set; }
        public Negocio.Puesto Puesto { get; set; }
        public Negocio.Departamento Departamento { get; set; }


        // Inicia capa BL - Métodos de la clase
        public static Negocio.Result GetAll(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            Negocio.Result result = new Negocio.Result();

            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.ATranquilinoEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.ATranquilinoEstructuraContext())
                {
                    var procedure = context.Empleados.FromSqlRaw($"EmpleadoGetAll '{nombre}', '{apellidoPaterno}', '{apellidoMaterno}'").ToList();
                    result.Objects = new List<object>();

                    if (procedure != null)
                    {
                        foreach (var obj in procedure)
                        {
                            Negocio.Empleado empleado = new Negocio.Empleado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Puesto = new Negocio.Puesto();
                            empleado.Puesto.IdPuesto = obj.IdPuesto.Value;
                            empleado.Puesto.Nombre = obj.PuestoNombre;
                            empleado.Departamento = new Negocio.Departamento();
                            empleado.Departamento.IdDepartamento = obj.IdDepartamento.Value;
                            empleado.Departamento.Nombre = obj.DepartamentoNombre;
                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static Negocio.Result GetById(int IdEmpleado)
        {
            Negocio.Result result = new Negocio.Result();

            try
            {
                using (AccesoDatos.ATranquilinoEstructuraContext context = new AccesoDatos.ATranquilinoEstructuraContext())
                {
                    var procedure = context.Empleados.FromSqlRaw($"EmpleadoGetById {IdEmpleado}").AsEnumerable().FirstOrDefault();
                    result.Objects = new List<object>();

                    if (procedure != null)
                    {
                        Negocio.Empleado empleado = new Empleado();
                        empleado.IdEmpleado = procedure.IdEmpleado;
                        empleado.Nombre = procedure.Nombre;
                        empleado.ApellidoPaterno = procedure.ApellidoPaterno;
                        empleado.ApellidoMaterno = procedure.ApellidoMaterno;
                        empleado.Puesto = new Negocio.Puesto();
                        empleado.Puesto.IdPuesto = procedure.IdPuesto.Value;
                        empleado.Puesto.Nombre = procedure.PuestoNombre;
                        empleado.Departamento = new Negocio.Departamento();
                        empleado.Departamento.IdDepartamento = procedure.IdDepartamento.Value;
                        empleado.Departamento.Nombre = procedure.DepartamentoNombre;

                        result.Object = empleado;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static Negocio.Result Add(Negocio.Empleado empleado)
        {
            Negocio.Result result = new Negocio.Result();

            try
            {
                using (AccesoDatos.ATranquilinoEstructuraContext context = new AccesoDatos.ATranquilinoEstructuraContext())
                {
                    var procedure = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.Nombre}', '{empleado.ApellidoPaterno}', '{empleado.ApellidoMaterno}', '{empleado.Puesto.IdPuesto}', '{empleado.Departamento.IdDepartamento}'");

                    if(procedure >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static Negocio.Result Delete(int IdEmpleado)
        {
            Negocio.Result result = new Negocio.Result();

            try
            {
                using (AccesoDatos.ATranquilinoEstructuraContext context = new AccesoDatos.ATranquilinoEstructuraContext())
                {
                    var procedure = context.Database.ExecuteSqlRaw($"EmpleadoDelete {IdEmpleado}");

                    if(procedure >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

    }
}