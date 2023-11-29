using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private Gate _gate;
    [SerializeField] private KeyCode _key;

    private void OnMouseDown() => _gate.Open();
    
    private void Update()
    {
        if (Input.GetKeyDown(_key))
            _gate.Open();
    }
}
