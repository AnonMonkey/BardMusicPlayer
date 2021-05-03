﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Reader.CurrentPlayer.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Reader.CurrentPlayer.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using MogLib.Common.Structs;

namespace Sharlayan {
    using System;

	using Sharlayan.Core;
	using Sharlayan.Core.Enums;
	using Sharlayan.Models.ReadResults;
    using Sharlayan.Utilities;

	using BitConverter = Sharlayan.Utilities.BitConverter;

	public static partial class Reader {
        public static bool CanGetPerformance() {
			//var canRead = Scanner.Instance.Locations.ContainsKey(Signatures.PerformanceLayoutKey) && Scanner.Instance.Locations.ContainsKey(Signatures.PerformanceStatusKey);
			var canRead = Scanner.Instance.Locations.ContainsKey(Signatures.PerformanceStatusKey);
			if (canRead) {
                // OTHER STUFF?
            }

            return canRead;
        }

		public static int memoryVersion = 0;

        public static PerformanceResult GetPerformance() {
            var result = new PerformanceResult();

            if (!CanGetPerformance() || !MemoryHandler.Instance.IsAttached) {
                return result;
            }

            try {
				if (memoryVersion == 55)
				{
					var PerformanceStatusMap = (IntPtr)Scanner.Instance.Locations[Signatures.PerformanceStatusKey];
					int entrySize = 28;
					int numEntries = 99;
					byte[] performanceData = MemoryHandler.Instance.GetByteArray(Scanner.Instance.Locations[Signatures.PerformanceStatusKey], entrySize * numEntries);
					for (int i = 0; i < numEntries; i++)
					{
						int offset = (i * entrySize);
						byte id = performanceData[offset + 12];
						byte type = performanceData[offset + 15];
						byte status = performanceData[offset + 21];
						byte instrument = performanceData[offset + 22];
						if (id >= 0 && id <= 99)
						{
							PerformanceItem item = new PerformanceItem();
							item.Id = (byte)id;
							item.Status = (Performance.Status)status;
							item.Instrument = instrument;
							if (!result.Performances.ContainsKey(id))
							{
								result.Performances[id] = item;
							}
						}
					}
				} else if (memoryVersion == 54)
                {
					var PerformanceStatusMap = (IntPtr) Scanner.Instance.Locations[Signatures.PerformanceStatusKey];

					int entrySize = 20;
					int numEntries = 99;
					byte[] performanceData = MemoryHandler.Instance.GetByteArray(Scanner.Instance.Locations[Signatures.PerformanceStatusKey], entrySize * numEntries);

					for (int i = 0; i < numEntries; i++)
					{
						int offset = (i * entrySize);

						float animation = BitConverter.TryToSingle(performanceData, offset + 0);
						byte id = performanceData[offset + 4];
						byte unknown1 = performanceData[offset + 5]; // No clue
						byte variant = performanceData[offset + 6]; // Animation (hand to left or right)
						byte type = performanceData[offset + 7];
						byte status = performanceData[offset + 8]; // 06 - holding
						byte instrument = performanceData[offset + 9];
						int unknown2 = BitConverter.TryToInt16(performanceData, offset + 10);

						if (id >= 0 && id <= 99)
						{
							PerformanceItem item = new PerformanceItem();
							item.Animation = animation;
							item.Unknown1 = (byte)unknown1;
							item.Id = (byte)id;
							item.Variant = (byte)variant;
							item.Type = (byte)type;
							item.Status = (Performance.Status)status;
							item.Instrument = instrument;

							if (!result.Performances.ContainsKey(id))
							{
								result.Performances[id] = item;
							}
						}
					}
                } else if (memoryVersion == 53)
                {
					var PerformanceStatusMap = (IntPtr) Scanner.Instance.Locations[Signatures.PerformanceStatusKey];

					int entrySize = 12;
					int numEntries = 99;
					byte[] performanceData = MemoryHandler.Instance.GetByteArray(Scanner.Instance.Locations[Signatures.PerformanceStatusKey], entrySize * numEntries);

					for (int i = 0; i < numEntries; i++)
					{
						int offset = (i * entrySize);

						float animation = BitConverter.TryToSingle(performanceData, offset + 0);
						byte id = performanceData[offset + 4];
						byte unknown1 = performanceData[offset + 5];
						byte variant = performanceData[offset + 6]; // Animation (hand to left or right)
						byte type = performanceData[offset + 7];
						byte status = performanceData[offset + 8];
						byte instrument = performanceData[offset + 9];
						int unknown2 = BitConverter.TryToInt16(performanceData, offset + 10);

						if (id >= 0 && id <= 99)
						{
							PerformanceItem item = new PerformanceItem();
							item.Animation = animation;
							item.Unknown1 = (byte)unknown1;
							item.Id = (byte)id;
							item.Variant = (byte)variant;
							item.Type = (byte)type;
							item.Status = (Performance.Status)status;
							item.Instrument = instrument;

							if (!result.Performances.ContainsKey(id))
							{
								result.Performances[id] = item;
							}
						}
					}
                } else MemoryHandler.Instance.RaiseException(Logger, new Exception("Unknown Game Version"), true);
            }
            catch (Exception ex) {
                MemoryHandler.Instance.RaiseException(Logger, ex, true);
            }

            return result;
        }
    }
}