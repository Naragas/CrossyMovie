using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class BaseTrigger : MonoBehaviour
    {
        protected Box _box;
        [SerializeField] protected Vector3 _firstPoint;
        [SerializeField] protected Vector3 _secondPoint;
        [SerializeField] protected Vector3 _topPoint;
        [SerializeField] protected Vector3 _thirdPoint;
        [SerializeField] protected Vector3 _fourthPoint;
        [SerializeField] protected Vector3 _endPoint;
        protected Vector3[] _path;

    }
}