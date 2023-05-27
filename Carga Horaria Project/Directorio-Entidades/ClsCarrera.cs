using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Entidades;

namespace Directorio_Entidades
{
    public class ClsCarrera
    {

        #region Atributos Privados
        private int _idCarrera;
        private string _nombreCarrera;
        private string _codigoCarrera;
        private string _pensum;
        private bool _estadoCarrera;
        private List<ClsAsignatura> _lstAsignaturas;
        private int _idDepartamento;
        #endregion

        #region Atributos Públicos
        public int IdCarrera { get => _idCarrera; set => _idCarrera = value; }
        public string NombreCarrera { get => _nombreCarrera; set => _nombreCarrera = value; }
        public string CodigoCarrera { get => _codigoCarrera; set => _codigoCarrera = value; }
        public string Pensum { get => _pensum; set => _pensum = value; }
        public bool EstadoCarrera { get => _estadoCarrera; set => _estadoCarrera = value; }
        public int IdDepartamento { get => _idDepartamento; set => _idDepartamento = value; }
        internal List<ClsAsignatura> LstAsignaturas { get => _lstAsignaturas; set => _lstAsignaturas = value; }
        #endregion
    }
}
