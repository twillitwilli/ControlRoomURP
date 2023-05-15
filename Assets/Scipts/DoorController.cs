using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private bool _openDoor;
    private enum DoorState { doorClosed, doorMoving, doorOpened }
    private DoorState _currentState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (_currentState)
        {
            case DoorState.doorClosed:
                if (_openDoor)
                {
                    _currentState = DoorState.doorMoving;
                    ControlDoor(true);
                }
                break;

            case DoorState.doorOpened:
                if (!_openDoor)
                {
                    _currentState = DoorState.doorMoving;
                    ControlDoor(false);
                }
                break;
        }
    }

    private void ControlDoor(bool openDoor)
    {
        if (openDoor) { _animator.Play("OpenDoor"); }
        else { _animator.Play("CloseDoor"); }
    }

    public void DoorOpened()
    {
        _currentState = DoorState.doorOpened;
        _animator.Play("OpenDoorPos");
    }

    public void DoorClosed()
    {
        _currentState = DoorState.doorClosed;
        _animator.Play("DefaultDoorPos");
    }
}
