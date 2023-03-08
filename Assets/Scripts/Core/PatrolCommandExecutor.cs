using UnityEngine;

namespace Core
{
    internal class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log(gameObject.name + " patrols");
        }
    }
}
