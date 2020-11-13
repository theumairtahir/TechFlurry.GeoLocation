using System;
using TechFlurry.GeoLocation.Models;

namespace TechFlurry.GeoLocation.Core
{
    public class Calculations
    {
        /// <summary>
        /// Returns the distance in miles or kilometers of any two
        /// latitude / longitude points.
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static double Distance(IGeoCordinates pos1, IGeoCordinates pos2, DistanceType type = DistanceType.Kilometers)
        {
            double R = (type == DistanceType.Miles) ? 3960 : 6371;

            double dLat = Helpers.Convert.ToRadian(pos2.Latitude - pos1.Latitude);
            double dLon = Helpers.Convert.ToRadian(pos2.Longitude - pos1.Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(Helpers.Convert.ToRadian(pos1.Latitude)) * Math.Cos(Helpers.Convert.ToRadian(pos2.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;

            return d;
        }

    }
}
