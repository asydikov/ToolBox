using System;

namespace ToolBox.Common.Commands
{
    public interface ICommand
    {
        Guid CommandId { get; set; }
    }
}