using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAuto.Application.Services.CsvParser.Abstraction
{
    public interface ICsvHalperParser<TEntity>
        : ICsvParse<TEntity>
        where TEntity : class
    {
        Task ParseAndSaveAsync<TEntityMapClass>(MemoryStream fileStream)
            where TEntityMapClass : ClassMap;

        Task ParseAndSaveAsync<TEntityMapClass>(string fileName)
            where TEntityMapClass : ClassMap;

    }
}
