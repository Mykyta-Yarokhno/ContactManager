using ContactManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Apllication.Utils
{
    public interface IEntityReader<T> 
    {
        IEnumerable<T> Read();
    }
}
