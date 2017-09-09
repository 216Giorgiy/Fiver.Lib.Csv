using System.Collections.Generic;
using System.IO;

namespace Fiver.Lib.Csv.Writer.Source
{
    public sealed class CsvWriter : ICsvWriter
    {
        private readonly string filename;

        public CsvWriter(string filename)
        {
            this.filename = filename;
        }

        public void Write(List<string> lines)
        {
            using (var fs = new FileStream(this.filename, FileMode.Create))
            using (var sw = new StreamWriter(fs))
            {
                lines.ForEach(row => sw.WriteLine(row));
            }
        }
    }
}
