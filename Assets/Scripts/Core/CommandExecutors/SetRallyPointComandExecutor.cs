using System.Threading.Tasks;

namespace Core
{
    public class SetRallyPointComandExecutor : CommandExecutorBase<ISetRallyPointCommand>
    {
        public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
        {
            GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;

        }
    }

}