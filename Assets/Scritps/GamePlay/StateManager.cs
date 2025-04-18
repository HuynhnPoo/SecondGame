using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private IState currentState;


    public void ChangeState(IState state)
    {
        if (currentState != null && state.GetType() == this.currentState.GetType()) return; // neu cung state se return 

        if (currentState != null) currentState.Exit();
        currentState = state; // chuyeen sang state khac

        if (currentState != null) currentState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null) currentState.Execute();
    }
}
