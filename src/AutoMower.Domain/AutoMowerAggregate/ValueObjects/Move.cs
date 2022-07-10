namespace AutoMower.Domain.AutoMowerAggregate.ValueObjects
{
    public readonly struct Move
    {
        public Direction Direction { get; }
        public int Steps { get; }

        public Move(Direction direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
    }
}
