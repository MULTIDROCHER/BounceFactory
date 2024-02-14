using System.Collections.Generic;
using BounceFactory.BaseObjects.ItemComponents;
using BounceFactory.Playground.Storage.Holder;

namespace BounceFactory.Tutorial.Steps
{
    public class ItemsMergeStep : TutorialStep
    {
        private readonly List<UpgradeHandler> _handlers = new ();

        public ItemsMergeStep(TutorialGuide guide)
        : base(guide)
        {
        }

        private ItemHolder Holder => Guide.ItemHolder;

        public override void Enter()
        {
            base.Enter();
            Holder.UpdateContent();

            foreach (var item in Holder.Contents)
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

        protected override Dictionary<string, string> CommonMessages()
        {
            return new Dictionary<string, string>()
        {
            { "ru", "перемести один предмет на другой,\nчтобы объединить их" },
            { "en", "move one item over another\nto merge them" },
            { "tr", "birleştirmek için bir öğeyi\ndiğerinin üzerine taşıyın" },
        };
        }
    }
}