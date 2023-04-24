using Proyectofinal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyectofinal.Model
{
    public class CarreraRepository
    {

        public List<String> CarrerasNombre { get; set; }

        public UsuarioDatabaseContext DataBase = new UsuarioDatabaseContext();

        public List<Carrera> GetAllCarrera()
        {
            var Carreras = DataBase.GetAllCarreras();
            return Carreras;
        }
        public List<string> GetAllCarreraNombres()
        {
            var Carreras = GetAllCarrera();
            CarrerasNombre = Carreras.Select(c => c.Nombre).ToList();
            return CarrerasNombre;
        }



    }
}
