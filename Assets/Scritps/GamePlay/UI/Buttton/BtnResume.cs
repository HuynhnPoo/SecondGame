using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnResume : BtnPause
{
    protected override void OnClick()
    {
        // base.OnClick();
        Pausing();
    }
}
