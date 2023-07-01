using UnityEngine;
using Zenject;

namespace Core
{
    public class AttackBuildingQueue : MonoBehaviour, ICommandsQueue
    {
        [Inject] CommandExecutorBase<IAttackCommand> _attackCommandExecutor;
        [Inject] CommandExecutorBase<IStopCommand> _stopCommandExecutor;

        public void Clear() { }

        public async void EnqueueCommand(object command)
        {
            await _attackCommandExecutor.TryExecuteCommand(command);
            await _stopCommandExecutor.TryExecuteCommand(command);
        }
    }
}