namespace AutoMower.Application.ViewModels
{
    public class MoveViewModel
    {
        public string Direction { get; set; }
        public int Steps { get; set; }

        public MoveViewModel(string direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
    }
}
