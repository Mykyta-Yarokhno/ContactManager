using ContactManager.Domain.Entities.Contacts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Apllication.Utils
{
    public class CsvReader<T> : IEntityReader<T> where T : class, new()
    {
        private readonly Stream _data;
        public CsvReader(Stream data)
        {
            _data = data;
        }

        public  IEnumerable<T> Read()
        {
            var cultureInfo = new CultureInfo("en-US");

            using (var reader = new StreamReader(_data))
            {
                string headerLine = reader.ReadLine(); 

                if (headerLine == null)
                    yield break; 

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split(',');

                        if (values.Length == 5)
                        {
                            yield return new Contact
                            (
                                0,
                                values[0],
                                DateTime.Parse(values[1]),
                                bool.Parse(values[2]),
                                values[3],
                                decimal.Parse(values[4], cultureInfo)
                            ) as T;
                            
                        }
                    }
                }
            }
        }
    }
}
