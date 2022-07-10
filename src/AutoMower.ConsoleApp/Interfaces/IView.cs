using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMower.ConsoleApp.Interfaces
{
    public interface IView
    {
        public string ReadLine();
        public void WriteLine(string output);
    }
}
