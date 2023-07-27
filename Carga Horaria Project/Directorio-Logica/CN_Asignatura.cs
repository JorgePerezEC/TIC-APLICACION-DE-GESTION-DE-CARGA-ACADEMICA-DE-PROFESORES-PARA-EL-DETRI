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
    public class CN_Asignatura
    {
        private DAL_Asignatura objetoCData = new DAL_Asignatura();

        private bool state = false;
        public DataTable MostrarAsignaturas()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistros();
            return tabla;
        }
        public DataTable MostrarAsignaturasWithGroups_CNegocio(string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarAsignaturasConGrupos(objSemestre);
            return tabla;
        }
        public DataTable MostrarAllAsignaturasCmb_CNegocio()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistrosToCmbDAL();
            return tabla;
        }
        public DataTable MostrarRegistrosByIdSemestre_Negocio(string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarRegistrosByIdSemestre(objSemestre);
            return tabla;
        }
        public DataTable MostrarRegistrosAsignaturaWithDocenteByIdSemestre_Negocio(string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarRegistrosAsignaturaWithDocenteByIdSemestre(objSemestre);
            return tabla;
        }
        public DataTable MostrarRegistrosAsignaturaWithOutDocenteByIdSemestre_Negocio(string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarRegistrosAsignaturaWithOutDocenteByIdSemestre(objSemestre);
            return tabla;
        }

        #region CRUD Methods
        public bool CreateAsignaturaNeg(string idCarrera,string nameAsig, string tpAsig, string cod, string hTot, string hSem, string lvlAsig)
        {
            try
            {
                ClsAsignatura ObjAsignatura = new ClsAsignatura()
                {
                    NombreAsignatura = nameAsig,
                    TipoAsignatura = tpAsig,
                    CodigoAsignatura = cod,
                    HorasAsignaturaTotales = Convert.ToInt32(hTot),
                    HorasAsignaturaSemanales = Convert.ToInt32(hSem),
                    NivelAsignatura = lvlAsig
                };
                ClsCarrera ObjCarrera = new ClsCarrera()
                {
                    IdCarrera = Convert.ToInt32(idCarrera),
                };
                objetoCData.CreateAsignatura(ObjAsignatura, ObjCarrera);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }

        public bool UpdateAsignaturaNeg(string idAsignatura, string idCarrera ,string nameAsig, string tpAsig, string cod, string hTot, string hSem, string lvlAsig)
        {
            try
            {
                ClsAsignatura ObjAsignatura = new ClsAsignatura()
                {
                    IdAsignatura = Convert.ToInt32(idAsignatura),
                    NombreAsignatura = nameAsig,
                    TipoAsignatura = tpAsig,
                    CodigoAsignatura = cod,
                    HorasAsignaturaTotales = Convert.ToInt32(hTot),
                    HorasAsignaturaSemanales = Convert.ToInt32(hSem),
                    NivelAsignatura = lvlAsig
                };
                ClsCarrera ObjCarrera = new ClsCarrera()
                {
                    IdCarrera = Convert.ToInt32(idCarrera),
                };
                objetoCData.UpdateAsignatura(ObjAsignatura, ObjCarrera);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteAsignaturaNeg(string idAsignatura)
        {
            try
            {
                ClsAsignatura ObjAsignatura = new ClsAsignatura()
                {
                    IdAsignatura = Convert.ToInt32(idAsignatura)
                };
                objetoCData.DeleteAsignatura(ObjAsignatura);

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
