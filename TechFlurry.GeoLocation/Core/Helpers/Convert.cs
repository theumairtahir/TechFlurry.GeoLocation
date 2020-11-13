using System;

namespace TechFlurry.GeoLocation.Core.Helpers
{
    internal static class Convert
    {
        /// <summary>
        /// Convert to Radians.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double ToRadian(decimal? val)
        {
            return (Math.PI / 180) * System.Convert.ToDouble(val);
        }
    }
}
