using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Apllication.Utils
{
    public class EntityDataProvider : IEntityDataProvider 
    {
        public IEntityReader<T> GetDataProvider<T>(IEntityDataProvider.EntityFormatProviders entityFormatProvider, Stream data) where T : class, new()
        {
            return entityFormatProvider switch
            {
                IEntityDataProvider.EntityFormatProviders.CSV => new CsvReader<T>(data),
                _ => throw new NotImplementedException()
            };

        }


    }
}
