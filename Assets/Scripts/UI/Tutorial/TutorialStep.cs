using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class TutorialStep
{
    protected TMP_Text Text;

    public event Action Completed;

    public TutorialStep(TMP_Text text) => Text = text;

    public virtual void Enter() { }

    public virtual void Exit() => OnUnneedMask();

    protected void ChangeText(string text) => Text.text = text;

    protected virtual Vector3 GetMaskPosition(Transform target) => target.position;

    protected virtual void OnPerformed() => Completed?.Invoke();

    protected virtual void OnNeedMask() => TutorialManager.Instance.SetOverlay(true);

    protected virtual void OnUnneedMask() => TutorialManager.Instance.SetOverlay(false);
}