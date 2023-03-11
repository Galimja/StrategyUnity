using UnityEngine;

public interface ISelectable : IHealthHolder
{
    Sprite Icon { get; }
    Transform PivotPoint { get; }
    Outline Outline { get; }
}
