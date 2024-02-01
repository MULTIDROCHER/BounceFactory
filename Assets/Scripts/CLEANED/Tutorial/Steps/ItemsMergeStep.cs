using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory
{
    public class ItemsMergeStep : TutorialStep
    {
        protected override Dictionary<string, string> CommonMessages()
        {
            return new Dictionary<string, string>() {
{ "ru", "перемести один предмет на другой,\nчтобы объединить их" },
{ "en", "move one item over another\nto merge them" },
{ "tr", "birleştirmek için bir öğeyi\ndiğerinin üzerine taşıyın" },
    };
        }

        private List<UpgradeHandler> _handlers;

        private ItemHolder _holder => TutorialManager.Instance.ItemHolder;

        public override void Enter()
        {
            foreach (var item in _holder.Contents)
                _handlers.Add(item.GetComponent<UpgradeHandler>());

            foreach (var handler in _handlers)
                handler.Performed += OnPerformed;

            OnUnneedMask(CommonMessages()[Language]);
        }

        public override void Exit()
        {
            foreach (var handler in _handlers)
                handler.Performed -= OnPerformed;
        }
    }
}