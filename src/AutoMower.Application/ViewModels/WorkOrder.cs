namespace AutoMower.Application.ViewModels
{
    public class WorkOrder
    {
        public PositionViewModel StartingPosition { get; set; }
        public List<MoveViewModel> Moves { get; set; }

        public WorkOrder(PositionViewModel startingPosition, List<MoveViewModel> moves)
        {
            StartingPosition = startingPosition;
            Moves = moves;
        }
    }
}
