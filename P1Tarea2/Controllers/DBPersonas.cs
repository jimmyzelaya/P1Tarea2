using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace P1Tarea2.Controllers
{
    public class DBPersonas
    {
        // Global Variables
        readonly SQLiteAsyncConnection _conexion;

        // Constructor Vacio
        public DBPersonas()
        { }

        public DBPersonas(String dbpath)
        {
            _conexion = new SQLiteAsyncConnection(dbpath);

            // Creacion de Objetos de Base de dartos
            _conexion.CreateTableAsync<Models.Personas>().Wait();
        }

        // CRUD - Create / Read / Update/ Delete

        public Task<int> StoreEquipo(Models.Personas persona)
        {
            if (persona.Id == 0)
            {
                return _conexion.InsertAsync(persona);
            }
            else
            {
                return _conexion.UpdateAsync(persona);
            }
        }

        // Read

        public Task<List<Models.Personas>> ListaEquipos()
        {
            return _conexion.Table<Models.Personas>().ToListAsync();
        }

        public Task<Models.Personas> GetEquipo(int pid)
        {
            return _conexion.Table<Models.Personas>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        public Task<int> DeleteEquipo(Models.Personas equipos)
        {
            return _conexion.DeleteAsync(equipos);
        }


    }
}