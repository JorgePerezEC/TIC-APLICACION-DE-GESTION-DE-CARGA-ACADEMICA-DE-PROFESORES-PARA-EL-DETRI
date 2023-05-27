using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Directorio_Entidades;

namespace Directorio_Entidades
{
    public class ClsActividad 
    {
        #region Atributos Privados
        private int _idActividad;
        private int _idTpActividad;
        private string _nombreActividad;
        private int _horasSemana;
        private int _horasTotalesAct;
        private bool _estado;
        private List<ClsCargaHoraria> _lstCrgHoraria;
        #endregion

        #region Atributos Públicos
        public int IdActividad { get => _idActividad; set => _idActividad = value; }
        public string NombreActividad { get => _nombreActividad; set => _nombreActividad = value; }
        public int HorasSemana { get => _horasSemana; set => _horasSemana = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public int IdTpActividad { get => _idTpActividad; set => _idTpActividad = value; }
        public int HorasTotalesAct { get => _horasTotalesAct; set => _horasTotalesAct = value; }
        internal List<ClsCargaHoraria> LstCrgHoraria { get => _lstCrgHoraria; set => _lstCrgHoraria = value; }
        #endregion

    }
}
