using UnityEngine;
using Zenject;

namespace Core
{
    public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
    {
        [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
        [Inject] CommandExecutorBase<ISetRallyPointCommand> _setRallyPointExecutor;

        public void Clear() { }

        public async void EnqueueCommand(object command)
        {
            await _produceUnitCommandExecutor.TryExecuteCommand(command);
            await _setRallyPointExecutor.TryExecuteCommand(command);
        }
    }
}