using System.Collections.Generic;

namespace Fiver.Lib.Csv.Reader
{
    public sealed class CsvRow
    {
        private readonly List<CsvCell> cells;

        internal CsvRow(List<CsvCell> cells)
        {
            this.cells = cells;
        }

        public IReadOnlyList<CsvCell> Cells => this.cells;
    }
}
