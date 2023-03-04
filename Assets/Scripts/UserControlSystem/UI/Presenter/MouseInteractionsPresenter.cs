using System.Linq;
using UnityEngine;

namespace UserControlSystem
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;

        private ISelectable _lastSelectable;
        private bool _isSelected;

        private void Update()
        {

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