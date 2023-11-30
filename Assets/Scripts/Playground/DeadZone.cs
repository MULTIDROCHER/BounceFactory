using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball)){
            Debug.Log("kill " + ball.name);
            Destroy(ball.gameObject);
        }
    }
}