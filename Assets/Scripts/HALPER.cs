using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HALPER : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public MergeButton mergeButton;
    public GameObject ballSeller;
    public GameObject itemSeller;

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
            scoreCounter.TestChit();

        if (mergeButton.gameObject.activeSelf == true && Input.GetKey(KeyCode.M))
            mergeButton.GetComponent<Button>().onClick.Invoke();

        if (ballSeller.GetComponent<Button>().interactable && Input.GetKey(KeyCode.B))
            ballSeller.GetComponent<Button>().onClick.Invoke();

        if (itemSeller.GetComponent<Button>().interactable && Input.GetKey(KeyCode.N))
            itemSeller.GetComponent<Button>().onClick.Invoke();
    }
}
