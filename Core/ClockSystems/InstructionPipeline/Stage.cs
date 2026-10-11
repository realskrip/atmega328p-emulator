namespace Core.ClockSystems.InstructionPipeline
{
    internal static class Stage
    {
        private static InstructionStage.Stage instructionStage;
        private static InstructionStage.Stage previousStage = InstructionStage.Stage.Fetch;

        internal static InstructionStage.Stage GetStage(bool tact)
        {
            if (tact == true)
            {
                if (previousStage == InstructionStage.Stage.Fetch)
                {
                    instructionStage = previousStage;
                    previousStage = InstructionStage.Stage.Execute;
                }
                else if (previousStage == InstructionStage.Stage.Execute)
                {
                    instructionStage = previousStage;
                    previousStage = InstructionStage.Stage.Fetch;
                }

                return instructionStage;
            }
            else
                return previousStage;
        }
    }
}