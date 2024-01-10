using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HALPER : MonoBehaviour
{
    public GameObject[] Alpha;
    public GameObject bar;
    bool active;

    public ScoreCounter scoreCounter;
    public MergeButton mergeButton;
    public GameObject ballSeller;
    public GameObject itemSeller;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            scoreCounter.TestChit();

        if (mergeButton.gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.M))
            mergeButton.GetComponent<Button>().onClick.Invoke();

        if (ballSeller.GetComponent<Button>().interactable && Input.GetKeyDown(KeyCode.B))
            ballSeller.GetComponent<Button>().onClick.Invoke();

        if (itemSeller.GetComponent<Button>().interactable && Input.GetKeyDown(KeyCode.N))
            itemSeller.GetComponent<Button>().onClick.Invoke();

        if (Input.GetKeyDown(KeyCode.Space))
            SwitchObjects();
    }

    private void SwitchObjects()
    {
        if (active)
        {
            foreach (var obj in Alpha)
                obj.transform.position += new Vector3(1000, 0, 0);
            active = false;
        }
        else
        {
            foreach (var obj in Alpha)
                obj.transform.position -= new Vector3(1000, 0, 0);
            active = true;
        }
    }
}
