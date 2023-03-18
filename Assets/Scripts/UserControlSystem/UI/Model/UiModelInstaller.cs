using System;
using UnityEngine;
using Zenject;

namespace UserControlSystem.UI.Model
{
    public class UiModelInstaller : MonoInstaller
    {
        [SerializeField] private AssetsContext _legacyContext;
        [SerializeField] private Vector3Value _vector3value;
        [SerializeField] private SelectableValue _selectableValue;
        [SerializeField] private AttackableValue _attackableValue;

        public override void InstallBindings()
        {
            Container.Bind<AssetsContext>().FromInstance(_legacyContext);
            Container.Bind<Vector3Value>().FromInstance(_vector3value);
            Container.Bind<SelectableValue>().FromInstance(_selectableValue);
            Container.Bind<AttackableValue>().FromInstance(_attackableValue);
            Container.Bind<IObservable<ISelectable>>().FromInstance(_selectableValue);

            Container.Bind<IAwaitable<IAttackable>>()
            .FromInstance(_attackableValue);
            Container.Bind<IAwaitable<Vector3>>()
            .FromInstance(_vector3value);

            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
            .To<ProduceUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
            .To<AttackCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
            .To<MoveCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>()
            .To<PatrolCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>()
            .To<StopCommandCommandCreator>().AsTransient();
            Container.Bind<CommandButtonsModel>().AsTransient();
            
        }
    }
}