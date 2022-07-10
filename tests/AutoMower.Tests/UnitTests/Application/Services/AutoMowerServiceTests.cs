using AutoMower.Application.Mappers;
using AutoMower.Application.Services;
using AutoMower.Application.Services.Interfaces;
using AutoMower.Application.ViewModels;
using Moq;

namespace AutoMower.Tests.UnitTests.Application.Services
{
    public class AutoMowerServiceTests
    {
        private readonly Mock<IAutoMowerService> _mockIAutoMowerService = new Mock<IAutoMowerService>();
        private readonly Mock<WorkOrderMapper> _mockWorkOrderMapper = new Mock<WorkOrderMapper>();
        private readonly Mock<WorkOrder> _mockWorkOrder = new Mock<WorkOrder>();

        [Fact]
        public void WorkSession_integer_input_should_return_integer()
        {
            var workOrderDTO = new WorkOrder(new PositionViewModel(10, 22), new List<MoveViewModel> { new MoveViewModel("E", 1), new MoveViewModel("N", 2) });

            AutoMowerService sut = new AutoMowerService(_mockWorkOrderMapper.Object);
            
            //Arrange
            _mockIAutoMowerService.Setup(x => x.WorkSession(workOrderDTO)).Returns<int>(x => x);

            //Act
            object result = sut.WorkSession(workOrderDTO);

            Assert.Equal(4, result);
        }
    }
}