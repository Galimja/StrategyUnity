using System;
using Zenject;

namespace UserControlSystem.UI.Model
{
    public class StopCommandCommandCreator : CommandCreatorBase<IStopCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void classSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new StopCommand()));
        }
    }
}
