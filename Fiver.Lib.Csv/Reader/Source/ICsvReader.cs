using System.Collections.Generic;

namespace Fiver.Lib.Csv.Reader.Source
{
    public interface ICsvReader
    {
        List<string> Read();
    }
}
