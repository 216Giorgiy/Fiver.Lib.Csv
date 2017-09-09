using Fiver.Lib.Csv.Writer.Source;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiver.Lib.Csv.Writer
{
    public sealed class CsvBuilder 
    {
        private readonly List<CsvRowBuilder> rows;

        public CsvBuilder()
        {
            this.rows = new List<CsvRowBuilder>();
        }

        public List<string> ToLines() 
            => this.rows.Select(row => row.ToLine()).ToList();

        public CsvRowBuilder AppendRow()
        {
            this.rows.Add(new CsvRowBuilder());
            return this.rows.Last();
        }

        public void WriteTo(ICsvWriter writer)
            => WriteTo(writer.Write); 

        public void WriteTo(Action<List<string>> writer)
            => writer(ToLines());
    }
}
