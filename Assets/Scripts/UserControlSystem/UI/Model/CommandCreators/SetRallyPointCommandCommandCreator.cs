using UnityEngine;

namespace UserControlSystem.UI.Model
{
    public class SetRallyPointCommandCommandCreator : CancellableCommandCreatorBase<ISetRallyPointCommand, Vector3> 
    {
        protected override ISetRallyPointCommand createCommand(Vector3 argument) => 
            new SetRallyPointCommand(argument);
    }

}