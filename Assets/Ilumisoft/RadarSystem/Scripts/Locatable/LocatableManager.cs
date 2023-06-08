using System.Collections.Generic;
using UnityEngine.Events;

namespace Ilumisoft.RadarSystem
{
    /// <summary>
    /// Holds a list of all locatable objects and provides events for when a locatable has been added or removed
    /// </summary>
    public static class LocatableManager
    {
        public static List<LocatableComponent> Locatables { get; private set; } = new List<LocatableComponent>();

        public static UnityAction<LocatableComponent> OnLocatableAdded { get; set; }

        public static UnityAction<LocatableComponent> OnLocatableRemoved { get; set; }

        public static void Register(LocatableComponent locatable)
        {
            if (Locatables.Contains(locatable) == false)
            {
                Locatables.Add(locatable);

                OnLocatableAdded?.Invoke(locatable);
            }
        }

        public static void Unregister(LocatableComponent locatable)
        {
            if (Locatables.Contains(locatable))
            {
                Locatables.Remove(locatable);

                OnLocatableRemoved?.Invoke(locatable);
            }
        }
    }
}