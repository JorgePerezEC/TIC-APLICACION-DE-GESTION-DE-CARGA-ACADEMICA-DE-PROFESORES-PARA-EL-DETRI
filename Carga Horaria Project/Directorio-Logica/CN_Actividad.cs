using Directorio_Datos;
using Directorio_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio_Logica
{
    public class CN_Actividad
    {
        private DAL_Actividad objetoCData = new DAL_Actividad();
        private bool state = false;

        #region LOAD DATA METHODS
        public DataTable MostrarActividadesNeg()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistros();
            return tabla;
        }
        public DataTable MostrarTpActividadesNeg()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarTpActividades();
            return tabla;
        }
        public DataTable GetGestionActivities_Negocio()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.GetActividadesGestionDAL();
            return tabla;
        }
        public DataTable GetDocenciaD11Activities_Negocio()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.GetActividadesDocenciaD11DAL();
            return tabla;
        }
        public DataTable GetDocenciaF11Activities_Negocio()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.GetActividadesDocenciaF11DAL();
            return tabla;
        }
        public DataTable GetInvestigacionActivities_Negocio()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.GetActividadesInvestigacionDAL();
            return tabla;
        }
        //ssssss
        public DataTable GetAllActivities_Negocio(string idCarga, string type)
        {
            DataTable tabla = new DataTable();
            ClsCargaHoraria ObjCargaH = new ClsCargaHoraria()
            {
                IdCargaHoraria = Convert.ToInt32(idCarga)
            };
            ClsTipoActividad ObjTpActividad = new ClsTipoActividad()
            {
                NombreTpActividad = type
            };
            tabla = objetoCData.GetAllActividadesGralDAL(ObjCargaH, ObjTpActividad);
            return tabla;
        }
        public int GetHorasActividadNegocio(string idActividad)
        {
            ClsActividad ObjActividad = new ClsActividad()
            {
                IdActividad = Convert.ToInt32(idActividad)
            };
            int horasActividad = objetoCData.GetHorasActividadDAL(ObjActividad);
            return horasActividad;
        }
        public int GetHorasTotalesActividadNegocio(string idActividad)
        {
            ClsActividad ObjActividad = new ClsActividad()
            {
                IdActividad = Convert.ToInt32(idActividad)
            };
            int horasTotalesActividad = objetoCData.GetHorasTotalesActividadDAL(ObjActividad);
            return horasTotalesActividad;
        }
        #endregion

        #region CRUD Methods
        public bool CreateActividadNeg(string idTpAct, int idProyecto, string nameActividad, string horasSemanal, string horasTotales)
        {
            try
            {
             
                ClsActividad ObjActividad = new ClsActividad()
                {
                    IdTpActividad = Convert.ToInt32(idTpAct),
                    NombreActividad = nameActividad,
                    HorasSemana = Convert.ToInt32(horasSemanal),
                    HorasTotalesAct = Convert.ToInt32(horasTotales)
                };

                ClsProyecto ObjProyecto = new ClsProyecto()
                {
                    IdProyecto = idProyecto
                };
                objetoCData.CreateActividad(ObjActividad, ObjProyecto);

                return true;

            }
            catch (FormatException ex)
            {
                string variableConError = GetVariableConError(idTpAct, horasSemanal, horasTotales); // Reemplaza esto por la lógica real para identificar la variable
                MessageBox.Show($"Error de formato en la variable '{variableConError}': {ex.Message}", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        private string GetVariableConError(string idTpAct, string horasSemanal, string horasTotales)
        {
            if (!int.TryParse(idTpAct, out _))
            {
                return "idTpAct";
            }
            else if (!int.TryParse(horasSemanal, out _))
            {
                return "horasSemanal";
            }
            else if (!int.TryParse(horasTotales, out _))
            {
                return "horasTotales";
            }
            else
            {
                return "Variable desconocida";
            }
        }

        public bool UpdateActividadNeg(string idActividad, int idProyecto, string idTpAct, string nameActividad, string horasSemanal, string horasTotales)
        {
            try
            {
                ClsActividad ObjActividad = new ClsActividad()
                {
                    IdActividad = Convert.ToInt32(idActividad),
                    IdTpActividad = Convert.ToInt32(idTpAct),
                    NombreActividad = nameActividad,
                    HorasSemana = Convert.ToInt32(horasSemanal),
                    HorasTotalesAct = Convert.ToInt32(horasTotales)
                };
                ClsProyecto ObjProyecto = new ClsProyecto()
                {
                    IdProyecto = idProyecto
                };
                objetoCData.UpdateActividad(ObjActividad, ObjProyecto);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteActividadNeg(string idActividad)
        {
            try
            {
                ClsActividad ObjActividad = new ClsActividad()
                {
                    IdActividad = Convert.ToInt32(idActividad)
                };
                objetoCData.DeleteActividad(ObjActividad);

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
