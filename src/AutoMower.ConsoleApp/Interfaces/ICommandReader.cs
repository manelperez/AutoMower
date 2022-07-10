using AutoMower.Application.ViewModels;

namespace AutoMower.ConsoleApp.Interfaces
{
    public interface ICommandReader
    {
        public WorkOrder ReadAllCommands();
    }
}