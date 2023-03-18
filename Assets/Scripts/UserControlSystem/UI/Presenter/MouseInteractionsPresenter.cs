using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem.UI.Model;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _groundTransform;
        [SerializeField] private EventSystem _eventSystem;

        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private AttackableValue _attackablesRMB;
        [SerializeField] private SelectableValue _selectedObject;
        
        
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
            var leftClickRay = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0))
                .Where(_ => !_eventSystem.IsPointerOverGameObject())
                .Select(_ => _camera.ScreenPointToRay(Input.mousePosition))
                .Select(ray =>
                {
                    SetOutline(false);
                    return Physics.RaycastAll(ray);
                });
            
            
            var rightClicRay = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(1))
                .Where(_ => !_eventSystem.IsPointerOverGameObject())
                .Select(_ => _camera.ScreenPointToRay(Input.mousePosition))
                .Select(ray =>
                {
                    SetOutline(false);
                    return (ray, Physics.RaycastAll(ray));
                });

            leftClickRay.Subscribe(hits =>
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
            });

            rightClicRay.Subscribe((ray, hits) =>
            {
                if (weHit<IAttackable>(hits, out var attackable))
                {
                    _attackablesRMB.SetValue(attackable);
                }
                else if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            });


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