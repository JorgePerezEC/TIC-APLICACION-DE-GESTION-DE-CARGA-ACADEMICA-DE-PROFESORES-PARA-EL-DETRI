using Directorio_Datos;
using Directorio_Entidades;
using System;
using System.Data;

namespace Directorio_Logica
{
    public class CN_TipoActividad
    {
        private DAL_TipoActividad objetoCData = new DAL_TipoActividad();


        public DataTable MostrarTiposActividadesLn()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistros();
            return tabla;
        }
        #region CRUD Methods
        public bool CreateTiposActividadN(string nameTpAct, string descripcion)
        {
            try
            {
                ClsTipoActividad ObjTpAct = new ClsTipoActividad()
                {
                    NombreTpActividad = nameTpAct,
                    DescripcionTpActividad = descripcion
                };
                objetoCData.CreateTipoActividad(ObjTpAct);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }

        public bool UpdateDepartamentoN(string idTpAct, string nameTpAct, string descripcion)
        {
            try
            {
                ClsTipoActividad ObjTpAct = new ClsTipoActividad()
                {
                    IdTipoActividad = Convert.ToInt32(idTpAct),
                    NombreTpActividad = nameTpAct,
                    DescripcionTpActividad = descripcion
                };
                //objetoCData.UpdateDepartamento(Convert.ToInt32(idDepa), nameDepartament, email);
                objetoCData.UpdateTipoActividad(ObjTpAct);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteDepartamentoN(string idTpAct, string nameTpAct, string descripcion)
        {
            try
            {
                ClsTipoActividad ObjTpAct = new ClsTipoActividad()
                {
                    IdTipoActividad = Convert.ToInt32(idTpAct),
                    NombreTpActividad = nameTpAct,
                    DescripcionTpActividad = descripcion
                };
                //objetoCData.DeleteDepartamento(Convert.ToInt32(idDepa), nameDepartament, email);
                objetoCData.DeleteTipoActividad(ObjTpAct);

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
