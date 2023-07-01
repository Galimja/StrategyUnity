using UnityEngine;

public interface ITeleportCommand : ICommand
{
    public Vector3 Target { get; }
}
