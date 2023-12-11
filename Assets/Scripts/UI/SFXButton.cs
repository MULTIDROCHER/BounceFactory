using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXButton : SoundButton
{
    override protected void Start()
    {
        Source = SoundManager.Instance.SFXSource;
        base.Start();
    }
}
