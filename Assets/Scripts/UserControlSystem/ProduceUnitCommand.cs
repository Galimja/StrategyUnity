using UnityEngine;

namespace UserControlSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Chomper")] private GameObject _unitPrefab;

    }

    public class ProduceUnitCommandHeir : ProduceUnitCommand
    {

    }
}