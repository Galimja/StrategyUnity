using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem.UI.Model;

namespace UserControlSystem.UI.Presenter
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;
        [SerializeField] private EventSystem _eventSystem;

        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private AttackableValue _attackablesRMB;
        [SerializeField] private Transform _groundTransform;
        
        private Plane _groundPlane;

        private ISelectable _lastSelectable;

        private void Awake()
        {
            _camera = Camera.main;
            _eventSystem = EventSystem.current;
            _groundTransform = GameObject.FindGameObjectWithTag("Ground").transform;
        }

        private void Start()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);
        }

        private void Update()
        {

            if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
            {
                return;
            }
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }
            //var ray = _camera.ScreenPointToRay(Input.mousePosition);
            //if (Input.GetMouseButtonUp(0))
            //{
            //    SetOutline(false);
            //    var hits = Physics.RaycastAll(ray);

            //    if (hits.Length == 0)
            //    {
            //        return;
            //    }

            //    var selectable = hits
            //    .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            //    .Where(c => c != null)
            //    .FirstOrDefault();

            //    if (selectable != null)
            //    {
            //        _lastSelectable = selectable;
            //        SetOutline(true);
            //    }

            //    _selectedObject.SetValue(selectable);
            //}
            //else
            //{
            //    if (_groundPlane.Raycast(ray, out var enter))
            //    {
            //        //Debug.Log(ray.origin + ray.direction * enter);
            //        _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            //    }
            //}

            SetOutline(false);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(ray);
            if (Input.GetMouseButtonUp(0))
            {
                if (weHit<ISelectable>(hits, out var selectable))
                {
                    if (selectable != null)
                    {
                        _lastSelectable = selectable;
                        SetOutline(true);
                    }
                    _selectedObject.SetValue(selectable);
                }
            }
            else
            {
                if (weHit<IAttackable>(hits, out var attackable))
                {
                    _attackablesRMB.SetValue(attackable);
                }
                else if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            }

        }
        private bool weHit<T>(RaycastHit[] hits, out T result) where T : class
        {
            result = default;
            if (hits.Length == 0)
            {
                return false;
            }
            result = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .Where(c => c != null)
            .FirstOrDefault();
            return result != default;
        }

        private void SetOutline(bool isSelected)
        {
            if (_lastSelectable != null) 
                _lastSelectable.Outline.enabled = isSelected;
        }
    }
}