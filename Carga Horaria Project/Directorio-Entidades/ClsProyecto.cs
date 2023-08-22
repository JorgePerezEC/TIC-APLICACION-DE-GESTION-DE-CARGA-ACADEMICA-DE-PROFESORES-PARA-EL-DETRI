using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio_Entidades
{
    public class ClsProyecto
    {
        #region Atributos Privados
        private int _idProyecto;
        private string _codigo;
        private string _nombreProyecto;
        private DateOnly _diaInicio;
        private DateOnly _diaFin;
        private decimal _presupuesto;
        private string _tipo;
        private string _url;
        private bool _estado;
        #endregion

        #region Atributos Publicos
        public int IdProyecto { get => _idProyecto; set => _idProyecto = value; }
        public string Codigo { get => _codigo; set => _codigo = value; }
        public string NombreProyecto { get => _nombreProyecto; set => _nombreProyecto = value; }
        public DateOnly DiaInicio { get => _diaInicio; set => _diaInicio = value; }
        public DateOnly DiaFin { get => _diaFin; set => _diaFin = value; }
        public decimal Presupuesto { get => _presupuesto; set => _presupuesto = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public string Url { get => _url; set => _url = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        #endregion
    }
}
