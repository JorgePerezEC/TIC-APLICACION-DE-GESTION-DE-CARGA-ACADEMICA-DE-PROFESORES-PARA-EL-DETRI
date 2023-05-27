using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Datos;
using System.Data;
using Directorio_Entidades;

namespace Directorio_LogicaNegocio
{
    public class CN_Departamento
    {
        private DAL_Departamento objetoCData = new DAL_Departamento();
        

        public DataTable MostrarDepartamentos()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistros();
            return tabla;
        }
        public DataTable MostrarDepartamentosTV()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCData.MostrarRegistrosTV();
            return tabla;
        }
        #region CRUD METHODS
        public bool CreateDepartamentoN(string nameDepartament, string email)
        {
            try
            {
                ClsDepartamento ObjDep = new ClsDepartamento()
                {
                    NombreDepa = nameDepartament,
                    EmailDepa = email
                };
                //objetoCData.CreateDepartamento(nameDepartament, email);
                objetoCData.CreateDepartamentoEntity(ObjDep);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool CreateDepartamentoNEntity(ClsDepartamento _departamentoLn)
        {
            try
            {
                //ClsDepartamento departamento = new ClsDepartamento()
                //{
                //    NombreDepa = _departamentoLn.NombreDepa,
                //    EmailDepa = _departamentoLn.EmailDepa
                //};
                _departamentoLn.NombreDepa = _departamentoLn.NombreDepa;
                _departamentoLn.EmailDepa = _departamentoLn.EmailDepa;
                objetoCData.CreateDepartamentoEntity(_departamentoLn);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool UpdateDepartamentoN(string idDepa, string nameDepartament, string email)
        {
            try
            {
                ClsDepartamento ObjDep = new ClsDepartamento()
                {
                    IdDepartamento = Convert.ToInt32(idDepa),
                    NombreDepa = nameDepartament,
                    EmailDepa = email
                };
                //objetoCData.UpdateDepartamento(Convert.ToInt32(idDepa), nameDepartament, email);
                objetoCData.UpdateDepartamentoEntity(ObjDep);


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;

            }

        }
        public bool DeleteDepartamentoN(string idDepa, string nameDepartament, string email)
        {
            try
            {
                ClsDepartamento ObjDep = new ClsDepartamento()
                {
                    IdDepartamento = Convert.ToInt32(idDepa),
                    NombreDepa = nameDepartament,
                    EmailDepa = email
                };
                //objetoCData.DeleteDepartamento(Convert.ToInt32(idDepa), nameDepartament, email);
                objetoCData.DeleteDepartamentoEntity(ObjDep);

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
