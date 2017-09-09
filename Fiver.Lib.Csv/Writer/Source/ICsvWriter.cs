using System.Collections.Generic;

namespace Fiver.Lib.Csv.Writer.Source
{
    public interface ICsvWriter
    {
        void Write(List<string> lines);
    }
}