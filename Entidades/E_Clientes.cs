using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Clientes
    {
        private int _idCLiente;
        private string _nombre;
        private string _direccion;
        private string _correo;
        private string _telefono;

        public int IdCLiente { get => _idCLiente; set => _idCLiente = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
    }
}
