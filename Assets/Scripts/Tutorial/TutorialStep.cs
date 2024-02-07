using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

namespace BounceFactory.Tutorial
{
    public abstract class TutorialStep
    {
        public event Action Completed;

        protected TMP_Text Text => TutorialGuide.Instance.Text;

        protected GameObject Mask => TutorialGuide.Instance.Mask;
        
        protected string Language => YandexGame.lang;

        public virtual void Enter() { }

        public virtual void Exit() { }

        protected virtual Dictionary<string, string> ComputerMessages()
        {
            return new();
        }

        protected virtual Dictionary<string, string> MobileMessages()
        {
            return new();
        }

        protected virtual Dictionary<string, string> CommonMessages()
        {
            return new();
        }

        protected virtual void OnNeedMask(string text, Transform target)
        {
            TutorialGuide.Instance.EnableOverlay();
            Mask.transform.position = GetMaskPosition(target);
            ChangeText(text);
        }

        protected virtual void OnUnneedMask(string text)
        {
            TutorialGuide.Instance.DisableOverlay();
            ChangeText(text);
        }

        protected void ChangeText(string text)
        {
            Text.text = text;
        }

        protected virtual Vector3 GetMaskPosition(Transform target) => target.position;

        protected virtual void OnPerformed()
        {
            Completed?.Invoke();
        }
    }
}