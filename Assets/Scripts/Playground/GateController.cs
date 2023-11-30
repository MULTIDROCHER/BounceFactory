using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private readonly Gate _gate;
    [SerializeField] private readonly KeyCode _key;

    private void OnMouseDown() => _gate.Open();
    
    private void Update()
    {
        if (Input.GetKeyDown(_key))
            _gate.Open();
    }
}