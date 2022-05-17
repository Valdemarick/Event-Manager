using Application.Common.Interfaces.Services;
using Moq;

namespace Tests.Mocks
{
    public class FakePlaceService
    {
        public Mock<IPlaceService> Mock;
        public IPlaceService Service;

        public FakePlaceService()
        {
            Mock = new Mock<IPlaceService>();
            Service = Mock.Object;
        }
    }
}