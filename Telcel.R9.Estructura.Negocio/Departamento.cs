using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura.Negocio
{
    public class Departamento
    {
        //Comienza clase ML - Propiedades de la clase
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public List<object> Departamentos { get; set; }


        //Comienza clase BL - Metodos de la clase

        public static Negocio.Result GetAll()
        {
            Negocio.Result result = new Negocio.Result();

            try
            {
                using (AccesoDatos.ATranquilinoEstructuraContext context = new AccesoDatos.ATranquilinoEstructuraContext())
                {
                    var procedure = context.Departamentos.FromSqlRaw("DepartamentoGetAll").ToList();
                    result.Objects = new List<object>();

                    if (procedure != null)
                    {
                        foreach (var obj in procedure)
                        {
                            Negocio.Departamento departamento = new Negocio.Departamento();
                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Nombre;
                            result.Objects.Add(departamento);
                        }
                    }
                    else
                    {
                        result.Correct = false;
                    }
                    result.Correct = true;
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
