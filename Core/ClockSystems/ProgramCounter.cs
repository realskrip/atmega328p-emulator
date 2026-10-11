using Core.ClockSystems.InstructionPipeline;

namespace Core.ClockSystems
{
    internal static class ProgramCounter
    {
        private static int instructionAddress = -1;

        internal static int GetInstructionAddress(bool tact, InstructionStage.Stage stage)
        {
            if (tact == true && stage == InstructionStage.Stage.Fetch)
                instructionAddress++;

            return instructionAddress;
        }
    }
}