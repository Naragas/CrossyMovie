
using UnityEngine;

namespace  DefaultNamespace
{
    public class JumpOverSaw : BaseTrigger, IJumpTrigger
    {
        [SerializeField] private float heaight = 1f;
        public void SetPath()
        {
            _firstPoint = new Vector3(transform.position.x + 0.5f, transform.position.y + heaight + 1f, transform.position.z);
            _secondPoint = new Vector3(transform.position.x + 1, transform.position.y + heaight  + 1.4f, transform.position.z);
            _topPoint = new Vector3(transform.position.x + 2, transform.position.y + heaight  + 1.9f, transform.position.z);
            _thirdPoint = new Vector3(transform.position.x + 3.5f, transform.position.y + heaight  + 1.7f, transform.position.z);
            _fourthPoint = new Vector3(transform.position.x + 4.5f, transform.position.y + heaight  + 1.2f, transform.position.z);
            _endPoint = new Vector3(transform.position.x + 7f, transform.position.y, transform.position.z);
            _path = new Vector3[] {_firstPoint, _secondPoint, _topPoint, _thirdPoint, _fourthPoint, _endPoint};
        }

        public void OnTriggerEnter(Collider other)
        {
            SetPath();
            Debug.Log("555");
            _box = other.GetComponent<Box>();
            _box.PathToJump = _path;
            _box.BoxState = BoxState.CanBigLineJump;
        }

        public void OnTriggerExit(Collider other)
        {
            Debug.Log("-555");
            _box.BoxState = BoxState.idle;
        }
    }
}
