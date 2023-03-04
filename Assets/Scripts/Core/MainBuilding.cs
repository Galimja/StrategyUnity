using UnityEngine;


namespace Core
{
    public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private Outline _outline;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        
        private float _health = 1000;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Outline Outline => _outline;

        private void Awake()
        {
            _outline = gameObject.GetComponent<Outline>();
            _outline.enabled = false;
        }

        public void ProduceUnit()
        {
            Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0,
                        Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }
    }
}