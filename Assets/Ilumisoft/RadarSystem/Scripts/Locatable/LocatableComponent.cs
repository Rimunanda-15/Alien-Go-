using Ilumisoft.RadarSystem.UI;
using UnityEngine;

namespace Ilumisoft.RadarSystem
{
    /// <summary>
    /// Abstract base class for all locatables
    /// </summary>
    public abstract class LocatableComponent : MonoBehaviour
    {
        public abstract bool ClampOnRadar { get; set; }

        protected virtual void OnEnable()
        {
            LocatableManager.Register(this);
        }

        protected virtual void OnDisable()
        {
            LocatableManager.Unregister(this);
        }

        public abstract LocatableIconComponent CreateIcon();
    }
}