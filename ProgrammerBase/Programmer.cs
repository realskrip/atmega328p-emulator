namespace ProgrammerBase
{
    public class Programmer
    {
        public byte[] GetFirmwareFromHex(string path)
        {
            IEnumerable<string> records = File.ReadLines(path);
            return  Parser.HEXparser.RecordParse(records);
        }
    }
}