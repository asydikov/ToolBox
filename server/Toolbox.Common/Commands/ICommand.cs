using System;

namespace ToolBox.Common.Commands
{
    public interface ICommand
    {
        public Guid Id { get; }
    }
}