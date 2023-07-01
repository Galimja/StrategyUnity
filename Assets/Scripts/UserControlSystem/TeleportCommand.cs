using UnityEngine;

namespace UserControlSystem
{
    public class TeleportCommand : ITeleportCommand
    {
        public Vector3 Target { get; }
        public TeleportCommand(Vector3 target)
        {
            Target = target;
        }

    }

}