using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura.Negocio
{
    public class Puesto
    {
        // Comienza capa ML - Propiedades de la clase
        public int IdPuesto { get; set; }
        public string Nombre { get; set; }
        public List<object> Puestos { get; set; }



        // Comienza clase BL - Métodos de la clase

        public static Negocio.Result GetAll()
        {
            Negocio.Result result = new Negocio.Result();

            try
            {
                using(AccesoDatos.ATranquilinoEstructuraContext context = new AccesoDatos.ATranquilinoEstructuraContext())
                {
                    var procedure = context.Puestos.FromSqlRaw("PuestoGetAll").ToList();
                    result.Objects = new List<object>();

                    if(procedure != null)
                    {
                        foreach(var obj in procedure)
                        {
                            Negocio.Puesto puesto = new Negocio.Puesto();
                            puesto.IdPuesto = obj.IdPuesto;
                            puesto.Nombre = obj.Nombre;
                            result.Objects.Add(puesto);
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
