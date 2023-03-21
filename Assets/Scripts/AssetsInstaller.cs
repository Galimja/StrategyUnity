using UnityEngine;
using UserControlSystem.UI.Model;
using Zenject;

[CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackableClicksRMB;
    [SerializeField] private SelectableValue _selectables;
    
    [SerializeField] private Sprite _chomperSprite;

    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _groundClicksRMB, _attackableClicksRMB, _selectables);
        Container.Bind<Sprite>().WithId("Chomper").FromInstance(_chomperSprite);
    }
}