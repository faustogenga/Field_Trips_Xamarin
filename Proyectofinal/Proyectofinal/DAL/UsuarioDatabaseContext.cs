using Proyectofinal.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Proyectofinal.DAL
{
    public class UsuarioDatabaseContext
    {
        public SQLiteConnection connection;

        static string dbName = "Proyecto.db";

        public string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),dbName);


        public UsuarioDatabaseContext()
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


        public List<Usuario> GetAllModels()
        {
            var query = connection.Table<Usuario>();
            return query.ToList();
        }

        public List<string> GetAllCarreras()
        {
            var query = connection.Table<Carrera>().Select(u => u.Nombre);
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

        public Usuario LoginAdminModel(String email, string password)
        {
            var query = connection.Table<Usuario>().Where(u => u.Email == email && u.Password == password && u.Role == "Admin");
            return query.FirstOrDefault();
        }

        public int RegisterModel(Usuario model)
        {
            int rowsAffected = connection.Insert(model);
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



    }

}
