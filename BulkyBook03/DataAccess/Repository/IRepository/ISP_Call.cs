using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Dapper;

namespace BulkyBook03.DataAccess.Repository.IRepository
{
    public  interface ISP_Call : IDisposable
    {
        T Single<T>(string procedureName, DynamicParameters param = null);
        void Execute(string procedureName, DynamicParameters param = null);
        T OneRecord<T>(string procedureName, DynamicParameters param = null);
        IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null);
        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null);
    }
}