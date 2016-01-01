﻿// Created by Ron 'Maxwolf' McDowell (ron.mcdowell@gmail.com) 
// Timestamp 01/01/2016@3:27 AM

namespace TrailSimulation.Event.Animal
{
    using System.Collections.Generic;
    using System.Text;
    using Entity;
    using Module.Director;
    using Prefab;

    /// <summary>
    ///     A pack of wolves is attacking the vehicle party! If there are not enough bullets to stop them then they will
    ///     overwhelm the people and kill them!
    /// </summary>
    [DirectorEvent(EventCategory.Animal)]
    public sealed class WolfAttack : ItemDestroyer
    {
        /// <summary>Fired by the item destroyer event prefab before items are destroyed.</summary>
        /// <param name="destroyedItems">Items that were destroyed from the players inventory.</param>
        /// <returns>The <see cref="string" />.</returns>
        protected override string OnPostDestroyItems(IDictionary<Entities, int> destroyedItems)
        {
            // Change event text depending on if items were destroyed or not.
            return destroyedItems.Count > 0
                ? TryKillPassengers("mauled")
                : "no loss of items.";
        }

        /// <summary>
        ///     Fired by the item destroyer event prefab after items are destroyed.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        protected override string OnPreDestroyItems()
        {
            var firePrompt = new StringBuilder();
            firePrompt.Clear();
            firePrompt.AppendLine("A pack of wolves attack you in the night!");
            firePrompt.Append("Resulting in ");
            return firePrompt.ToString();
        }
    }
}