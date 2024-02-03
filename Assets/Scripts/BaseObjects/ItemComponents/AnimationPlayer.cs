using UnityEngine;

namespace BounceFactory.BaseObjects.ItemComponents
{
    public class AnimationPlayer
    {
        const string Trigger = "BallEntered";

        private Animator _animator;

        public AnimationPlayer(Animator animator)
        {
            _animator = animator;
        }

        public void PlayAnimation() => _animator.SetTrigger(Trigger);
    }
}