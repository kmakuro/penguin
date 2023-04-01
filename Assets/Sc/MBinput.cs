using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MBinput : MonoBehaviour
{
    private bool m_Jump;
    public VirtualButtonState _JumpButton;
    private bool m_Block;
    
    public VirtualButtonState _Attack;
    private bool m_att;

    public void Start()
    {
        _player = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        // Jump State
        if (_JumpButton._currentState == VirtualButtonState.State.Down
                                   && m_Jump == false)
        {
            m_Jump = true;
            _player.ActionJump();
        }
        else if (_JumpButton._currentState == VirtualButtonState.State.Up
                                    && m_Jump == true)
        {
            m_Jump = false;
        }

        _player.ActionSwapDirection(_VirtualJoy.InputVector.x);
        _player.ActionBodyMove(_VirtualJoy.InputVector.x);
        _player.ActionRun(_VirtualJoy.InputVector.x);

        /*if (_BlockButton._currentState == VirtualButtonState.State.Down && m_Block == false)
        {
            m_Block = true;
            _player.ActionBlock();
        }
        else if (_BlockButton._currentState == VirtualButtonState.State.Up && m_Block == true)
        {
            m_Block = false;
        }*/



        if (_Attack._currentState == VirtualButtonState.State.Down
                                   && m_att == false)
        {
            m_att = true;
            _player.ActionAttack();
        }
        else if (_Attack._currentState == VirtualButtonState.State.Up
                                    && m_att == true)
        {
            m_att = false;
        }

    }

}

    
