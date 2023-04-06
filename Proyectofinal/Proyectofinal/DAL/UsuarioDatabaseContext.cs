using Proyectofinal.Model;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
            File.Delete(dbPath);
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


        public List<Usuario> GetAllUsuarios()
        {
            return connection.Table<Usuario>().ToList();
        }

        public List<Carrera> GetAllCarreras()
        {
            return connection.GetAllWithChildren<Carrera>().ToList();
        }

        public int UpdateUsuario(Usuario model)
        {
            return connection.Update(model);
        }

        public int DeleteUsuario(Usuario model)
        {
            return connection.Delete(model);
        }

        public Usuario GetUsuarioById(int id)
        {
            return connection.Table<Usuario>().FirstOrDefault(u => u.Id == id);
        }


        public Usuario LoginUsuario(string email, string password)
        {
            var query = connection.Table<Usuario>().Where(u => u.Email == email && u.Password == password).ToList();
            return query.FirstOrDefault();
        }


        public Usuario LoginAdminUsuario(String email, string password)
        {
            var query = connection.Table<Usuario>().Where(u => u.Email == email && u.Password == password && u.Role == "Admin").ToList();
            return query.FirstOrDefault();
        }

        public int RegisterUsuario(Usuario model)
        {
            return connection.Insert(model);
        }

        public Usuario RegisterEmailValidation(string email)
        {
            var query = connection.Table<Usuario>().Where(u => u.Email == email).ToList();
            return query.FirstOrDefault();
        }

        public Usuario RegisterCedulaValidation(string cedula)
        {
            var query = connection.Table<Usuario>().Where(u => u.Cedula == cedula).ToList();
            return query.FirstOrDefault();
        }

    }

}
