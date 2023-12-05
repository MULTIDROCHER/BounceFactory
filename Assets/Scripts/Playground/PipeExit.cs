using UnityEngine;

public class PipeExit : MonoBehaviour, IAnimated
{
    private Animator _splash;

    private void Start() => _splash = GetComponentInChildren<Animator>();

    private void OnTriggerEnter2D(Collider2D other) => PlayAnimation(other);

    public void PlayAnimation(Collider2D other)
    {
        if (other.TryGetComponent(out Ball _))
            _splash.SetTrigger(IAnimated.Trigger);
    }
}
