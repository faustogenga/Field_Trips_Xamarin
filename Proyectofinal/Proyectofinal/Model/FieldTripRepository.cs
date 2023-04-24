using Proyectofinal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyectofinal.Model
{
    public class FieldTripRepository
    {
        public List<String> FieldTripsCodigo { get; set; }

        public UsuarioDatabaseContext DataBase = new UsuarioDatabaseContext();

        public List<FieldTrip> GetAllFieldTrip()
        {
            var FieldTrips = DataBase.GetAllFieldTrips();
            return FieldTrips;
        }
        public List<string> GetAllFieldTripCodigos()
        {
            var FieldTrips = GetAllFieldTrip();
            FieldTripsCodigo = FieldTrips.Select(c => c.Codigo).ToList();
            return FieldTripsCodigo;
        }
    }
}
