using AutoMower.Application.ViewModels;
using AutoMower.ConsoleApp.Controllers;
using AutoMower.ConsoleApp.Interfaces;
using Moq;

namespace AutoMower.Tests.UnitTests.ConsoleApp.Controllers
{
    public class AutoMowerControllerTests
    {
        private readonly Mock<IView> _mockIView = new Mock<IView>();
        private readonly Mock<ICommandReader> _mockICommandReader = new Mock<ICommandReader>();

        [Fact]
        public void Run_should_display_places_cleaned()
        {
            var SUT = new AutoMowerController(_mockICommandReader.Object, _mockIView.Object);

            ////Arrange
            _mockICommandReader.Setup(x => x.ReadAllCommands()).Returns(new WorkOrder(new PositionViewModel(10, 22), new List<MoveViewModel> { new MoveViewModel("E", 1), new MoveViewModel("N", 2) }));
            _mockIView.Setup(x => x.WriteLine(It.IsAny<String>()));

            //Act
            SUT.Run();

            _mockIView.Verify(w => w.WriteLine(It.Is<string>(s => s == "=> Mowed: 4")), Times.Once);
        }

    }
}
