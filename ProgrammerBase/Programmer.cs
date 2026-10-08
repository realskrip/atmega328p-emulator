//:020000020000FC
//:1000000000E204B915B1102715B901D0FBCF2AE0E1
//:100010003FEF4FEF4A95F1F73A95D9F72A95C1F797
//:02002000089541
//:00000001FF

namespace ProgrammerBase
{
    public class Programmer
    {
        public byte[] GetFirmwareFromHex(string path)
        {
            IEnumerable<string> records = File.ReadLines(path);
            return RecordParse(records);
        }

        //intel HEX
        //:LLAAAATTDD…CC
        private byte[] RecordParse(IEnumerable<string> records)
        {
            int baseAddress = 0;
            //Программатор не должен знать, какой размер flash памяти у микроконтроллера
            byte[] flashBuffer = new byte[32768];

            foreach (string item in records)
            {
                string record = item.TrimStart(':');

                string LL = record.Substring(0, 2);
                string AAAA = record.Substring(2, 4);
                string TT = record.Substring(6, 2);
                string DD = record.Substring(8, record.Length - 10);
                string CC = record.Substring(record.Length - 2, 2);

                if (TT == "00")
                {
                    int flashBufferIndex = baseAddress + Convert.ToInt32(AAAA, 16);
                    byte[] data = Convert.FromHexString(DD);

                    for (int i = 0; i < Convert.ToInt32(LL, 16); i++)
                    {
                        flashBuffer[flashBufferIndex] = data[i];
                        flashBufferIndex++;
                    }
                }
                else if (TT == "01")
                    continue;
                else if (TT == "02")
                {
                    int segment = Convert.ToInt32(DD, 16);
                    baseAddress = segment << 4;
                }
            }

            return flashBuffer;
        }
    }
}