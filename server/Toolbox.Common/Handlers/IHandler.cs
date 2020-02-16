using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Common.Exceptions;

namespace Toolbox.Common.Handlers
{
    public interface IHandler
    {
        IHandler Handle(Func<Task> handle);
        IHandler OnSuccess(Func<Task> onSuccess);
        IHandler OnError(Func<Exception, Task> onError, bool rethrow = false);
        IHandler OnCustomError(Func<ToolBoxException, Task> onCustomError, bool rethrow = false);
        IHandler Always(Func<Task> always);
        Task ExecuteAsync();
    }
}
