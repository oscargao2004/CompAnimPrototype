using UnityEngine;

namespace DefaultNamespace.UI
{
    public abstract class UIElement : MonoBehaviour
    {
        public abstract void OnEnable();
        public abstract void OnDisable();
    }
}