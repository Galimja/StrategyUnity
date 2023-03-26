using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    internal class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        [SerializeField] private UnitMovementStop _stop;

        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            Vector3 pointTo = command.To;
            Vector3 pointFrom = command.From;

            while (true)
            {
                GetComponent<NavMeshAgent>().destination = pointTo;
                _animator.SetTrigger(Animator.StringToHash(AnimationTypes.Walk));
                _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();

                try
                {
                    await _stop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
                }
                catch
                {
                    GetComponent<NavMeshAgent>().isStopped = true;
                    GetComponent<NavMeshAgent>().ResetPath();

                    break;
                }

                var tmp = pointTo;
                pointTo = pointFrom;
                pointFrom = tmp;
            }

            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetTrigger(Animator.StringToHash(AnimationTypes.Idle));
        }
    }
}
