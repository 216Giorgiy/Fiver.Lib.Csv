using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fiver.Lib.Csv.Reader.Source
{
    public sealed class CsvReader : ICsvReader
    {
        private readonly string filename;

        public CsvReader(string filename)
        {
            this.filename = filename;
        }

        public List<string> Read()
        {
            return File.ReadAllLines(this.filename).ToList();
        }
    }
}
