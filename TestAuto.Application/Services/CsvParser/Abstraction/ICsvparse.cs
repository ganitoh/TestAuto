using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAuto.Application.Services.CsvParser.Abstraction
{
    public interface ICsvParse<TEntity> where TEntity : class
    {
        Task ParseAndSaveAsync(MemoryStream fileStream);
        Task ParseAndSaveAsync(string filePath);
    }
}
