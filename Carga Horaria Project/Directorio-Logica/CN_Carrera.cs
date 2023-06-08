using Directorio_Datos;
using Directorio_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Entidades;
using System.Drawing;

namespace Directorio_Logica
{
    public class CN_Carrera
    {
        private DAL_Carrera objetoCData = new DAL_Carrera();
        private bool state = false;
        public DataTable MostrarCarreras()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistros();
            return tabla;
        }
        public DataTable MostrarDepartamentosNeg()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarDepartamentos();
            return tabla;
        }

        #region CRUD Methods
        public bool CreateCarreraNeg(string idDep, string nameCarrera, string codCarrera, string pensum)
        {
            try
            {
                ClsCarrera ObjCarrera = new ClsCarrera()
                {
                    IdDepartamento = Convert.ToInt32(idDep),
                    NombreCarrera = nameCarrera,
                    CodigoCarrera = codCarrera,
                    Pensum = pensum
                };
                objetoCData.CreateCarrera(ObjCarrera);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool UpdateCarreraNeg(string idCarrera, string idDep, string nameCarrera, string codCarrera, string pensum)
        {
            try
            {
                ClsCarrera ObjCarrera = new ClsCarrera()
                {
                    IdCarrera = Convert.ToInt32(idCarrera),
                    IdDepartamento = Convert.ToInt32(idDep),
                    NombreCarrera = nameCarrera,
                    CodigoCarrera = codCarrera,
                    Pensum = pensum,
                };
                objetoCData.UpdateCarrera(ObjCarrera);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteCarreraNeg(string idCarrera)
        {
            try
            {
                ClsCarrera ObjCarrera = new ClsCarrera()
                {
                    IdCarrera = Convert.ToInt32(idCarrera)
                };
                objetoCData.DeleteCarrera(ObjCarrera);

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
