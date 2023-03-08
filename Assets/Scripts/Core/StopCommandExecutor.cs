using UnityEngine;

namespace Core
{
    internal class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log(gameObject.name + " stops");
        }
    }
}
