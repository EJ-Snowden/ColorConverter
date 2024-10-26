using System;

namespace Covide.Web.Utilities
{
    public static class MathUtilities
    {
        public const double Tolerance = 0.0001;

        public static bool AreApproximatelyEqual(double a, double b)
        {
            return Math.Abs(a - b) < Tolerance;
        }
    }
}
