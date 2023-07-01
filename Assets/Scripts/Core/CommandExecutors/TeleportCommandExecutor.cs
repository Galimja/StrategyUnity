using System.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class TeleportCommandExecutor : CommandExecutorBase<ITeleportCommand>
    {
        [SerializeField] private Transform _unitTransform;

        public override async Task ExecuteSpecificCommand(ITeleportCommand command)
        {
            _unitTransform.position = command.Target;
        }

    }
}
