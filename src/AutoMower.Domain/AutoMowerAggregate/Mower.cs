using AutoMower.Domain.AutoMowerAggregate.Interfaces;
using AutoMower.Domain.AutoMowerAggregate.ValueObjects;

namespace AutoMower.Domain.AutoMowerAggregate
{
    public class Mower : IMower
    {
        private Position _currentPosition;

        public Dictionary<Position, bool> MowedPositions { get; set; }
        public Position CurrentPosition
        {
            get { return _currentPosition; }
            private set
            {
                _currentPosition = value;
                MowCurrentPosition();
            }
        }

        public Mower()
        {
            MowedPositions = new Dictionary<Position, bool>();
        }

        public void JumpTo(Position position)
        {
            CurrentPosition = position;
        }

        public void MoveTowards(Direction direction, int steps)
        {
            Position directionStep = CoordinateMap.GetDirectionStep(direction);
            for (int i = 0; i < steps; i++)
            {
                CurrentPosition = new Position(CurrentPosition.X + directionStep.X, CurrentPosition.Y + directionStep.Y);
            }
        }

        private void MowCurrentPosition()
        {
            MowedPositions[CurrentPosition] = true;
        }
    }
}