using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Entidades;

namespace Directorio_Entidades
{
    public class ClsGrupoAsignatura
    {
        #region Atributos Privados
        private List<ClsDocente> _lstDocentes;
        private int _idGrupoAsignatura;
        private int _idAsignatura;
        private string _nombreGrupo;
        #endregion

        #region Atributos Públicos
        public List<ClsDocente> LstDocentes { get => _lstDocentes; set => _lstDocentes = value; }
        public int IdAsignatura { get => _idAsignatura; set => _idAsignatura = value; }
        public string NombreGrupo { get => _nombreGrupo; set => _nombreGrupo = value; }
        public int IdGrupoAsignatura { get => _idGrupoAsignatura; set => _idGrupoAsignatura = value; }
        #endregion

    }
}
