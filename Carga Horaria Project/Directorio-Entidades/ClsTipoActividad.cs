using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio_Entidades
{
    public class ClsTipoActividad
    {
        #region Atributos Privados

        private int _idTipoActividad;
        private string _nombreTpActividad;
        private string _descripcionTpActividad;
        private List<ClsActividad> _lstActividad;

        #endregion

        #region Atributos Públicos
        public int IdTipoActividad { get => _idTipoActividad; set => _idTipoActividad = value; }
        public string NombreTpActividad { get => _nombreTpActividad; set => _nombreTpActividad = value; }
        public string DescripcionTpActividad { get => _descripcionTpActividad; set => _descripcionTpActividad = value; }
        internal List<ClsActividad> LstActividad { get => _lstActividad; set => _lstActividad = value; }
        #endregion


        public override string ToString()
        {
            return this.NombreTpActividad + ", " + this.DescripcionTpActividad + ", " + this.LstActividad ;
        }


    }
}
