using UnityEngine;

namespace Ilumisoft.RadarSystem.UI
{
    /// <summary>
    /// Concrete component for the icon being visible on the radar of a locatable
    /// </summary>
    [AddComponentMenu("Radar System/UI/Locatable Icon")]
    [RequireComponent(typeof(CanvasGroup))]
    public class LocatableIcon : LocatableIconComponent
    {
        protected CanvasGroup CanvasGroup { get; set; }

        protected virtual void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
        }

        public override void SetVisible(bool visibility)
        {
            CanvasGroup.alpha = visibility ? 1.0f : 0.0f;
        }
    }
}