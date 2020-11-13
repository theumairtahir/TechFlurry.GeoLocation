using System;
using System.Collections.Generic;
using System.Linq;
using TechFlurry.GeoLocation.Models;

namespace TechFlurry.GeoLocation.Core.Extentions
{
    public static class Extentions
    {
        /// <summary>
        /// Returns the distance from a location point to this point
        /// </summary>
        /// <param name="from">Point from which the distance is being calculated to this point</param>
        /// <param name="type">Kilometers/Meters</param>
        /// <returns></returns>
        public static double DistanceFromAPoint<T>(this IGeoCordinates to, T from, DistanceType type = DistanceType.Kilometers) where T : IGeoCordinates
        {
            //using haveresine's formula
            double R = (type == DistanceType.Miles) ? 3960 : 6371;

            double dLat = Helpers.Convert.ToRadian(to.Latitude - from.Latitude);
            double dLon = Helpers.Convert.ToRadian(to.Longitude - from.Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(Helpers.Convert.ToRadian(to.Latitude)) * Math.Cos(Helpers.Convert.ToRadian(from.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;

            return d;
        }
        /// <summary>
        /// Returns the distance from a location point to this point
        /// </summary>
        /// <param name="to"></param>
        /// <param name="type">Kilometers/Meters</param>
        /// <returns></returns>
        public static double DistanceToAPoint<T>(this IGeoCordinates from, T to, DistanceType type = DistanceType.Kilometers) where T : IGeoCordinates
        {
            //using haveresine's formula
            double R = (type == DistanceType.Miles) ? 3960 : 6371;

            double dLat = Helpers.Convert.ToRadian(to.Latitude - from.Latitude);
            double dLon = Helpers.Convert.ToRadian(to.Longitude - from.Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(Helpers.Convert.ToRadian(to.Latitude)) * Math.Cos(Helpers.Convert.ToRadian(from.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;

            return d;
        }
        /// <summary>
        /// Finds out the nearest point from a given list of points
        /// </summary>
        /// <typeparam name="T">Type of points type</typeparam>
        /// <param name="from">Cordinate point from which calculating</param>
        /// <param name="lstPoints">List of points from which get nearest</param>
        /// <param name="nearestPoint">Nearest point to be returned by the method (will be default if no point found nearest)</param>
        /// <param name="type">Distance Type (Kilometer/Miles)</param>
        /// <returns></returns>
        public static bool GetNearestPoint<T>(this IGeoCordinates from, List<T> lstPoints, out T nearestPoint, DistanceType type = DistanceType.Kilometers) where T : IGeoCordinates
        {
            List<GeoLocationWithDistance<T>> temp = new List<GeoLocationWithDistance<T>>();
            foreach (var point in lstPoints)
            {
                var distance = from.DistanceToAPoint(point, type);
                if (distance < Convert.ToDouble(point.Radius))
                {
                    temp.Add(new GeoLocationWithDistance<T> { DistanceFromOrigion = distance, Point = point });
                }
            }
            if (temp.Count > 0)
            {
                nearestPoint = temp.OrderBy(x => x.DistanceFromOrigion).First().Point;
                return true;
            }
            else
            {
                nearestPoint = Activator.CreateInstance<T>();
                return false;
            }
        }
    }
}
