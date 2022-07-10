using AutoMower.Domain.AutoMowerAggregate.ValueObjects;

namespace AutoMower.Domain.AutoMowerAggregate.Interfaces
{
    public interface IMower : IAggregateRoot
    {
        public Dictionary<Position, bool> MowedPositions { get; set; }

        public void JumpTo(Position position);

        public void MoveTowards(Direction direction, int steps);
    }
}
