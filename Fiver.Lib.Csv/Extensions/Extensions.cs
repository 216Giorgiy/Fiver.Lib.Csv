using Fiver.Lib.Csv.Reader;
using Fiver.Lib.Csv.Writer;

namespace Fiver.Lib.Csv.Extensions
{
    public static class Extensions
    {
        public static CsvBuilder ToBuilder(this CsvTable table)
        {
            var builder = new CsvBuilder();

            var builderHeader = builder.AppendRow();
            foreach (var cell in table.Header.Cells)
            {
                builderHeader.AppendCell(cell.Value);
            }

            foreach (var row in table.Rows)
            {
                var builderRow = builder.AppendRow();
                foreach (var cell in row.Cells)
                {
                    builderRow.AppendCell(cell.Value);
                }
            }
            
            return builder;
        }

        public static CsvTable ToTable(this CsvBuilder builder)
            => CsvTable.ReadFrom(() => builder.ToLines());
    }
}
