using System;
using Xunit;
using FullerProjection.Core.Geometry.Angles;
using static FullerProjection.Core.Geometry.Angles.AngleMath;

namespace FullerProjection.UnitTests.Core
{
    public class AngleMathTests
    {
        [Fact]
        public void Can_calculate_sin_of_angle()
        {
            var angle = Angle.From(Degrees.FromRaw(90));

            var result = Sin(angle);

            var expected = 1;
            Assert.Equal(expected, result, DoubleComparisonPrecision);
        }

        [Fact]
        public void Can_calculate_cos_of_angle()
        {
            var angle = Angle.From(Degrees.FromRaw(90));

            var result = Cos(angle);

            var expected = 0;
            Assert.Equal(expected, result, DoubleComparisonPrecision);
        }

        [Fact]
        public void Can_calculate_tan_of_angle()
        {
            var angle = Angle.From(Degrees.FromRaw(30));

            var result = Tan(angle);

            var expected = 0.5773502691996256;
            Assert.Equal(expected, result, DoubleComparisonPrecision);
        }

        [Fact]
        public void Can_calculate_arctan_of_angle()
        {
            var value = 0.5773502691996256;
            var expected = Angle.From(Degrees.FromRaw(30));

            var result = Atan(value);

            Assert.Equal(expected.Degrees.Value, result.Degrees.Value, 5);
        }

        private const int DoubleComparisonPrecision = 10;
    }
}