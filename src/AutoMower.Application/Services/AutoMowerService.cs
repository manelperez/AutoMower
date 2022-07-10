using AutoMower.Application.Mappers;
using AutoMower.Application.Services.Interfaces;
using AutoMower.Application.ViewModels;
using AutoMower.Domain.AutoMowerAggregate;
using AutoMower.Domain.AutoMowerAggregate.Interfaces;
using AutoMower.Domain.AutoMowerAggregate.ValueObjects;

namespace AutoMower.Application.Services
{
    public class AutoMowerService : IAutoMowerService
    {
        private readonly WorkOrderMapper _workOrderMapper;

        public AutoMowerService(WorkOrderMapper workOrderMapper)
        {
            _workOrderMapper = workOrderMapper;
        }

        public int WorkSession(WorkOrder workOrder)
        {
            IMower mower = new Mower();

            Position startingPosition = _workOrderMapper.ConvertToPosition(workOrder.StartingPosition);
            IEnumerable<Move> moves = _workOrderMapper.ConvertToMove(workOrder.Moves);

            mower.JumpTo(startingPosition);
            foreach (var move in moves)
            {
                mower.MoveTowards(move.Direction, move.Steps);
            }
            return mower.MowedPositions.Count;
        }
    }
}
