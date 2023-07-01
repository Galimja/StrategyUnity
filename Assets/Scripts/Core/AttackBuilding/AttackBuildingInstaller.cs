using Zenject;

namespace Core
{
    public class AttackBuildingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IHealthHolder>().FromComponentInChildren();
            Container.Bind<float>().WithId("AttackDistance").FromInstance(30f);
            Container.Bind<int>().WithId("AttackPeriod").FromInstance(1400);

        }

    }
}