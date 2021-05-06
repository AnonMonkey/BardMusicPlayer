﻿/*
 * Copyright(c) 2021 MoogleTroupe, 2018-2020 parulina
 * Licensed under the GPL v3 license. See https://github.com/BardMusicPlayer/BardMusicPlayer/blob/develop/LICENSE for full license information.
 */

namespace BardMusicPlayer.Seer.Events
{
    public sealed class EnsembleRequested : SeerEvent
    {
        internal EnsembleRequested(EventSource readerBackendType) : base(readerBackendType, 100)
        {
            EventType = GetType();
        }
        public override bool IsValid() => true;
    }
}
