using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UserControlSystem
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;
        [SerializeField] private EventSystem _eventSystem;

        private ISelectable _lastSelectable;

        private void Awake()
        {
            _camera = Camera.main;
            _eventSystem = EventSystem.current;
        }

        private void Update()
        {
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }

            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }

            SetOutline(false);
            
            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));

            if (hits.Length == 0)
            {
                return;
            }

            var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault();

            if (selectable != null)
            {
                _lastSelectable = selectable;
                SetOutline(true);
            }

            _selectedObject.SetValue(selectable);
        }

        private void SetOutline(bool isSelected)
        {
            if (_lastSelectable != null) 
                _lastSelectable.Outline.enabled = isSelected;
        }
    }
}