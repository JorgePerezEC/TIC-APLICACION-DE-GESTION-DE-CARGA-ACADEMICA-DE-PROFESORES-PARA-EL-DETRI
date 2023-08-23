using Directorio_Datos;
using Directorio_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Directorio_Logica
{
    public class CN_Proyecto
    {
        private DAL_Proyecto objetoCData = new DAL_Proyecto();
        public DataTable MostrarRegistros()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistros();
            return tabla;
        }

        public DataTable GetProjectInfo_Negocio(int idActividad)
        {
            ClsActividad ObjActividad = new ClsActividad()
            {
                IdActividad= idActividad,
            };
            DataTable tabla = new DataTable();
            tabla = objetoCData.GetProjectInfo_DAL(ObjActividad);
            return tabla;
        }

        #region CRUD Methods
        public bool CreateProyecto_Negocio(string code, string nombreProyecto, string dateIni, string dateEnd, decimal presupuesto, string tipo, string url)
        {
            try
            {
                var dateI = DateTime.Parse(dateIni);
                var dateF = DateTime.Parse(dateEnd);

                ClsProyecto ObjProyecto = new ClsProyecto()
                {
                    Codigo = code,
                    NombreProyecto = nombreProyecto,
                    DiaInicio = DateOnly.FromDateTime(dateI),
                    DiaFin = DateOnly.FromDateTime(dateF),
                    Presupuesto = presupuesto,
                    Tipo = tipo,
                    Url = url
                };
                objetoCData.CreateProyecto(ObjProyecto);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool UpdateProyecto_Negocio(string id, string code, string nombreProyecto, string dateIni, string dateEnd, decimal presupuesto, string tipo, string url)
        {
            try
            {
                var dateI = DateTime.Parse(dateIni);
                var dateF = DateTime.Parse(dateEnd);

                ClsProyecto ObjProyecto = new ClsProyecto()
                {
                    IdProyecto = Convert.ToInt32(id),
                    Codigo = code,
                    NombreProyecto = nombreProyecto,
                    DiaInicio = DateOnly.FromDateTime(dateI),
                    DiaFin = DateOnly.FromDateTime(dateF),
                    Presupuesto = presupuesto,
                    Tipo = tipo,
                    Url = url
                };

                objetoCData.UpdateProyecto(ObjProyecto);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteProyecto_Negocio(string id)
        {
            try
            {
                ClsProyecto ObjProyecto = new ClsProyecto()
                {
                    IdProyecto = Convert.ToInt32(id)
                };
                objetoCData.DeleteProyecto(ObjProyecto);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        #endregion
    }
}
