namespace AutoMower.Domain.AutoMowerAggregate.ValueObjects
{
    public readonly struct CoordinateMap
    {
        public static Position GetDirectionStep(Direction direction)
        {
            return _mapDirectionCoordinate[direction];
        }

        private static Dictionary<Direction, Position> _mapDirectionCoordinate = new Dictionary<Direction, Position>
        {
            {Direction.N, new Position(0, 1)},
            {Direction.S, new Position(0, -1)},
            {Direction.E, new Position(1, 0)},
            {Direction.W, new Position(-1, 0)}
        };

        private static Dictionary<string, Direction> _mapDirectionName = new Dictionary<string, Direction>
        {
            {"N", Direction.N},
            {"S", Direction.S},
            {"E", Direction.E},
            {"W", Direction.W}
        };

        public static Direction GetDirection(string p)
        {
            return _mapDirectionName[p];
        }
    }
}
