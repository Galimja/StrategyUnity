using System.Threading.Tasks;
using UnityEngine;

namespace Core
{
    internal class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} is patroling from {command.From} to {command.To}!");
        }
    }
}
