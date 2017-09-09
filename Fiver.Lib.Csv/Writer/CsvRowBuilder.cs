using System.Collections.Generic;
using System.Linq;

namespace Fiver.Lib.Csv.Writer
{
    public sealed class CsvRowBuilder
    {
        private readonly List<string> cells;

        internal CsvRowBuilder()
        {
            this.cells = new List<string>();
        }

        public CsvRowBuilder AppendCell(string value)
        {
            this.cells.Add(value);
            return this;
        }

        internal string ToLine()
            => this.cells.Aggregate((concat, curr) => string.Format("{0},{1}", concat, curr));
    }
}
