using System.Threading.Tasks;
using UnityEngine;


namespace Core
{

    public class MainBuilding : MonoBehaviour, ISelectable, IAttackable
    {
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private Outline _outline;
        [SerializeField] private Transform _pivotPoint; 

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        
        private float _health = 1000;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Outline Outline => _outline;
        public Transform PivotPoint => _pivotPoint;

        public Vector3 RallyPoint { get; set; }

        private void Awake()
        {
            _outline = gameObject.GetComponent<Outline>();
            _outline.enabled = false;
        }

        public void RecieveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        //public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
        //{
        //    Debug.Log("spawn unit");
        //    Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0,
        //    Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        //}
    }
}