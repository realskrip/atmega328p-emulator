namespace Core
{
    public class ATmega328p
    {
        private Memory.Flash flash = new Core.Memory.Flash();
        
        public void LoadFirmwareFlash(byte[] firmware)
        {
            flash.LoadFirmware(firmware);
        }
        
        public void Run()
        {

        }
    }
}