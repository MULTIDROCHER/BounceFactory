using UnityEngine;

namespace BounceFactory.BaseObjects.ItemComponents
{
    public class AnimationPlayer
    {
        private const string BallEnterTrigger = "BallEntered";

        private readonly Animator _animator;

        public AnimationPlayer(Animator animator)
        {
            _animator = animator;
        }

        public void PlayAnimation() => _animator.SetTrigger(BallEnterTrigger);
    }
}