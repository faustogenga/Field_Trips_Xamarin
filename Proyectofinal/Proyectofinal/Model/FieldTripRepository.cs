using Proyectofinal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyectofinal.Model
{
    public class FieldTripRepository
    {
        public List<String> FieldTripsOrganizacion { get; set; }

        public UsuarioDatabaseContext DataBase = new UsuarioDatabaseContext();

        public List<FieldTrip> GetAllFieldTrip()
        {
            var FieldTrips = DataBase.GetAllFieldTrips();
            return FieldTrips;
        }

        public List<string> GetAllFieldTripString()
        {
            var fieldTrips = GetAllFieldTrip();
            var fieldTripsString = fieldTrips.Select(c => c.ToString()).ToList();
            return fieldTripsString;
        }
        public List<string> GetAllFieldTripOrganizacion()
        {
            var FieldTrips = GetAllFieldTrip();
            FieldTripsOrganizacion = FieldTrips.Select(c => c.Organizacion).ToList();
            return FieldTripsOrganizacion;
        }

        public string GetFieldTripByOrganizacion(string Organizacion)
        {
            var FieldTrips = GetAllFieldTrip();
            var FieldTrip = FieldTrips.Where(c => c.Organizacion == Organizacion).FirstOrDefault();
            return FieldTrip.Codigo;
        }

    }
}
