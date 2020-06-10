using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class RightSideLineJump : BaseTrigger, IJumpTrigger
{
    public void SetPath()
    {
        _firstPoint = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z -0.5f);
        _secondPoint = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z -1f);
        _topPoint = new Vector3(transform.position.x , transform.position.y + 2, transform.position.z -1.5f);
        _thirdPoint = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z -2f);
        _fourthPoint = new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z-2.5f);
        _endPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z-3f);
        _path = new Vector3[] {_firstPoint,_secondPoint, _topPoint, _thirdPoint, _fourthPoint, _endPoint};
    }

    public void OnTriggerEnter(Collider other)
    {
        SetPath();
        Debug.Log("555");
        _box = other.GetComponent<Box>();
        _box.BoxState = BoxState.CanRightSideJumpLine;
        _box.PathToJump = _path;
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("-555");
        _box.BoxState = BoxState.idle;
    }
}
