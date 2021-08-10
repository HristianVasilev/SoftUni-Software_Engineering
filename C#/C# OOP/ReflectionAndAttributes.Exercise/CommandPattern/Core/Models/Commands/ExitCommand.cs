using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Models.Commands
{
    class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return null;
        }
    }
}
