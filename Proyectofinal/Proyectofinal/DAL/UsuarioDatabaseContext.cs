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
        public SQLiteConnection connection;

        static string dbName = "Proyecto.db";

        public string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            dbName);


        public UsuarioDatabaseContext()
        { 

            if (!File.Exists(dbPath))
            {
                connection = new SQLiteConnection(dbPath);
                connection.CreateTable<Usuario>();
                var Admin = new Usuario();
                Admin.Nombre = "Admin";
                Admin.Email = "Admin@gmail.com";
                Admin.Password = "Admin";
                Admin.Cedula = "000000000";
                Admin.Carrera = "Administracion";
                Admin.Role = "Admin";
                connection.Insert(Admin);
            }
            else
            {
                connection = new SQLiteConnection(dbPath);
            }

            File.SetAttributes(dbPath, FileAttributes.Normal);
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


        public List<string> GetAllCarreras()
        {
            var query = connection.Table<Usuario>().Select(u => u.Carrera);
            List<string> carreras = query.ToList();
            return carreras;
        }

    }

}
