using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Entidades;

namespace Directorio_Entidades
{
    public class ClsHorarioGrAsignatura
    {
        #region Atributos Privados
        private int _idHorario;
        private int _idGrupo;
        private int _idGrAsig;
        private string _grupo;
        private TimeOnly _horaInicio;
        private TimeOnly _horaFin;
        private string _diaSemana;
        private int _idDiaSemana;
        #endregion

        #region Atributos Públicos
        public int IdHorario { get => _idHorario; set => _idHorario = value; }
        public TimeOnly HoraInicio { get => _horaInicio; set => _horaInicio = value; }
        public TimeOnly HoraFin { get => _horaFin; set => _horaFin = value; }
        public string DiaSemana { get => _diaSemana; set => _diaSemana = value; }
        public string Grupo { get => _grupo; set => _grupo = value; }
        public int IdGrupo { get => _idGrupo; set => _idGrupo = value; }
        public int IdGrAsig { get => _idGrAsig; set => _idGrAsig = value; }
        public int IdDiaSemana { get => _idDiaSemana; set => _idDiaSemana = value; }
        #endregion


    }
}
