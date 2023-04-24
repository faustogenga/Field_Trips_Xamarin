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

        //INSERT
        public int InsertFieldTrip(FieldTrip model)
        {
            return connection.Insert(model);
        }

        //GET ALL

        public List<Usuario> GetAllUsuarios()
        {
            return connection.Table<Usuario>().ToList();
        }

        public List<Carrera> GetAllCarreras()
        {
            return connection.GetAllWithChildren<Carrera>().ToList();
        }

        public List<FieldTrip> GetAllFieldTrips()
        {
            return connection.Table<FieldTrip>().ToList();
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return connection.Table<Feedback>().ToList();
        }

        //UPDATE

        public int UpdateUsuario(Usuario model)
        {
            return connection.Update(model);
        }

        public int UpdateCarrera(Carrera model)
        {
            return connection.Update(model);
        }

        public int UpdateFieldTrip(FieldTrip model)
        {
            return connection.Update(model);
        }
        public int UpdateFeedbackp(Feedback model)
        {
            return connection.Update(model);
        }

        //DELETE

        public int DeleteUsuario(Usuario model)
        {
            return connection.Delete(model);
        }

        public int DeleteCarrera(Carrera model)
        {
            return connection.Delete(model);
        }

        public int DeleteFieldTrip(FieldTrip model)
        {
            return connection.Delete(model);
        }
        public int DeleteFeedback(Feedback model)
        {
            return connection.Delete(model);
        }


        //GET BY ID

        public Usuario GetUsuarioById(int id)
        {
            return connection.Table<Usuario>().FirstOrDefault(u => u.Id == id);
        }

        public Carrera GetCarreraById(int id)
        {
            return connection.Table<Carrera>().FirstOrDefault(u => u.Id == id);
        }

        public FieldTrip GetFieldTripById(int id)
        {
            return connection.Table<FieldTrip>().FirstOrDefault(u => u.Id == id);
        }
        public Feedback GetFeedbackById(int id)
        {
            return connection.Table<Feedback>().FirstOrDefault(u => u.Id == id);
        }



        //LOGIN
        public Usuario LoginUsuario(string email, string password)
        {
            var query = connection.Table<Usuario>().Where(u => u.Email == email && u.Password == password).ToList();
            return query.FirstOrDefault();
        }

        //ADMIN LOGIN
        public Usuario LoginAdminUsuario(String email, string password)
        {
            var query = connection.Table<Usuario>().Where(u => u.Email == email && u.Password == password && u.Role == "Admin").ToList();
            return query.FirstOrDefault();
        }

        //REGISTER
        public int RegisterUsuario(Usuario model)
        {
            return connection.Insert(model);
        }
        public int RegisterFeedback(Feedback model)
        {
            return connection.Insert(model);
        }

        //VALIDATION
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

        public FieldTrip FieldTripIdValidation(string Codigo)
        {
            var query = connection.Table<FieldTrip>().Where(u => u.Codigo == Codigo).ToList();
            return query.FirstOrDefault();
        }

    }

}
