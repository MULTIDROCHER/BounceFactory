using UnityEngine;
using UnityEngine.UI;

namespace BounceFactory
{
    [RequireComponent(typeof(Button))]
    public class MergeButton : MonoBehaviour
    {
        public Button Button { get; private set; }

        private void Awake() => Button = GetComponent<Button>();
    }
}