﻿// Created by Ron 'Maxwolf' McDowell (ron.mcdowell@gmail.com) 
// Timestamp 01/01/2016@3:27 AM

namespace TrailSimulation.Event.River
{
    using System.Collections.Generic;
    using System.Text;
    using Entity;
    using Entity.Vehicle;
    using Module.Director;
    using Prefab;
    using Window.RandomEvent;

    /// <summary>
    ///     When crossing a river there is a chance that your wagon will flood if you choose to caulk and float across the
    ///     river.
    /// </summary>
    [DirectorEvent(EventCategory.RiverCross, EventExecution.ManualOnly)]
    public sealed class VehicleFloods : ItemDestroyer
    {
        /// <summary>Fired by the item destroyer event prefab before items are destroyed.</summary>
        /// <param name="destroyedItems">Items that were destroyed from the players inventory.</param>
        /// <returns>The <see cref="string" />.</returns>
        protected override string OnPostDestroyItems(IDictionary<Entities, int> destroyedItems)
        {
            return destroyedItems.Count > 0
                ? TryKillPassengers("drowned")
                : "no loss of items.";
        }

        /// <summary>
        ///     Fired when the event handler associated with this enum type triggers action on target entity. Implementation is
        ///     left completely up to handler.
        /// </summary>
        /// <param name="userData">
        ///     Entities which the event is going to directly affect. This way there is no confusion about
        ///     what entity the event is for. Will require casting to correct instance type from interface instance.
        /// </param>
        public override void Execute(RandomEventInfo userData)
        {
            base.Execute(userData);

            // Cast the source entity as vehicle.
            var vehicle = userData.SourceEntity as Vehicle;

            // Reduce the total possible mileage of the vehicle this turn.
            vehicle?.ReduceMileage(20 - 20*GameSimulationApp.Instance.Random.Next());
        }

        /// <summary>
        ///     Fired by the item destroyer event prefab after items are destroyed.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        protected override string OnPreDestroyItems()
        {
            var _floodPrompt = new StringBuilder();
            _floodPrompt.Clear();
            _floodPrompt.AppendLine("Vehicle floods");
            _floodPrompt.AppendLine("while crossing the");
            _floodPrompt.Append("river results in");
            return _floodPrompt.ToString();
        }
    }
}