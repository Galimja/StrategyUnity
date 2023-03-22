using Zenject;

namespace Core
{
    public class CommandExecutorsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<DiContainer>().AsTransient();

            var executors = gameObject.GetComponentsInChildren<ICommandExecutor>();
            foreach (var executor in executors)
            {
                var baseType = executor.GetType().BaseType;
                Container.Bind(baseType).FromInstance(executor);
            }
        }
    }
}