using System;
using Xunit;
using FullerProjection.Geometry.Coordinates;
using FullerProjection.Geometry.Angles;

namespace FullerProjection.Test
{
    public class GeodesicTests
    {
        [Theory]
        [InlineData(90, 30)]
        [InlineData(-90, 30)]
        [InlineData(0, 30)]
        [InlineData(0.1278, 30)]
        [InlineData(0.1278, 359)]
        [InlineData(0.1278, 0)]
        [InlineData(0.1278, 51.5074)]
        public void Can_create(double rawLat, double rawLon)
        {
            var lat = Angle.From(new Degrees(rawLat));
            var lon = Angle.From(new Degrees(rawLon));
            var point = new Geodesic(lat, lon);

            Assert.Equal(lat, point.Latitude);
            Assert.Equal(lon, point.Longitude);
        }

        [Theory]
        [InlineData(-91.56)]
        [InlineData(91.56)]
        public void Latitude_outside_range_minus_90_to_90_throws(double rawLat)
        {
            var lat = Angle.From(new Degrees(rawLat));
            var lon = Angle.From(new Degrees(0.1278));
            
            Assert.Throws<ArgumentException>(() => new Geodesic(lat, lon));
        }

        [Theory]
        [InlineData(-1.23, 358.77)]
        [InlineData(361.23, 1.23)]
        [InlineData(725.23, 5.23)]
        [InlineData(-725.23, 354.77)]
        public void Longitude_outside_range_0_to_360_wraps(double rawLon, double expected)
        {
            var lat = Angle.From(new Degrees(10.5074));
            var lon = Angle.From(new Degrees(rawLon));
            
            var point = new Geodesic(lat, lon);

            var expectedAngle = Angle.From(new Degrees(expected));
            Assert.Equal(expectedAngle, point.Longitude);
        }
    }
}
