using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Usuarios
    {
        private int _idUsuario;
        private string _nombres;
        private string _apellidos;
        private string _usuario;
        private string _contrasenia;
        private int _idRol;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Contrasenia { get => _contrasenia; set => _contrasenia = value; }
        public int IdRol { get => _idRol; set => _idRol = value; }
    }
}
