using UnityEngine;

namespace Core
{
    internal class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"{name} is attacking {command.Target}!");
        }
    }
}
