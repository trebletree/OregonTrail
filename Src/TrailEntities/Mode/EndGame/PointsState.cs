﻿using System;

namespace TrailEntities.Mode
{
    /// <summary>
    ///     Shows point tabulation based on current simulation statistics. This way if the player dies or finishes the game we
    ///     just attach this state to the travel mode and it will show the final score and reset the game and return to main
    ///     menu when the player is done.
    /// </summary>
    public sealed class PointsState : ModeState<EndGameInfo>
    {
        /// <summary>
        ///     This constructor will be used by the other one
        /// </summary>
        public PointsState(GameMode gameMode, EndGameInfo userData) : base(gameMode, userData)
        {
        }

        /// <summary>
        ///     Returns a text only representation of the current game mode state. Could be a statement, information, question
        ///     waiting input, etc.
        /// </summary>
        public override string OnRenderState()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Fired when the game mode current state is not null and input buffer does not match any known command.
        /// </summary>
        /// <param name="input">Contents of the input buffer which didn't match any known command in parent game mode.</param>
        public override void OnInputBufferReturned(string input)
        {
            throw new NotImplementedException();
        }
    }
}