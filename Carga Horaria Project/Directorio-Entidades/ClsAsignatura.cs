using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Entidades;

namespace Directorio_Entidades
{
    public class ClsAsignatura
    {
        #region Atributos Privados
        private int _idAsignatura;
        private string _nombreAsignatura;
        private string _tipoAsignatura;
        private string _codigoAsignatura;
        private int _horasAsignaturaTotales;
        private int _horasAsignaturaSemanales;
        private string _nivelAsignatura;
        private bool _estado;
        private List<ClsGrupoAsignatura> _lstGrAsignaturas;
        private List<ClsCarrera> _lstCarreras; //* a * entre Carrera y Asig
        private List<ClsCargaHoraria> _lstCargasHorarias; //* a * entre CargaHoraria y Asig
        #endregion

        #region Atributos Públicos
        public int IdAsignatura { get => _idAsignatura; set => _idAsignatura = value; }
        public string NombreAsignatura { get => _nombreAsignatura; set => _nombreAsignatura = value; }
        public string TipoAsignatura { get => _tipoAsignatura; set => _tipoAsignatura = value; }
        public string CodigoAsignatura { get => _codigoAsignatura; set => _codigoAsignatura = value; }
        public int HorasAsignaturaTotales { get => _horasAsignaturaTotales; set => _horasAsignaturaTotales = value; }
        public int HorasAsignaturaSemanales { get => _horasAsignaturaSemanales; set => _horasAsignaturaSemanales = value; }
        public string NivelAsignatura { get => _nivelAsignatura; set => _nivelAsignatura = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public List<ClsCarrera> LstCarreras { get => _lstCarreras; set => _lstCarreras = value; }
        internal List<ClsGrupoAsignatura> LstGrAsignaturas { get => _lstGrAsignaturas; set => _lstGrAsignaturas = value; }
        internal List<ClsCargaHoraria> LstCargasHorarias { get => _lstCargasHorarias; set => _lstCargasHorarias = value; }
        #endregion
    }
}
