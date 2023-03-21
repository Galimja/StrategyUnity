using UnityEngine;

public interface IProduceUnitCommand : ICommand, IIconHolder
{
    float ProductionTime { get; }
    string UnitName { get; }
    GameObject UnitPrefab { get; }
}
