using Proyectofinal.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Proyectofinal.DAL
{
    public class UsuarioDatabaseContext
    {
        public readonly SQLiteConnection connection;

        public UsuarioDatabaseContext()
        {
            string dbName = "Proyecto.db";

            string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            dbName);

            if (!File.Exists(dbPath))
            {
                // El archivo de base de datos no existe en la ubicación local, copiar el recurso
                var assembly = typeof(UsuarioDatabaseContext).Assembly;

                using (Stream stream = assembly.GetManifestResourceStream("Proyectofinal.Database.Proyecto.db"))
                {
                    // Copy the stream to the local storage
                    using (var fileStream = new FileStream(dbPath, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(fileStream);
                    }   
                }
            }
            connection = new SQLiteConnection(dbPath);
        }

        public List<Usuario> GetAllModels()
        {
            var query = connection.Table<Usuario>();
            return query.ToList();
        }


        public void UpdateModel(Usuario model)
        {
            connection.Update(model);
        }

        public void DeleteModel(Usuario model)
        {
            connection.Delete(model);
        }

        public Usuario LoginModel(string email, string password)
        {
            var query = connection.Table<Usuario>().Where(u => u.Email == email && u.Password == password);
            return query.FirstOrDefault();
        }

        public int RegisterModel(Usuario model)
        {
            int rowsAffected = connection.Insert(model);
            UpdateDatabase();
            return rowsAffected;
        }

        public Usuario RegisterEmailValidation(string email)
        {
            var query = connection.Table<Usuario>().Where(u => u.Email == email);
            return query.FirstOrDefault();
        }

        public Usuario RegisterCedulaValidation(string cedula)
        {
            var query = connection.Table<Usuario>().Where(u => u.Cedula == cedula);
            return query.FirstOrDefault();
        }


        public List<string> GetAllCarreras()
        {
            var query = connection.Table<Usuario>().Select(u => u.Carrera);
            List<string> carreras = query.ToList();
            return carreras;
        }

        private void UpdateResourceDatabase()
        {
            var assembly = typeof(UsuarioDatabaseContext).Assembly;

            // Read the original database file as a stream
            using (var stream = assembly.GetManifestResourceStream("Proyectofinal.Database.Proyecto.db"))
            {
                if (stream == null)
                {
                    throw new Exception("Could not find the original database file in the resources folder.");
                }

                // Get the path to the local copy of the database file
                var localPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Proyecto.db");

                // Overwrite the original database file with the updated contents
                using (var fileStream = new FileStream(localPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }

    }

}
