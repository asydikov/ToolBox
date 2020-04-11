using System.Threading.Tasks;

namespace ToolBox.Common.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}