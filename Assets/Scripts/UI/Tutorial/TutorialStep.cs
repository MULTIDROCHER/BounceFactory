using UnityEngine;
using TMPro;
using System;

public class TutorialStep
{
    protected TMP_Text Text;

    public event Action Completed;

    public TutorialStep(TMP_Text text)
    {
        Text = text;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    protected virtual void OnCompleted() => Completed?.Invoke();

    protected virtual Vector3 GetMaskPosition(Transform target) => target.position;

    protected virtual void OnMobile() => TutorialManager.Instance.SetOverlay(true);

    protected virtual void OnComputer() => TutorialManager.Instance.SetOverlay(false);

    protected void ChangeText(string text)
    {
        Text.text = text;
    }
}