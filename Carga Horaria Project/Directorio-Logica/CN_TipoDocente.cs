using Directorio_Datos;
using Directorio_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Directorio_Logica
{
    public class CN_TipoDocente
    {
        private DAL_TipoDocente objetoCData = new DAL_TipoDocente();

        private bool state = false;
        public DataTable MostrarTiposDocentesLn()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistros();
            return tabla;
        }
        public DataTable MostrarTiposDocentesCmbLn()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistrosCmb();
            return tabla;
        }
        public DataTable MostrarDocentesHExBySemestre_Negocio(string idDocente)
        {
            DataTable tabla = new DataTable();
            ClsSemestre ObjSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idDocente)
            };
            tabla = objetoCData.MostrarRegistrosHorasExBySemestre(ObjSemestre);
            return tabla;
        }
        #region CRUD Methods
        public bool CreateTiposDocentesNeg(string nameTpDoc, string numHoras)
        {
            try
            {
                ClsTipoDocente ObjTpDoc = new ClsTipoDocente()
                {
                    NombreTipoDocente = nameTpDoc,
                    HorasExigibles = Convert.ToInt32(numHoras)
                };
                objetoCData.CreateTipoDocente(ObjTpDoc);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool CreateDocenteWHorasExigibles_Neg(string idTpDocente, string idSemestre, string idDocente, string numHorasEx)
        {
            try
            {
                ClsTipoDocente ObjTpDoc = new ClsTipoDocente()
                {
                    IdTipoDocente = Convert.ToInt32(idTpDocente),
                    HorasExigibles= Convert.ToInt32(numHorasEx),
                };
                ClsDocente ObjDocente = new ClsDocente()
                {
                    IdDocente = Convert.ToInt32(idDocente),
                };
                ClsSemestre ObjSemestre = new ClsSemestre()
                {
                    IdSemestre = Convert.ToInt32(idSemestre)
                };
                objetoCData.CreateDocenteWHorasExigibles_DAL(ObjTpDoc, ObjSemestre, ObjDocente);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }

        public bool UpdateTiposDocentesNeg(string idTpDoc, string nameTpDoc, string numHoras)
        {
            try
            {
                
                ClsTipoDocente ObjTpDoc = new ClsTipoDocente()
                {
                    IdTipoDocente = Convert.ToInt32(idTpDoc),
                    NombreTipoDocente = nameTpDoc,
                    HorasExigibles = Convert.ToInt32(numHoras),
                };
                objetoCData.UpdateTipoDocente(ObjTpDoc);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool UpdateDocenteWHorasExigibles_Neg(string idSemTpDocente, string idTpDocente, string idSemestre, string idDocente, string numHorasEx)
        {
            try
            {
                ClsTipoDocente ObjTpDoc = new ClsTipoDocente()
                {
                    IdSemestreTipoDocente = Convert.ToInt32(idSemTpDocente),
                    IdTipoDocente = Convert.ToInt32(idTpDocente),
                    HorasExigibles = Convert.ToInt32(numHorasEx),
                };
                ClsDocente ObjDocente = new ClsDocente()
                {
                    IdDocente = Convert.ToInt32(idDocente),
                };
                ClsSemestre ObjSemestre = new ClsSemestre()
                {
                    IdSemestre = Convert.ToInt32(idSemestre)
                };
                objetoCData.UpdateDocenteWHorasExigibles_DAL(ObjTpDoc, ObjSemestre, ObjDocente);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteTiposDocentesNeg(string idTpDoc)
        {
            try
            {
                ClsTipoDocente ObjTpDoc = new ClsTipoDocente()
                {
                    IdTipoDocente = Convert.ToInt32(idTpDoc)
                };
                objetoCData.DeleteTipoDocente(ObjTpDoc);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteDocenteWithHorasExig_Neg(string idSemestreTpDoc)
        {
            try
            {
                ClsTipoDocente ObjTpDoc = new ClsTipoDocente()
                {
                    IdSemestreTipoDocente = Convert.ToInt32(idSemestreTpDoc)
                };
                objetoCData.DeleteDocenteWithHorasExig_DAL(ObjTpDoc);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        #endregion
        public int GetHorasExigiblesByTpDocenteNegocio(string idTipoDocente)
        {
            ClsTipoDocente ObjTipoDocente = new ClsTipoDocente()
            {
                IdTipoDocente = Convert.ToInt32(idTipoDocente)
            };
            int horasEx = objetoCData.GetHorasExigiblesByTpDocente_DAL(ObjTipoDocente);
            return horasEx;
        }
        public int GetTipoDocenteHoras_Negocio(string idSemestre, string idTipoDocente)
        {
            ClsTipoDocente ObjTipoDocente = new ClsTipoDocente()
            {
                IdTipoDocente = Convert.ToInt32(idTipoDocente)
            };
            ClsSemestre ObjSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            int horasEx = objetoCData.GetTipoDocenteHoras_DAL(ObjSemestre,ObjTipoDocente);
            return horasEx;
        }
        public DataTable GetTipoDocenteHorasAll_Negocio(string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsSemestre ObjSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.GetTipoDocenteHorasAll_DAL(ObjSemestre);
            return tabla;
        }
        public DataTable GetInfoTipoDocenteByName_Negocio(string idSemestre, string nameTipoDocente)
        {
            DataTable tabla = new DataTable();
            ClsSemestre ObjSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            ClsTipoDocente ObjTipoDocente = new ClsTipoDocente()
            {
                NombreTipoDocente = nameTipoDocente
            };
            tabla = objetoCData.GetInfoTipoDocenteByName_DAL(ObjSemestre, ObjTipoDocente);
            return tabla;
        }
        public bool AddOrUpdateTipoDocente_Semstre_Negocio(string idTpDocente, string idSemestre, string numHorasEx)
        {
            try
            {
                ClsTipoDocente ObjTpDoc = new ClsTipoDocente()
                {
                    IdTipoDocente = Convert.ToInt32(idTpDocente),
                    HorasExigibles = Convert.ToInt32(numHorasEx),
                };
                ClsSemestre ObjSemestre = new ClsSemestre()
                {
                    IdSemestre = Convert.ToInt32(idSemestre)
                };
                objetoCData.AddOrUpdateTipoDocente_Semstre_DAL(ObjTpDoc, ObjSemestre);

                return true;

            }
            catch (Exception ex)
            {
                return false;

            }

        }
    }
}
