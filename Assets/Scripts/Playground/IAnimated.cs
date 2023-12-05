using UnityEngine;

public interface IAnimated
{
    const string Trigger = "BallEntered";

    void PlayAnimation(Collider2D other);
}