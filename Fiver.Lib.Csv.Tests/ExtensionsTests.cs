using System.Collections.Generic;
using System.Linq;
using Xunit;
using Fiver.Lib.Csv.Reader;
using Fiver.Lib.Csv.Extensions;
using Fiver.Lib.Csv.Writer;

namespace Fiver.Lib.Csv.Tests
{
    public class ExtensionsTests
    {
        [Fact(DisplayName = "Convert_table_to_builder")]
        public void Convert_table_to_builder()
        {
            // Arrange
            var table = CsvTable.ReadFrom(() => new List<string>
                                                {
                                                    "Id,Title,Year,Summary",
                                                    "1,Dr. No,1963,Excellent",
                                                    "2,Goldfinger,1965,Good"
                                                });

            var lines = new List<string>();
            
            // Act
            var builder = table.ToBuilder();
            builder.WriteTo(rows => lines = rows);

            // Assert
            Assert.Equal(expected: 3, actual: lines.Count);
            Assert.Equal(expected: "Id,Title,Year,Summary", actual: lines[0]);
            Assert.Equal(expected: "1,Dr. No,1963,Excellent", actual: lines[1]);
        }

        [Fact(DisplayName = "Convert_builder_to_table")]
        public void Convert_builder_to_table()
        {
            // Arrange
            var builder = new CsvBuilder();

            builder.AppendRow()
                   .AppendCell("Id")
                   .AppendCell("Title")
                   .AppendCell("Year");

            builder.AppendRow()
                   .AppendCell("1")
                   .AppendCell("Dr. No")
                   .AppendCell("1963");

            // Act
            var table = builder.ToTable();
            
            // Assert
            Assert.Equal(expected: 1, actual: table.Rows.Count());
            Assert.Equal(expected: "Dr. No", actual: table.Rows[0].Cells[1].Value);
        }
    }
}
