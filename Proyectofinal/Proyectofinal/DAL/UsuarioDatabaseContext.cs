using Proyectofinal.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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

            var assembly = typeof(UsuarioDatabaseContext).Assembly;

            using (Stream stream = assembly.GetManifestResourceStream("Proyectofinal.Database.Proyecto.db"))
            {
                // Copy the stream to the local storage
                using (var fileStream = new FileStream(dbPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
            }

            connection = new SQLiteConnection(dbPath);
        }

        public List<Usuario> GetAllModels()
        {
            var query = connection.Table<Usuario>();
            return query.ToList();
        }

        public void InsertModel(Usuario model)
        {
            connection.Insert(model);
        }

        public void UpdateModel(Usuario model)
        {
            connection.Update(model);
        }

        public void DeleteModel(Usuario model)
        {
            connection.Delete(model);
        }

        public Usuario LoginModelAsync(string email, string password)
        {
            var query = connection.Table<Usuario>().Where(u => u.Email == email && u.Password == password);
            return query.FirstOrDefault();
        }
    }

}
