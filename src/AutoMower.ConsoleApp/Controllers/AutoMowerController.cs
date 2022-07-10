using AutoMower.Application.Mappers;
using AutoMower.Application.Services;
using AutoMower.Application.Services.Interfaces;
using AutoMower.Application.ViewModels;
using AutoMower.ConsoleApp.Interfaces;

namespace AutoMower.ConsoleApp.Controllers
{
    public class AutoMowerController
    {
        private ICommandReader _commandReader;
        private IView _view;

        public AutoMowerController(ICommandReader commandReader, IView view)
        {
            _commandReader = commandReader;
            _view = view;
        }
        public void Run()
        {
            WorkOrder workOrder = _commandReader.ReadAllCommands();
            IAutoMowerService autoMower = new AutoMowerService(new WorkOrderMapper());
            int placesMowed = autoMower.WorkSession(workOrder);
            _view.WriteLine($"=> Mowed: {placesMowed}");
        }
    }
}