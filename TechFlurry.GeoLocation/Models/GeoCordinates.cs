namespace TechFlurry.GeoLocation.Models
{
    /// <summary>
    /// Abstract Interface to store location attributes
    /// </summary>
    public interface IGeoCordinates
    {
        decimal? Latitude { get; set; }
        decimal? Longitude { get; set; }
        decimal? Radius { get; set; }
    }
    /// <summary>
    /// The distance type to return the results in.
    /// </summary>
    public enum DistanceType
    {
        Miles = 0,
        Kilometers = 1
    };
}
