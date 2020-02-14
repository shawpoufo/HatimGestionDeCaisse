using System;
namespace CaisseSqlLogicLibrary.SqliteDataAccess
{
    public interface ISqliteTransaction
    {
        void ComitTransaction();
        void Dispose();
        string GetConnectionString(string name);
        System.Collections.Generic.List<T> LoadDataInTransaction<T, U>(U parameters, string query);
        void RollBackTransaction();
        void SavedDataInTransaction<T>(T parameters, string query);
        void StartTransaction(string connectionStringName = "caisseCnn");
    }
}
