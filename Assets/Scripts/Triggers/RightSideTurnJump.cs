using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class RightSideTurnJump : BaseTrigger, IJumpTrigger
{
    public void SetPath()
    {
        _firstPoint = new Vector3(transform.position.x +0.4f, transform.position.y + 1, transform.position.z);
        _secondPoint = new Vector3(transform.position.x +1f, transform.position.y + 1.5f, transform.position.z );
        _topPoint = new Vector3(transform.position.x +1.5f, transform.position.y + 2, transform.position.z );
        _thirdPoint = new Vector3(transform.position.x  +2f, transform.position.y + 1.5f, transform.position.z);
        _fourthPoint = new Vector3(transform.position.x +2.5f, transform.position.y + 0.6f, transform.position.z);
        _endPoint = new Vector3(transform.position.x+3, transform.position.y, transform.position.z);
        _path = new Vector3[] {_firstPoint,_secondPoint, _topPoint, _thirdPoint, _fourthPoint, _endPoint};
    }
    
    
    public void OnTriggerEnter(Collider other)
    {
        SetPath();
        Debug.Log("555");
        _box = other.GetComponent<Box>();
        _box.PathToJump = _path;
        _box.BoxState = BoxState.CanRightSideJumpTurn;
       
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("-555");
        _box.BoxState = BoxState.idle;
    }
}
