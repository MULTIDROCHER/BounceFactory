using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    private TMP_Text levelText;
    private Item _item;
    private bool isDisplayed;
    private Vector3 _offset = new(0, -.5f, 0);
    
    private string Text => _item.Level.ToString();

    private void Awake()
    {
        _item = GetComponentInParent<Item>();
        levelText = GetComponentInChildren<TMP_Text>();
        HideLevel();
    }

    private void OnDestroy() => HideLevel();

    private void LateUpdate()
    {
        if (_item == null)
            _item = GetComponentInParent<Item>();

        if (isDisplayed)
        {
            levelText.text = Text;
            transform.SetPositionAndRotation(_item.transform.position + _offset, Quaternion.identity);
        }
    }

    public void ShowLevel()
    {
        if (levelText != null)
        {
            levelText.gameObject.SetActive(true);
            isDisplayed = true;
        }
    }

    public void HideLevel()
    {
        if (levelText != null)
        {
            levelText.gameObject.SetActive(false);
            isDisplayed = false;
        }
    }
}