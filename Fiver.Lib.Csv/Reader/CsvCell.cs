namespace Fiver.Lib.Csv.Reader
{
    public sealed class CsvCell
    {
        internal CsvCell(string header, string value)
        {
            this.Header = header;
            this.Value = value;
        }
        
        public string Header { get; }
        public string Value { get; }
    }
}
