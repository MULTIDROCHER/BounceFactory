using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    private TMP_Text _levelText;
    private Item _item;
    private bool _isDisplayed;
    private Vector3 _offset = new(0, -.5f, 0);
    
    private string ItemLevel => _item.Level.ToString();

    private void Awake()
    {
        _item = GetComponentInParent<Item>();
        _levelText = GetComponentInChildren<TMP_Text>();

        HideLevel();
    }

    private void LateUpdate()
    {
        if (_item == null)
            _item = GetComponentInParent<Item>();

        if (_isDisplayed)
        {
            _levelText.text = ItemLevel;
            transform.SetPositionAndRotation(_item.transform.position + _offset, Quaternion.identity);
        }
    }

    private void OnDestroy() => HideLevel();

    public void ShowLevel()
    {
        if (_levelText != null)
        {
            _levelText.gameObject.SetActive(true);
            _isDisplayed = true;
        }
    }

    public void HideLevel()
    {
        if (_levelText != null)
        {
            _levelText.gameObject.SetActive(false);
            _isDisplayed = false;
        }
    }
}