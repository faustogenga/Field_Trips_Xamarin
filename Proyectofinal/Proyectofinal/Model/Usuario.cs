using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyectofinal.Model
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cedula { get; set; }
        public string Carrera { get; set; }
    }
}
