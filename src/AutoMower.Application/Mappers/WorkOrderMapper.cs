using AutoMower.Application.ViewModels;
using AutoMower.Domain.AutoMowerAggregate.ValueObjects;

namespace AutoMower.Application.Mappers
{
    public class WorkOrderMapper
    {
        internal Position ConvertToPosition(PositionViewModel positionViewModel)
        {
            return new Position(positionViewModel.X, positionViewModel.Y);
        }

        internal IEnumerable<Move> ConvertToMove(IEnumerable<MoveViewModel> moveViewModels)
        {
            var moves = new List<Move>();
            foreach (var moveViewModel in moveViewModels)
            {
                var direction = CoordinateMap.GetDirection(moveViewModel.Direction);
                var move = new Move(direction, moveViewModel.Steps);
                moves.Add(move);
            }
            return moves;
        }


    }
}
