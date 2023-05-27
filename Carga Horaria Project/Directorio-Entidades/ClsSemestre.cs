using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Entidades;

namespace Directorio_Entidades
{
    public class ClsSemestre
    {
        #region Atributos Privados
        private int _idSemestre;
        private string _codigoSemestre;
        private int _añoSemestre;
        private DateOnly _diaInicio;
        private DateOnly _diaFin;
        private int _numeroSemanasClase;
        private int _numeroSemanasSemestre;
        private bool _estado;
        private List<ClsTipoDocente> _lstTpDocente;
        #endregion

        #region Atributos Públicos
        public int IdSemestre { get => _idSemestre; set => _idSemestre = value; }
        public string CodigoSemestre { get => _codigoSemestre; set => _codigoSemestre = value; }
        public int AñoSemestre { get => _añoSemestre; set => _añoSemestre = value; }
        public DateOnly DiaInicio { get => _diaInicio; set => _diaInicio = value; }
        public DateOnly DiaFin { get => _diaFin; set => _diaFin = value; }
        public int NumeroSemanasClase { get => _numeroSemanasClase; set => _numeroSemanasClase = value; }
        public int NumeroSemanasSemestre { get => _numeroSemanasSemestre; set => _numeroSemanasSemestre = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public List<ClsTipoDocente> LstTpDocente { get => _lstTpDocente; set => _lstTpDocente = value; }
        #endregion
        public string DisplaySemestre()
        {
            return IdSemestre +" "+ CodigoSemestre;
        }
    }
}
