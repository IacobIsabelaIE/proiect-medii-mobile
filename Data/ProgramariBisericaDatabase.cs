using ProiectMobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMobile.Data
{
    public class ProgramariBisericaDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ProgramariBisericaDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Serviciu>().Wait();
            _database.CreateTableAsync<Programare>().Wait();

        }
        public Task<List<Serviciu>> GetServiciuListsAsync()
        {
            return _database.Table<Serviciu>().ToListAsync();
        }
        public Task<Serviciu> GetServiciuAsync(int id)
        {
            return _database.Table<Serviciu>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveServiciuAsync(Serviciu slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteServiciuAsync(Serviciu slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> SaveProgamareAsync(Programare programare)
        {
            if (programare.ID != 0)
            {
                return _database.UpdateAsync(programare);
            }
            else
            {
                return _database.InsertAsync(programare);
            }
        }

        public Task<int> DeleteProgramareAsync(Programare programare)
        {
            return _database.DeleteAsync(programare);
        }

        public Task<List<Programare>> GetProgramariAsync()
        {
            return _database.Table<Programare>().ToListAsync();
        }


    }
}

