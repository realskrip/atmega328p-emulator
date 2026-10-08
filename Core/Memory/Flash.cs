namespace Core.Memory
{
    internal class Flash
    {
        private const int atmega328pFlashSize = 32768;
        private byte[] flash = new byte[atmega328pFlashSize];

        internal void LoadFirmware(byte[] firmware)
        {
            for (int i = 0; i < atmega328pFlashSize; i++)
                flash[i] = firmware[i];
        }
    }
}