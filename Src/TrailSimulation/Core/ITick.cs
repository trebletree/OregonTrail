﻿namespace TrailSimulation.Core
{
    /// <summary>
    ///     Used by simulation and all attached modes and their states. Allows them to receive ticks and understand the
    ///     difference between a system tick that occurs unpredictably and a simulation tick which occurs at fixed intervals
    ///     based on the tick delta of incoming system ticks adding up to whatever constant is set in the core simulation.
    /// </summary>
    public interface ITick
    {
        /// <summary>
        ///     Called when the simulation is ticked by underlying operating system, game engine, or potato. Each of these system
        ///     ticks is called at unpredictable rates, however if not a system tick that means the simulation has processed enough
        ///     of them to fire off event for fixed interval that is set in the core simulation by constant in milliseconds.
        /// </summary>
        /// <remarks>Default is one second or 1000ms.</remarks>
        /// <param name="systemTick">
        ///     TRUE if ticked unpredictably by underlying operating system, game engine, or potato. FALSE if
        ///     pulsed by game simulation at fixed interval.
        /// </param>
        void OnTick(bool systemTick);
    }
}