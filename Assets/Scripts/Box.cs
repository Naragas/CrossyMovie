using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using DG.Tweening;
using TMPro.EditorUtilities;

public class Box : MonoBehaviour
{

    [SerializeField] private float _turnJumpTime;
    [SerializeField] private float _lineJumpTime;
    [SerializeField] private float _overSawJumpTime;
    [SerializeField] private float _smallJumpTime;

    private float _speed = 4;
    private BoxState _boxState = BoxState.idle;
    private bool canBoxJump = true;
    private bool canBoxMove = false;
    private bool BoxMoveRightSide = true;
    private Vector3[] _pathToJump;
    private Vector3[] _smallJumpPath;
    private Animator _animator;
    private Collider _collider;

    public Vector3[] PathToJump
    {
        get => _pathToJump;
        set => _pathToJump = value;
    }

    public BoxState BoxState
    {
        get => _boxState;
        set => _boxState = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }


    void Start()
    {
        CreatePathArray();
        _animator = GetComponent<Animator>();
        //rigidbody = GetComponent<Rigidbody>();
        //_collider = GetComponentInChildren<Collider>();
        
    }

    private void SmallJumpPathCreator()
    {
        _smallJumpPath = new Vector3[]
        {
            new Vector3(transform.position.x + 0.5f, transform.position.y + 0.4f, transform.position.z),
            new Vector3(transform.position.x + 0.9f, transform.position.y + 0.8f, transform.position.z),
            new Vector3(transform.position.x + 1.3f, transform.position.y + 1.2f, transform.position.z),
            new Vector3(transform.position.x + 1.7f, transform.position.y + 0.8f, transform.position.z),
            new Vector3(transform.position.x + 2.1f, transform.position.y + 0.4f, transform.position.z),
            new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z)
        };
    }

    public void StartMoving()
    {
        canBoxMove = true;
    }
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (canBoxMove)
        {
            if (BoxMoveRightSide)
            {
                transform.position += Vector3.right * Speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.forward * Speed * Time.deltaTime;
            }
        }
        
    }

    private void CreatePathArray()
    {
        PathToJump = new Vector3[6];
    }


    public void Jump()
    {
        if (canBoxJump)
        {
            switch (BoxState)
            {
                case BoxState.idle:
                    SmallLineJump();
                    break;
                case BoxState.CanBigLineJump:
                    JumpOverSaw();
                    break;
                case BoxState.CanLeftSideJumpTurn:
                    LeftSideJumpTurn();
                    break;
                case BoxState.CanRightSideJumpTurn:
                    RightSideJumpTurn();
                    break;
                case BoxState.CanLeftSideJumpLine:
                    LeftSideJumpLine();
                    break;
                case BoxState.CanRightSideJumpLine:
                    RightSideJumpLine();
                    break;
            }
        }
    }


    

    public void fall()
    {
        _animator.enabled = true;
        _animator.SetTrigger("Fall");
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void GoConveyor()
    {
        _animator.SetTrigger("OnConveyor");
    }

    public void Saw()
    {

        _animator.SetTrigger("Saw");

    }

    public void JumpOverSaw()
    {
        _animator.SetTrigger(AnimTriggersNameManager.JumpOverSaw);
        DoPathMovement(_overSawJumpTime);
        CreatePathArray();
    }

    public void LeftSideJumpTurn()
    {
        _animator.SetTrigger(AnimTriggersNameManager.LeftSideJumpTurn);
        DoPathMovement(_turnJumpTime);
        BoxMoveRightSide = false;
        CreatePathArray();
    }
    public void RightSideJumpTurn()
    {
        _animator.SetTrigger(AnimTriggersNameManager.RightSideJumpTurn);
        DoPathMovement(_turnJumpTime);
        BoxMoveRightSide = true;
        CreatePathArray();
    }

    private void LeftSideJumpLine()
    {
        _animator.SetTrigger(AnimTriggersNameManager.LeftSideJumpLine);
        DoPathMovement(_turnJumpTime);
        CreatePathArray();
    }
    
    private void RightSideJumpLine()
    {
        _animator.SetTrigger(AnimTriggersNameManager.RightSideJumpLine);
        DoPathMovement(_lineJumpTime);
        CreatePathArray();
    }
    
    private void DoPathMovement(float time)
    {
        canBoxMove = false;
        canBoxJump = false;
        transform.DOPath(PathToJump, time, PathType.CatmullRom, PathMode.Full3D, resolution: 2);
        _animator.SetBool("CanGo", true);
        StartCoroutine(JumpRoutine(time));

    }

    private void SmallLineJump()
    {
        SmallJumpPathCreator();
        PathToJump = _smallJumpPath;
        _animator.SetTrigger(AnimTriggersNameManager.SmallLineJump);
        _animator.SetBool("CanGo", true);
        DoPathMovement(_smallJumpTime);


    }

    public void Shredder()
    {
        _animator.SetTrigger("Shredder");
    }

    private IEnumerator JumpRoutine(float rutineTime)
    {
        yield return new WaitForSeconds(rutineTime);
        canBoxMove = true;
        canBoxJump = true;
    }

}
