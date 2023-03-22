using UnityEngine;

namespace Core
{
    public class ChomperUnit : MonoBehaviour, ISelectable, IAttackable, IUnit
    {
        [SerializeField] private Outline _outline;
        [SerializeField] private Transform _pivotPoint;

        [SerializeField] private float _maxHealth = 150;
        [SerializeField] private Sprite _icon;

        private float _health = 150;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Outline Outline => _outline;
        public Transform PivotPoint => _pivotPoint;

        private void Awake()
        {
            _outline = gameObject.GetComponent<Outline>();
            _outline.enabled = false;
        }

    }
}