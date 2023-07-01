using UnityEngine;


namespace Core
{
    public class AttackBuilding : MonoBehaviour, ISelectable, IAttackable, IDamageDealer
    {
        [SerializeField] private Outline _outline;
        [SerializeField] private Transform _pivotPoint;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        private float _health = 1000;
        private int _damage = 30;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Outline Outline => _outline;
        public Transform PivotPoint => _pivotPoint;
        public int Damage => _damage;


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
    }
}