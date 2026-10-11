namespace Core.ClockSystems
{
    internal static class CalibratedRCOscillator
    {
        private static bool tact = false;

        internal static bool Clock()
        {
            if (tact == false)
                tact = true;
            else if (tact == true)
                tact = false;

            return tact;
        }
    }
}