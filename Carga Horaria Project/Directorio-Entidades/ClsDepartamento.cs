using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio_Entidades
{
    public class ClsDepartamento
    {
        #region Atributos Privados
        private int _idDepartamento;
        private string _nombreDepa, _emailDepa;
        private List<ClsCarrera> LstCarreras;
        private List<ClsDocente> LstDocentes;

        //Atributos de manjeo DB
        private string _mensajeError;
        private DataTable _dtResultados;
        #endregion

        #region Atributos Públicos
        public int IdDepartamento { get => _idDepartamento; set => _idDepartamento = value; }
        public string NombreDepa { get => _nombreDepa; set => _nombreDepa = value; }
        public string EmailDepa { get => _emailDepa; set => _emailDepa = value; }
        public List<ClsCarrera> LstCarreras1 { get => LstCarreras; set => LstCarreras = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        internal List<ClsDocente> LstDocentes1 { get => LstDocentes; set => LstDocentes = value; }
        #endregion
    }
}
