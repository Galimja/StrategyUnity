using UnityEngine;

namespace UserControlSystem.UI.Model
{
    public class TeleportCommandCommandCreator : CancellableCommandCreatorBase<ITeleportCommand, Vector3>
    {
        protected override ITeleportCommand createCommand(Vector3 argument) => new TeleportCommand(argument);
    }
}
