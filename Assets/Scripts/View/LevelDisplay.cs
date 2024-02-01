using TMPro;
using UnityEngine;

namespace BounceFactory
{
    public class LevelDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        private UpgradableObject _item;
        private bool _isDisplayed;
        private Vector3 _offset = new(0, -.5f, 0);

        private string ItemLevel => _item.Level.ToString();

        private void Awake()
        {
            _item = GetComponentInParent<Item>();

            HideLevel();
        }

        private void LateUpdate()
        {
            if (_isDisplayed)
                transform.SetPositionAndRotation(_item.transform.position + _offset, Quaternion.identity);
        }

        private void OnDestroy() => HideLevel();

        public void ShowLevel()
        {
            if (_levelText != null)
            {
                _levelText.text = ItemLevel;
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
}