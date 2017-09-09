using Fiver.Lib.Csv.Reader;
using Fiver.Lib.Csv.Reader.Source;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fiver.Lib.Csv.Tests
{
    public class ReaderTests
    {
        [Fact(DisplayName = "Reading_data_fills_table")]
        public void Reading_data_fills_table()
        {
            // Arrange
            var mockReader = new Mock<ICsvReader>();
            mockReader.Setup(reader => reader.Read())
                      .Returns(new List<string>
                      {
                        "Id,Title,Year,Summary",
                        "1,Dr. No,1963,Excellent",
                        "2,Goldfinger,1965,Good"
                      });

            // Act
            var table = CsvTable.ReadFrom(mockReader.Object);
            
            // Assert
            Assert.Equal(expected: 2, actual: table.Rows.Count());
            Assert.Equal(expected: "Dr. No", actual: table.Rows[0].Cells[1].Value);
        }
    }
}
