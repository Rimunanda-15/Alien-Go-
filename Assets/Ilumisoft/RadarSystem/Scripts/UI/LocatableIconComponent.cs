using UnityEngine;

namespace Ilumisoft.RadarSystem.UI
{
    /// <summary>
    /// Abstract base class for the icons of a locatable
    /// </summary>
    public abstract class LocatableIconComponent : MonoBehaviour
    {
        public abstract void SetVisible(bool visibility);
    }
}