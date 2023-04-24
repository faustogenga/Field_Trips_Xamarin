using Proyectofinal.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Proyectofinal.DAL
{
    public class FieldTripDatabaseContext
    {
        public SQLiteConnection connection;

        static string dbName = "Proyecto.db";

        public string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);

        //Connection
        public FieldTripDatabaseContext()
        {
            // Check if the database file exists in the local application data folder
            if (!File.Exists(dbPath))
            {
                // Copy the database file from the resources folder to the local application data folder
                var assembly = typeof(App).GetTypeInfo().Assembly;
                using (var resourceStream = assembly.GetManifestResourceStream("Proyectofinal.Database.Proyecto.db"))
                {
                    using (var fileStream = File.Create(dbPath))
                    {
                        resourceStream.CopyTo(fileStream);
                    }
                }
            }

            connection = new SQLiteConnection(dbPath);

            File.SetAttributes(dbPath, FileAttributes.Normal);
        }

        //Insert
        public int InsertFieldTrip(FieldTrip model)
        {
            return connection.Insert(model);
        }


        //Read
        public List<FieldTrip> GetAllFieldTrip()
        {
            return connection.Table<FieldTrip>().ToList();
        }

        //Update
        public int UpdateFieldTrip(FieldTrip model)
        {
            return connection.Update(model);
        }

        //Delete
        public int DeleteFieldTrip(FieldTrip model)
        {
            return connection.Delete(model);
        }

        //Search - Single object
        public FieldTrip GetFieldTripById(int id)
        {
            return connection.Table<FieldTrip>().FirstOrDefault(u => u.GiraId == id);
        }

        //ID Validation - VM
        public FieldTrip FieldTripIdValidation(int giraId)
        {
            var query = connection.Table<FieldTrip>().Where(u => u.GiraId == giraId).ToList();
            return query.FirstOrDefault();
        }
    }    
}
