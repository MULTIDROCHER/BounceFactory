using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : SoundButton
{
    override protected void Start()
    {
        Source = SoundManager.Instance.MusicSource;
        base.Start();
    }
}
