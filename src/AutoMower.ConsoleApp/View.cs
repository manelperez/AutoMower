using AutoMower.ConsoleApp.Interfaces;

namespace AutoMower.ConsoleApp
{
    public class View : IView
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
