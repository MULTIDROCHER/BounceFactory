using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

namespace BounceFactory.Tutorial
{
    public abstract class TutorialStep
    {
        protected TMP_Text Text;
        protected GameObject Mask;
        protected TutorialGuide Guide;

        public event Action Completed;

        protected TutorialStep(TutorialGuide guide) => Guide = guide;

        protected string Language => YandexGame.lang;

        public virtual void Enter()
        {
            Text = Guide.Text;
            Mask = Guide.Mask;
        }

        public virtual void Exit()
        {
        }

        protected virtual Dictionary<string, string> ComputerMessages()
        {
            return new ();
        }

        protected virtual Dictionary<string, string> MobileMessages()
        {
            return new ();
        }

        protected virtual Dictionary<string, string> CommonMessages()
        {
            return new ();
        }

        protected virtual void OnNeedMask(string text, Transform target)
        {
            Guide.EnableOverlay();
            Mask.transform.position = target.position;
            ChangeText(text);
        }

        protected virtual void OnUnneedMask(string text)
        {
            Guide.DisableOverlay();
            ChangeText(text);
        }

        protected void ChangeText(string text)
        {
            Text.text = text;
        }

        protected virtual void OnPerformed()
        {
            Completed?.Invoke();
        }
    }
}