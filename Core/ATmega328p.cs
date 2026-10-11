namespace Core
{
    public class ATmega328p
    {
        private Memory.Flash flash = new Core.Memory.Flash();
        
        public void LoadFirmwareInFlash(byte[] firmware)
        {
            flash.LoadFirmware(firmware);
        }
        
        public void Run()
        {
            MainCycle();
        }

        private void MainCycle()
        {
            bool clock;
            int instructionAddress;
            ClockSystems.InstructionPipeline.InstructionStage.Stage stage;

            while (true)
            {
                clock = ClockSystems.CalibratedRCOscillator.Clock();
                stage = ClockSystems.InstructionPipeline.Stage.GetStage(clock);
                instructionAddress = ClockSystems.ProgramCounter.GetInstructionAddress(clock, stage);

                Console.WriteLine(clock);
                Console.WriteLine(stage);
                Console.WriteLine(instructionAddress);
                Console.WriteLine();
            }
        }
    }
}