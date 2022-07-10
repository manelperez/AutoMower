using AutoMower.Application.ViewModels;
using AutoMower.ConsoleApp;
using AutoMower.ConsoleApp.Interfaces;
using AutoMower.Domain.AutoMowerAggregate.ValueObjects;
using Moq;
using Newtonsoft.Json;
using System.Reflection;

namespace AutoMower.Tests.UnitTests.ConsoleApp
{
    public class CommandReaderTests
    {
        private readonly Mock<IView> _mockIView = new Mock<IView>();

        [Fact]
        public void ReadAmountOfMoves_integer_input_should_return_integer()
        {
            var sut = new CommandReader(_mockIView.Object);

            //Arrange
            _mockIView.Setup(x => x.ReadLine()).Returns("44");

            //Act            
            MethodInfo methodInfo = typeof(CommandReader).GetMethod("ReadAmountOfMoves", BindingFlags.NonPublic | BindingFlags.Instance);

            object result = methodInfo.Invoke(sut, null);

            Assert.Equal(44, result);
        }

        [Fact]
        public void ReadStartingPosition_string_input_should_return_position()
        {
            var sut = new CommandReader(_mockIView.Object);

            //Arrange
            _mockIView.Setup(x => x.ReadLine()).Returns("12 45");

            //Act
            MethodInfo methodInfo = typeof(CommandReader).GetMethod("ReadStartingPosition", BindingFlags.NonPublic | BindingFlags.Instance);

            object result = methodInfo.Invoke(sut, null);

            var object1Json = JsonConvert.SerializeObject(new PositionViewModel(12, 45));
            var object2Json = JsonConvert.SerializeObject(result);

            Assert.Equal(object1Json, object2Json);
        }

        [Fact]
        public void ReadMove_string_input_should_return_move()
        {
            var sut = new CommandReader(_mockIView.Object);

            //Arrange
            _mockIView.Setup(x => x.ReadLine()).Returns("E 26");

            //Act
            MethodInfo methodInfo = typeof(CommandReader).GetMethod("ReadMove", BindingFlags.NonPublic | BindingFlags.Instance);

            object result = methodInfo.Invoke(sut, null);

            var object1Json = JsonConvert.SerializeObject(new MoveViewModel("E", 26));
            var object2Json = JsonConvert.SerializeObject(result);

            Assert.Equal(object1Json, object2Json);
        }
        [Fact]
        public void ReadAllCommand_text_sequence_input_should_return_CleanningSession()
        {
            var SUT = new CommandReader(_mockIView.Object);

            //Arrange
            _mockIView.SetupSequence(x => x.ReadLine()).Returns("4")
                .Returns("-100 -101")
                .Returns("N 100")
                .Returns("E 1000")
                .Returns("S 500")
                .Returns("W 10");

            //Act
            WorkOrder result = SUT.ReadAllCommands();

            Assert.Equal(-100, result.StartingPosition.X);
            Assert.Equal(-101, result.StartingPosition.Y);
            Assert.Equal(4, result.Moves.Count);

            Assert.Equal(Direction.N.ToString(), result.Moves[0].Direction);
            Assert.Equal(100, result.Moves[0].Steps);

            Assert.Equal(Direction.E.ToString(), result.Moves[1].Direction);
            Assert.Equal(1000, result.Moves[1].Steps);

            Assert.Equal(Direction.S.ToString(), result.Moves[2].Direction);
            Assert.Equal(500, result.Moves[2].Steps);

            Assert.Equal(Direction.W.ToString(), result.Moves[3].Direction);
            Assert.Equal(10, result.Moves[3].Steps);
        }
    }
}