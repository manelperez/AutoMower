namespace AutoMower.Application.ViewModels
{
    public class PositionViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PositionViewModel(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}