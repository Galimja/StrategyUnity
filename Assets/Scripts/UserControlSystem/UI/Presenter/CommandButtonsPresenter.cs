using System;
using System.Collections.Generic;
using UnityEngine;

namespace UserControlSystem
{

    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += onSelected;
            onSelected(_selectable.CurrentValue);
            _view.OnClick += onButtonClick;
        }

        private void onSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            _currentSelectable = selectable;
            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as
                Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void onButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProducer = TypeOfCommand<IProduceUnitCommand>(commandExecutor);
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                return;
            }

            var attackCommand = TypeOfCommand<IAttackCommand>(commandExecutor);
            if (attackCommand != null)
            {
                attackCommand.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
                return;
            }

            var moveCommand = TypeOfCommand<IMoveCommand>(commandExecutor);
            if (moveCommand != null)
            {
                moveCommand.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
                return;
            }

            var patrolCommand = TypeOfCommand<IPatrolCommand>(commandExecutor);
            if (patrolCommand != null)
            {
                patrolCommand.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
                return;
            }

            var stopCommand = TypeOfCommand<IStopCommand>(commandExecutor);
            if (stopCommand != null)
            {
                stopCommand.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
                return;
            }

            throw new
            ApplicationException(@$"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: 
Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
        }

        private CommandExecutorBase<T> TypeOfCommand<T>(ICommandExecutor commandExecutor) where T : ICommand
        {
            return commandExecutor as CommandExecutorBase<T>;
        }
    }
}