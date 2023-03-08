using UnityEngine;

namespace Core
{
    public class ChomperUnit : MonoBehaviour, ISelectable
    {
        [SerializeField] private Outline _outline;

        [SerializeField] private float _maxHealth = 150;
        [SerializeField] private Sprite _icon;

        private float _health = 150;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Outline Outline => _outline;

        private void Awake()
        {
            _outline = gameObject.GetComponent<Outline>();
            _outline.enabled = false;
        }

        //public override void ExecuteSpecificCommand(ICommand command)
        //{
        //    Debug.Log("command " + nameof(command) + " activate");
        //}
    }
}