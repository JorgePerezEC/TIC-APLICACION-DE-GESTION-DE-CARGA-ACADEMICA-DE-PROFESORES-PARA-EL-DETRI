using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directorio_Entidades;

namespace Directorio_Entidades
{
    public class ClsDocente
    {
        #region Atributos Privados
        private int _idDocente;
        private int _idDepa;
        private string _nombre1Docente;
        private string _nombre2Docente;
        private string _apellido1Docente;
        private string _apellido2Docente;
        private string _tituloDocente;
        private string _emailDocente;
        #endregion

        #region Atributos Públicos
        public int IdDocente { get => _idDocente; set => _idDocente = value; }
        public string Nombre1Docente { get => _nombre1Docente; set => _nombre1Docente = value; }
        public string Nombre2Docente { get => _nombre2Docente; set => _nombre2Docente = value; }
        public string Apellido1Docente { get => _apellido1Docente; set => _apellido1Docente = value; }
        public string Apellido2Docente { get => _apellido2Docente; set => _apellido2Docente = value; }
        public string TituloDocente { get => _tituloDocente; set => _tituloDocente = value; }
        public int IdDepa { get => _idDepa; set => _idDepa = value; }
        public string EmailDocente { get => _emailDocente; set => _emailDocente = value; }
        #endregion
    }
}
