using KomodoBank.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBankUI
{
    public class ProgramUI
    {
        private readonly IConsole _console;

        public ProgramUI(IConsole consoleForAllReadsAndWrites)
        {
            _console = consoleForAllReadsAndWrites;
        }

        public void Run()
        {
            bool finished = false;

            do
            {
                _console.WriteLine("What would you like to do?\r\n " +
                                   "1. Create an account\r\n " +
                                   "2. Deposit\r\n " +
                                   "3. Withdraw\r\n " +
                                   "4. Transfer\r\n " +
                                   "5. View all accounts\r\n " +
                                   "6. View all checking accounts\r\n " +
                                   "7. View all savings accounts\r\n " +
                                   "8. Find specific account\r\n " +
                                   "9. Exit program\r\n ");

                var command = _console.ReadLine().ToLower();

                if (String.IsNullOrWhiteSpace(command))
                {
                    finished = true;
                }
                else if (command == "1")
                {
                    //TODO
                }
                else if (command == "2")
                {
                    //TODO
                }
                else if (command == "3")
                {
                    //TODO
                }
                else if (command == "4")
                {
                    //TODO
                }
                else if (command == "5")
                {
                    //TODO
                }
                else if (command == "6")
                {
                    //TODO
                }
                else if (command == "7")
                {
                    //TODO
                }
                else if (command == "8")
                {
                    //TODO
                }
                else if (command == "9")
                {
                    finished = true;
                }
                else
                {
                    _console.WriteLine("Please enter a valid number");
                }
            } while (!finished);
        }
    
    }


}
