using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Entidades;

namespace Directorio_Entidades
{
    public class ClsCargaHoraria
    {
        #region Atributos Privados
        private int _idCargaHoraria;
        private int _idDocente;
        private int _idSemestre;

        private int _idAsignaturaCarga;
        private int _idActividadCarga;
        //
        private int _idActividad;
        private int _idAsignatura;
        private int _idGrAsignatura;
        private int _horaSemanalActividad;
        private int _horaTotalActividad;
        //
        private ClsDocente _docente;
        private ClsSemestre _semestre;
        private List<ClsActividad> _lstActividades;
        private List<ClsAsignatura> _lstAsignatura;
        #endregion

        #region Atributos Públicos
        public int IdCargaHoraria { get => _idCargaHoraria; set => _idCargaHoraria = value; }
        public ClsDocente Docente { get => _docente; set => _docente = value; }
        public ClsSemestre Semestre { get => _semestre; set => _semestre = value; }
        public List<ClsActividad> LstActividades { get => _lstActividades; set => _lstActividades = value; }
        public List<ClsAsignatura> LstAsignatura { get => _lstAsignatura; set => _lstAsignatura = value; }
        public int IdDocente { get => _idDocente; set => _idDocente = value; }
        public int IdSemestre { get => _idSemestre; set => _idSemestre = value; }
        //
        public int IdActividad { get => _idActividad; set => _idActividad = value; }
        public int IdAsignatura { get => _idAsignatura; set => _idAsignatura = value; }
        public int HoraSemanalActividad { get => _horaSemanalActividad; set => _horaSemanalActividad = value; }
        public int IdGrAsignatura { get => _idGrAsignatura; set => _idGrAsignatura = value; }
        public int IdAsignaturaCarga { get => _idAsignaturaCarga; set => _idAsignaturaCarga = value; }
        public int IdActividadCarga { get => _idActividadCarga; set => _idActividadCarga = value; }
        public int HoraTotalActividad { get => _horaTotalActividad; set => _horaTotalActividad = value; }
        //
        #endregion


    }
}
