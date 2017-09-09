using Fiver.Lib.Csv.Writer;
using Fiver.Lib.Csv.Writer.Source;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Fiver.Csv.Tests
{
    public class WriterTests
    {
        [Fact(DisplayName = "Adding_data_to_builder_produces_comma_separated_lines")]
        public void Adding_data_to_builder_produces_comma_separated_lines()
        {
            // Arrange
            var lines = new List<string>();

            var mockWriter = new Mock<ICsvWriter>();
            mockWriter.Setup(writer => writer.Write(It.IsAny<List<string>>()))
                      .Callback<List<string>>(rows => lines = rows);

            var builder = new CsvBuilder();
            
            // Act
            builder.AppendRow()
                   .AppendCell("Id")
                   .AppendCell("Title")
                   .AppendCell("Year");
            
            builder.AppendRow()
                   .AppendCell("1")
                   .AppendCell("Dr. No")
                   .AppendCell("1963");

            builder.WriteTo(mockWriter.Object);
           
            // Assert
            Assert.Equal(expected: 2, actual: lines.Count);
            Assert.Equal(expected: "Id,Title,Year", actual: lines[0]);
            Assert.Equal(expected: "1,Dr. No,1963", actual: lines[1]);
        }
    }
}
