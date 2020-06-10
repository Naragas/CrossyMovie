using UnityEngine;


namespace DefaultNamespace
{



    public class LeftSideTurnJump : BaseTrigger, IJumpTrigger
    {
        public void SetPath()
        {
            _firstPoint = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 0.4f);
            _secondPoint = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z + 1f);
            _topPoint = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 1.5f);
            _thirdPoint = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + 2f);
            _fourthPoint = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z + 2.5f);
            _endPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            _path = new Vector3[] {_firstPoint, _secondPoint, _topPoint, _thirdPoint, _fourthPoint, _endPoint};
        }


        public void OnTriggerEnter(Collider other)
        {
            SetPath();
            Debug.Log("555");
            _box = other.GetComponent<Box>();
            _box.PathToJump = _path;
            _box.BoxState = BoxState.CanLeftSideJumpTurn;

        }

        public void OnTriggerExit(Collider other)
        {
            Debug.Log("-555");
            _box.BoxState = BoxState.idle;
        }
    }
}
