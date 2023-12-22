using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class TutorialStep
{
    protected TMP_Text Text = TutorialManager.Instance.Text;
    protected GameObject Mask = TutorialManager.Instance.Mask;

    public event Action Completed;

    public virtual void Enter() { }

    public virtual void Exit() { }

    protected virtual void OnNeedMask(string text, Transform target)
    {
        TutorialManager.Instance.SetOverlay(true);
        Mask.transform.position = GetMaskPosition(target);
        ChangeText(text);
    }

    protected virtual void OnUnneedMask(string text)
    {
        TutorialManager.Instance.SetOverlay(false);
        ChangeText(text);
    }

    protected void ChangeText(string text) => Text.text = text;

    protected virtual Vector3 GetMaskPosition(Transform target) => target.position;

    protected virtual void OnPerformed() => Completed?.Invoke();
}