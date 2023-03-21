using UnityEngine;

public interface ISelectable : IHealthHolder, IIconHolder
{
    Transform PivotPoint { get; }
    Outline Outline { get; }
}
