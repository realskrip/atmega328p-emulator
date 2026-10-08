namespace Console
{
    internal class Program
    {
        static void Main()
        {
            ProgrammerBase.Programmer programmer = new ProgrammerBase.Programmer();
            Core.ATmega328p aTmega328P = new Core.ATmega328p();

            byte[] firmware = programmer.GetFirmwareFromHex(@"c:\blink.hex");

            aTmega328P.LoadFirmwareFlash(firmware);
            aTmega328P.Run();
        }
    }
}