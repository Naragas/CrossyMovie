using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Box _box;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _box.Jump();
        }
    }
}
