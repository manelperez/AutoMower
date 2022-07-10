using AutoMower.Application.ViewModels;

namespace AutoMower.Application.Services.Interfaces
{
    public interface IAutoMowerService
    {
        public int WorkSession(WorkOrder workOrder);
    }
}