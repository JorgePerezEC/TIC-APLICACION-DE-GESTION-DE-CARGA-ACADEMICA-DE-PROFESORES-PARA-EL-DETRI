using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Entidades;

namespace Directorio_Entidades
{
    public class ClsTipoDocente
    {
        #region Atributos Privados
        private int _idTipoDocente;
        private int _idSemestreTipoDocente;
        private string _nombreTipoDocente;
        private bool _estado;
        private int _horasExigibles;
        private List<ClsSemestre> _lstSemestres;
        #endregion

        #region Atributos Públicos
        public int IdTipoDocente { get => _idTipoDocente; set => _idTipoDocente = value; }
        public string NombreTipoDocente { get => _nombreTipoDocente; set => _nombreTipoDocente = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public int IdSemestreTipoDocente { get => _idSemestreTipoDocente; set => _idSemestreTipoDocente = value; }
        public int HorasExigibles { get => _horasExigibles; set => _horasExigibles = value; }
        internal List<ClsSemestre> LstSemestres { get => _lstSemestres; set => _lstSemestres = value; }
        #endregion
    }
}
