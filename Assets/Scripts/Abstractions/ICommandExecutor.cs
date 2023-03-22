using System.Threading.Tasks;

public interface ICommandExecutor
{
    Task TryExecuteCommand(object command);
}

public interface ICommandExecutor<T> : ICommandExecutor where T : ICommand
{

}
