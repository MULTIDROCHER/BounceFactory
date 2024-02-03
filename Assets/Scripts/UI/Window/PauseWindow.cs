using UnityEngine;

namespace BounceFactory.UI.Window
{
    public class PauseWindow : MonoBehaviour
    {
        private void OnEnable() => Time.timeScale = 0;

        private void OnDisable() => Time.timeScale = 1;
    }
}