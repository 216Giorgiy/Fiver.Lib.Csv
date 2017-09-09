using Fiver.Lib.Csv.Reader.Source;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiver.Lib.Csv.Reader
{
    public sealed class CsvTable
    {
        private readonly List<CsvRow> rows;

        private CsvTable()
        {
            this.rows = new List<CsvRow>();
        }

        public IReadOnlyList<CsvRow> Rows => this.rows;

        public CsvRow Header
            => new CsvRow(
                this.rows.First().Cells
                                 .Select(cell => new CsvCell(cell.Header, cell.Header))
                                 .ToList());
        
        public static CsvTable ReadFrom(ICsvReader reader)
            => ReadFrom(() => reader.Read());
        
        public static CsvTable ReadFrom(Func<List<string>> reader)
        {
            var table = new CsvTable();

            var lines = reader();
            var headers = lines.First().Split(',');

            foreach (var line in lines.Skip(1))
            {
                var cells = new List<CsvCell>();
                var y = 0;
                foreach (var dataValue in line.Split(','))
                {
                    var cell = new CsvCell(headers[y], dataValue);
                    cells.Add(cell);
                    y += 1;
                }
                table.rows.Add(new CsvRow(cells));
            }

            return table;
        }
    }
}
