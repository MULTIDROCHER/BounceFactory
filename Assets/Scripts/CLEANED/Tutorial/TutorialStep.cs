using UnityEngine;
using TMPro;
using System;
using YG;
using System.Collections.Generic;

namespace BounceFactory
{
    public abstract class TutorialStep
    {
        protected virtual Dictionary<string, string> ComputerMessages() { return new(); }
        protected virtual Dictionary<string, string> MobileMessages() { return new(); }
        protected virtual Dictionary<string, string> CommonMessages() { return new(); }

        protected TMP_Text Text => TutorialManager.Instance.Text;
        protected GameObject Mask => TutorialManager.Instance.Mask;
        protected string Language => YandexGame.lang;

        public event Action Completed;

        public virtual void Enter() { }

        public virtual void Exit() { }

        protected virtual void OnNeedMask(string text, Transform target)
        {
            TutorialManager.Instance.EnableOverlay();
            Mask.transform.position = GetMaskPosition(target);
            ChangeText(text);
        }

        protected virtual void OnUnneedMask(string text)
        {
            TutorialManager.Instance.DisableOverlay();
            ChangeText(text);
        }

        protected void ChangeText(string text) => Text.text = text;

        protected virtual Vector3 GetMaskPosition(Transform target) => target.position;

        protected virtual void OnPerformed() => Completed?.Invoke();
    }
}