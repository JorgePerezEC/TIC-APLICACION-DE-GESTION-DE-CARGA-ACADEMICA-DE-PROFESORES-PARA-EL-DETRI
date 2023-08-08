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
    public class CN_GrAsignatura
    {
        private DAL_GrupoAsignatura objetoCData = new DAL_GrupoAsignatura();

        public DataTable MostrarGrAsignatura()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarAllRegistros();
            return tabla;
        }
        public DataTable MostrarGruposPorAsignatura_Negocio(string idAsignatuar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarGruposPorAsignatura(idAsignatuar);
            return tabla;
        }

        #region CRUD Methods
        public bool CreateGruposNeg(string idAsig, string nameGr)
        {
            try
            {
                ClsGrupoAsignatura ObjGrupoAsig = new ClsGrupoAsignatura()
                {
                    IdAsignatura = Convert.ToInt32(idAsig),
                    NombreGrupo = nameGr
                };
                objetoCData.CreateGrAsignatura(ObjGrupoAsig);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;
            }

        }

        public bool UpdateGruposNeg(string idGrupo, string idAsig, string nameGr)
        {
            try
            {
                ClsGrupoAsignatura ObjGrupoAsig = new ClsGrupoAsignatura()
                {
                    IdGrupoAsignatura = Convert.ToInt32(idGrupo),
                    IdAsignatura = Convert.ToInt32(idAsig),
                    NombreGrupo = nameGr
                };
                objetoCData.UpdateGrAsignatura(ObjGrupoAsig);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteGruposNeg(string idGrupo)
        {
            try
            {
                ClsGrupoAsignatura ObjGrupoAsig = new ClsGrupoAsignatura()
                {
                    IdGrupoAsignatura = Convert.ToInt32(idGrupo)
                };
                
                objetoCData.DeleteGrAsignatura(ObjGrupoAsig);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        #endregion
        public int GetIDGrAsignaturaNegocio(string idAsignatura, string grupo)
        {
            ClsGrupoAsignatura ObjGrAsignatura = new ClsGrupoAsignatura()
            {
                IdAsignatura = Convert.ToInt32(idAsignatura),
                NombreGrupo = grupo
            };
            int idCargHoraria = objetoCData.GetIdGrAsignaturaDAL(ObjGrAsignatura);
            return idCargHoraria;
        }
        public string GetLvlAsignatura_Negocio(string idAsignatura)
        {
            ClsAsignatura ObjAsignatura = new ClsAsignatura()
            {
                IdAsignatura = Convert.ToInt32(idAsignatura),
            };
            string lvlAsignatura = objetoCData.GetAsigLevelByAsigDAL(ObjAsignatura);
            return lvlAsignatura;
        }
        public string GetTypeAsigByAsig_Negocio(string idAsignatura)
        {
            ClsAsignatura ObjAsignatura = new ClsAsignatura()
            {
                IdAsignatura = Convert.ToInt32(idAsignatura),
            };
            string typeAsignatura = objetoCData.GetTypeAsigByAsig_DAL(ObjAsignatura);
            return typeAsignatura;
        }
        public string GetCodeAsigByAsig_Negocio(string idAsignatura)
        {
            ClsAsignatura ObjAsignatura = new ClsAsignatura()
            {
                IdAsignatura = Convert.ToInt32(idAsignatura),
            };
            string typeAsignatura = objetoCData.GetCodeAsigByAsig_DAL(ObjAsignatura);
            return typeAsignatura;
        }

    }
}
