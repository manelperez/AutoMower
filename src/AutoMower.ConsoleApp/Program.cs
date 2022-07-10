using AutoMower.ConsoleApp.Controllers;
using AutoMower.ConsoleApp.Interfaces;

namespace AutoMower.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IView view = new View();
            ICommandReader commandReader = new CommandReader(view);
            var controller = new AutoMowerController(commandReader, view);
            controller.Run();
        }
    }
}