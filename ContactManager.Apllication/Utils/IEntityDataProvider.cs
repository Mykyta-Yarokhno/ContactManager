using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Apllication.Utils
{
    

    public interface IEntityDataProvider 
    {
        public enum EntityFormatProviders 
        {
            CSV,
            JSON,
            XML
        }
        IEntityReader<T> GetDataProvider<T>(EntityFormatProviders entityFormatProvider, Stream data) where T : class, new();
    }
}
