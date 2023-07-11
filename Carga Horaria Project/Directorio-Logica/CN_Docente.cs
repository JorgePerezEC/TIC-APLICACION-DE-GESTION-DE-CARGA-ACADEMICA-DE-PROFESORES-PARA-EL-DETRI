using Directorio_Datos;
using Directorio_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace Directorio_Logica
{
    public class CN_Docente
    {
        private DAL_Docente objetoCData = new DAL_Docente();
        public DataTable MostrarDocentes()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistros();
            return tabla;
        }
        public DataTable MostrarDocentesAllNames()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarDocentesNombresCompletos();
            return tabla;
        }
        public DataTable MostrarDepartamentosNeg()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistros();
            return tabla;
        }
        public DataTable MostrarDocentesByDepId(string idDepa, string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsDepartamento objDepa = new ClsDepartamento()
            {
                IdDepartamento = Convert.ToInt32(idDepa)
            };
            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarRegistrosById(objDepa, objSemestre);
            return tabla;
        }
        public DataTable MostrarDocentesLstWithHorasEx_Negocio(string idSemestre)
        {
            DataTable tabla = new DataTable();

            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarDocentesLstWithHorasEx_DAL(objSemestre);
            return tabla;
        }

        public DataTable MostrarRegistrosByIdSemestre_Negocio(string idSemestre)
        {
            DataTable tabla = new DataTable();
            ClsSemestre objSemestre = new ClsSemestre()
            {
                IdSemestre = Convert.ToInt32(idSemestre)
            };
            tabla = objetoCData.MostrarRegistrosByIdSemestre( objSemestre);
            return tabla;
        }

        #region CRUD Methods
        public bool CreateDocenteNeg(string idDep, string name1, string name2, string apellido1,string apellido2,string titulo)
        {
            try
            {
                
                ClsDocente ObjDocente = new ClsDocente()
                {
                    IdDepa = Convert.ToInt32(idDep),
                    Nombre1Docente = name1,
                    Nombre2Docente = name2,
                    Apellido1Docente = apellido1,
                    Apellido2Docente = apellido2,
                    TituloDocente = titulo
                };
                objetoCData.CreateDocente(ObjDocente);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }

        public bool UpdateDocenteNeg(string idDocente, string idDep, string name1, string name2, string apellido1, string apellido2, string titulo)
        {
            try
            {
                ClsDocente ObjDocente = new ClsDocente()
                {
                    IdDocente = Convert.ToInt32(idDocente),
                    IdDepa = Convert.ToInt32(idDep),
                    Nombre1Docente = name1,
                    Nombre2Docente = name2,
                    Apellido1Docente = apellido1,
                    Apellido2Docente = apellido2,
                    TituloDocente = titulo
                };
                objetoCData.UpdateDocente(ObjDocente);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteDocenteNeg(string idDocente)
        {
            try
            {
                ClsDocente ObjDocente = new ClsDocente()
                {
                    IdDocente = Convert.ToInt32(idDocente)
                };
                objetoCData.DeleteDocente(ObjDocente);

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
