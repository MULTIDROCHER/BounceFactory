using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    private TMP_Text levelText;
    private Item item;
    private bool isDisplayed;
    private Vector3 _offset = new(0, -.5f, 0);
    private string Text => item.Level.ToString();

    private void Awake()
    {
        item = GetComponentInParent<Item>();
        levelText = GetComponentInChildren<TMP_Text>();
        HideLevel();
    }

    private void LateUpdate()
    {
        if (isDisplayed)
        {
            levelText.text = Text;
            transform.SetPositionAndRotation(item.transform.position + _offset, Quaternion.identity);
        }
    }

    public void ShowLevel()
    {
        levelText.gameObject.SetActive(true);
        isDisplayed = true;
    }

    public void HideLevel()
    {
        levelText.gameObject.SetActive(false);
        isDisplayed = false;
    }
}