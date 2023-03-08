using UnityEngine;

namespace Core
{
    internal class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log(gameObject.name + " moves");
        }
    }
}
