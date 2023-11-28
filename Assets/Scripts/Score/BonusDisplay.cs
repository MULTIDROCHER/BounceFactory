using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusDisplay : MonoBehaviour
{
    private TMP_Text _text;
    private Transform _parent;
    private float _delay = 1;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
        _parent = transform.parent;
        _wait = new WaitForSeconds(_delay);
    }

    public void ShowText(int bonus, Item item)
    {
        _text.enabled = true;
        transform.SetParent(item.transform);
        transform.SetPositionAndRotation(item.transform.position, Quaternion.identity);
        _text.text = "+" + bonus.ToString();

        StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return _wait;

        _text.enabled = false;
        transform.SetParent(_parent);
        transform.SetPositionAndRotation(_parent.position, Quaternion.identity);
    }
}
