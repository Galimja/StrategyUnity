using System;
using UniRx;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private Subject<Collision> _collision = new Subject<Collision>();

    public IObservable<Collision> Collision => _collision;

    private void OnCollisionStay(Collision collision)
    {
        _collision.OnNext(collision);
    }
}
