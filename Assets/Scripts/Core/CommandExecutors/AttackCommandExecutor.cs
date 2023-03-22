using System.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override async Task ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"{name} is attacking {command.Target}!");
        }
    }

}