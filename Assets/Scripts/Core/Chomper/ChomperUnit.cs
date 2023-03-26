using UnityEngine;

namespace Core
{
    public class ChomperUnit : MonoBehaviour, ISelectable, IAttackable, IUnit, IDamageDealer
    {
        [SerializeField] private Outline _outline;
        [SerializeField] private Transform _pivotPoint;

        [SerializeField] private float _maxHealth = 150;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _damage = 25;

        private float _health = 150;
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

        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommand;

        public void RecieveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                _animator.SetTrigger("PlayDead");
                //_outline.enabled = false;
                //GetComponent<MoveCommandExecutor>().enabled = false;
                destroy();
                //Destroy(gameObject, 1f);
            }
        }

        private async void destroy()
        {
            await _stopCommand.ExecuteSpecificCommand(new StopCommand());
            Destroy(gameObject, 1f);
        }

    }
}