using AutoMower.Application.ViewModels;
using AutoMower.ConsoleApp.Interfaces;

namespace AutoMower.ConsoleApp
{
    public class CommandReader : ICommandReader
    {
        private IView _view;

        public CommandReader(IView view)
        {
            _view = view;
        }

        public WorkOrder ReadAllCommands()
        {
            int amountOfMoves = this.ReadAmountOfMoves();
            PositionViewModel startingPosition = this.ReadStartingPosition();
            List<MoveViewModel> moves = new List<MoveViewModel>();
            while (moves.Count < amountOfMoves)
            {
                moves.Add(this.ReadMove());
            }
            WorkOrder work = new WorkOrder(startingPosition, moves);
            return work;
        }

        private MoveViewModel ReadMove()
        {
            string line = _view.ReadLine();
            string[] move = line.Split(' ');
            string direction = move[0].ToString();
            int steps = int.Parse(move[1]);
            return new MoveViewModel(direction, steps);
        }

        private PositionViewModel ReadStartingPosition()
        {
            string line = _view.ReadLine();
            string[] coordinates = line.Split(' ');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);
            return new PositionViewModel(x, y);
        }

        private int ReadAmountOfMoves()
        {
            return int.Parse(_view.ReadLine());
        }
    }
}
