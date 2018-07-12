using KomodoBank.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBank.Tests
{
    [ExcludeFromCodeCoverage]
    class MockConsole : IConsole
    {
        public Queue<string> UserInput;
        public string Output;

        public MockConsole(IEnumerable<string> input)
        {
            UserInput = new Queue<string>(input);
            Output = "";
        }

        public void WriteLine(string message)
        {
            Output += message + "\r\n";
        }

        public void Write(string message)
        {
            Output += message;
        }
        public void WriteLine(Object o)
        {
            Output += o.ToString() + "\r\n";
        }

        public string ReadLine()
        {
            if (UserInput.Count == 0)
                return "";
            return UserInput.Dequeue();
        }

        public void WriteLine()
        {
            throw new NotImplementedException();
        }
    }
}
