namespace TechFlurry.GeoLocation.Models
{
    internal class GeoLocationWithDistance<T>
    {
        public double DistanceFromOrigion { get; internal set; }
        public T Point { get; internal set; }
    }
}
