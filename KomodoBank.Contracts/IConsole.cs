using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Contracts
{
    public interface IConsole
    {
        void WriteLine(string message);
        void WriteLine();
        void Write(string message);
        string ReadLine();
        void WriteLine(Object o);
    }
}
