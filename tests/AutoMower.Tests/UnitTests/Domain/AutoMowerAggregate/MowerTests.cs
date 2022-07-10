using AutoMower.Domain.AutoMowerAggregate;
using AutoMower.Domain.AutoMowerAggregate.ValueObjects;

namespace AutoMower.Tests.UnitTests.Domain.AutoMowerAggregate
{
    public class MowerTests
    {
        [Fact]
        public void JumpTo_position_should_change_CurrentPosition()
        {
            Mower SUT = new Mower();

            //Act
            SUT.JumpTo(new Position(-2000, 3000));

            Assert.Equal(-2000, SUT.CurrentPosition.X);
            Assert.Equal(3000, SUT.CurrentPosition.Y);
        }

        [Fact]
        public void MoveTowards_direction_E_should_change_CurrentPosition()
        {
            Mower SUT = new Mower();

            //Act
            SUT.JumpTo(new Position(0, 0));

            SUT.MoveTowards(Direction.E, 2000);

            Assert.Equal(2000, SUT.CurrentPosition.X);
            Assert.Equal(0, SUT.CurrentPosition.Y);
        }

        [Fact]
        public void MoveTowards_direction_W_should_change_CurrentPosition()
        {
            Mower SUT = new Mower();

            //Act
            SUT.JumpTo(new Position(0, 0));
            SUT.MoveTowards(Direction.W, 2000);

            Assert.Equal(-2000, SUT.CurrentPosition.X);
            Assert.Equal(0, SUT.CurrentPosition.Y);
        }

        [Fact]
        public void MoveTowards_direction_N_should_change_CurrentPosition()
        {
            Mower SUT = new Mower();

            //Act
            SUT.JumpTo(new Position(0, 0));
            SUT.MoveTowards(Direction.N, 2000);

            Assert.Equal(0, SUT.CurrentPosition.X);
            Assert.Equal(2000, SUT.CurrentPosition.Y);
        }

        [Fact]
        public void MoveTowards_direction_S_should_change_CurrentPosition()
        {
            Mower SUT = new Mower();

            //Act
            SUT.JumpTo(new Position(0, 0));
            SUT.MoveTowards(Direction.S, 2000);

            Assert.Equal(0, SUT.CurrentPosition.X);
            Assert.Equal(-2000, SUT.CurrentPosition.Y);
        }
    }
}
