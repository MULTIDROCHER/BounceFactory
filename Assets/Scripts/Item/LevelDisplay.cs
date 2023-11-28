using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    private TMP_Text levelText;
    private Item item;
    private bool isDisplayed = false;
    private string Text => item.Level.ToString();

    private void Awake()
    {
        item = GetComponentInParent<Item>();
        levelText = GetComponentInChildren<TMP_Text>();
        levelText.text = Text;
        HideLevel();
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

    private void LateUpdate()
    {
        if (isDisplayed)
        {
            transform.position = item.transform.position;
            transform.rotation = Quaternion.identity;
        }
    }
}