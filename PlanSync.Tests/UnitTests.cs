using Xunit;
using PlanSync;
using FluentAssertions;

namespace PlanSync.Tests
{
    public class UnitTests
    {
        [Fact]
        public void ShouldReadPLN()
        {
            var fp = Utilities.ReadFlightPlan(@"C:\Users\Ian\source\repos\PlanSync\PLNFiles\EGKKEKVG_MFS_11May21.pln");

            fp.DestinationID.Should().Be("EKVG");
            fp.DepartureID.Should().Be("EGKK");
        }
    }
}