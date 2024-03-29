﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NuGet.Protocol;
using osu.Framework.Bindables;
using osu.Framework.Logging;
using OsuMemoryDataProvider;
using OsuMemoryDataProvider.OsuMemoryModels;
using OsuMemoryDataProvider.OsuMemoryModels.Abstract;
using OsuMemoryDataProvider.OsuMemoryModels.Direct;


//make it slow down when osu! not found so it can easily run in the background wihtouht wasting much cpu cycles

namespace osu1progressbar.Game.MemoryProvider
{
    public class OsuMemoryProvider
    {
        private readonly string osuWindowTitle;
        public int ReadDelay { get; set; } = 200;
        private readonly object minMaxLock = new object();
        private readonly int throttledDelay = 1000;
        private double memoryReadTimeMin = double.PositiveInfinity;
        private double memoryReadTimeMax = double.NegativeInfinity;

        private OsuBaseAddresses baseAddresses;
        public Bindable<OsuBaseAddresses> OsuBaseAddressesBindable { get; }


        private readonly StructuredOsuMemoryReader sreader;
        private CancellationTokenSource cts = new CancellationTokenSource();

        public OsuMemoryProvider(string osuWindowTitle)
        {
            sreader = StructuredOsuMemoryReader.Instance.GetInstanceForWindowTitleHint(osuWindowTitle);
            baseAddresses = new OsuBaseAddresses();
            OsuBaseAddressesBindable = new Bindable<OsuBaseAddresses>(baseAddresses);
            Logger.Log("Instancated OsuMemoryProvider...");   
        }


        ~OsuMemoryProvider()
        {
            cts.Cancel();
        }

        //HELPER FUMCTIONS COPIED FROM StructuredOsuMemoryProviderTester 
        private T ReadProperty<T>(object readObj, string propName, T defaultValue = default) where T : struct
        {
            if (sreader.TryReadProperty(readObj, propName, out var readResult))
                return (T)readResult;

            return defaultValue;
        }

        private T ReadClassProperty<T>(object readObj, string propName, T defaultValue = default) where T : class
        {
            if (sreader.TryReadProperty(readObj, propName, out var readResult))
                return (T)readResult;

            return defaultValue;
        }

        private int ReadInt(object readObj, string propName)
            => ReadProperty(readObj, propName, -5);
        private short ReadShort(object readObj, string propName)
            => ReadProperty<short>(readObj, propName, -5);

        private float ReadFloat(object readObj, string propName)
            => ReadProperty(readObj, propName, -5f);

        private string ReadString(object readObj, string propName)
            => ReadClassProperty(readObj, propName, "INVALID READ");

        public async void Run()
        {
            Logger.Log("OsuMemoryProvider Run call...");
            sreader.InvalidRead += SreaderOnInvalidRead;
            await Task.Run(async () =>
            {
                //Logger.Log("Starting memoryReader");
                Stopwatch stopwatch;
                double readTimeMs, readTimeMsMin, readTimeMsMax;
                sreader.WithTimes = true;
                var readUsingProperty = false;
                //var baseAddresses = new OsuBaseAddresses();
                while (true)
                {
                   
                    if (cts.IsCancellationRequested) return;

                    if (!sreader.CanRead)
                    {

                        Logger.Log("osu! process not found");
                        //ReadDelay = throttledDelay;
                        await Task.Delay(ReadDelay);
                        continue;
                    }

                    stopwatch = Stopwatch.StartNew();
                    if (readUsingProperty)
                    {
                        OsuBaseAddressesBindable.Value.Beatmap.Id = ReadInt(baseAddresses.Beatmap, nameof(CurrentBeatmap.Id));
                        OsuBaseAddressesBindable.Value.Beatmap.SetId = ReadInt(baseAddresses.Beatmap, nameof(CurrentBeatmap.SetId));
                        OsuBaseAddressesBindable.Value.Beatmap.MapString = ReadString(baseAddresses.Beatmap, nameof(CurrentBeatmap.MapString));
                        OsuBaseAddressesBindable.Value.Beatmap.FolderName = ReadString(baseAddresses.Beatmap, nameof(CurrentBeatmap.FolderName));
                        OsuBaseAddressesBindable.Value.Beatmap.OsuFileName = ReadString(baseAddresses.Beatmap, nameof(CurrentBeatmap.OsuFileName));
                        OsuBaseAddressesBindable.Value.Beatmap.Md5 = ReadString(baseAddresses.Beatmap, nameof(CurrentBeatmap.Md5));
                        OsuBaseAddressesBindable.Value.Beatmap.Ar = ReadFloat(baseAddresses.Beatmap, nameof(CurrentBeatmap.Ar));
                        OsuBaseAddressesBindable.Value.Beatmap.Cs = ReadFloat(baseAddresses.Beatmap, nameof(CurrentBeatmap.Cs));
                        OsuBaseAddressesBindable.Value.Beatmap.Hp = ReadFloat(baseAddresses.Beatmap, nameof(CurrentBeatmap.Hp));
                        OsuBaseAddressesBindable.Value.Beatmap.Od = ReadFloat(baseAddresses.Beatmap, nameof(CurrentBeatmap.Od));
                        OsuBaseAddressesBindable.Value.Beatmap.Status = ReadShort(baseAddresses.Beatmap, nameof(CurrentBeatmap.Status));
                        OsuBaseAddressesBindable.Value.Skin.Folder = ReadString(baseAddresses.Skin, nameof(Skin.Folder));
                        OsuBaseAddressesBindable.Value.GeneralData.RawStatus = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.RawStatus));
                        OsuBaseAddressesBindable.Value.GeneralData.GameMode = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.GameMode));
                        OsuBaseAddressesBindable.Value.GeneralData.Retries = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.Retries));
                        OsuBaseAddressesBindable.Value.GeneralData.AudioTime = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.AudioTime));
                        OsuBaseAddressesBindable.Value.GeneralData.Mods = ReadInt(baseAddresses.GeneralData, nameof(GeneralData.Mods));
                        Logger.Log(JsonConvert.SerializeObject(baseAddresses, Formatting.Indented));
                    }
                    else
                    {
                        sreader.TryRead(OsuBaseAddressesBindable.Value.Beatmap);
                        sreader.TryRead(OsuBaseAddressesBindable.Value.Skin);
                        sreader.TryRead(OsuBaseAddressesBindable.Value.GeneralData);
                        sreader.TryRead(OsuBaseAddressesBindable.Value.BanchoUser);
                    }

                    if (OsuBaseAddressesBindable.Value.GeneralData.OsuStatus == OsuMemoryStatus.SongSelect)
                        sreader.TryRead(OsuBaseAddressesBindable.Value.SongSelectionScores);
                    else
                        OsuBaseAddressesBindable.Value.SongSelectionScores.Scores.Clear();

                    if (OsuBaseAddressesBindable.Value.GeneralData.OsuStatus == OsuMemoryStatus.ResultsScreen)
                        sreader.TryRead(OsuBaseAddressesBindable.Value.ResultsScreen);

                    if (OsuBaseAddressesBindable.Value.GeneralData.OsuStatus == OsuMemoryStatus.Playing)
                    {
                        sreader.TryRead(OsuBaseAddressesBindable.Value.Player);
                        //TODO: flag needed for single/multi player detection (should be read once per play in singleplayer)
                        sreader.TryRead(OsuBaseAddressesBindable.Value.LeaderBoard);
                        sreader.TryRead(OsuBaseAddressesBindable.Value.KeyOverlay);
                        if (readUsingProperty)
                        {
                            //Testing reading of reference types(other than string)
                            sreader.TryReadProperty(OsuBaseAddressesBindable.Value.Player, nameof(Player.Mods), out var dummyResult);
                        }
                    }
                    else
                    {
                        OsuBaseAddressesBindable.Value.LeaderBoard.Players.Clear();
                    }

                    var hitErrors = OsuBaseAddressesBindable.Value.Player?.HitErrors;
                    if (hitErrors != null)
                    {
                        var hitErrorsCount = hitErrors.Count;
                        hitErrors.Clear();
                        hitErrors.Add(hitErrorsCount);
                    }

                    stopwatch.Stop();
                    readTimeMs = stopwatch.ElapsedTicks / (double)TimeSpan.TicksPerMillisecond;
                    lock (minMaxLock)
                    {
                        if (readTimeMs < memoryReadTimeMin) memoryReadTimeMin = readTimeMs;
                        if (readTimeMs > memoryReadTimeMax) memoryReadTimeMax = readTimeMs;
                        // copy value since we're inside lock
                        readTimeMsMin = memoryReadTimeMin;
                        readTimeMsMax = memoryReadTimeMax;
                    }

                    OsuBaseAddressesBindable.TriggerChange();
                    //Logger.Log(JsonConvert.SerializeObject(baseAddresses, Formatting.Indented),LoggingTarget.Information,LogLevel.Debug);
                    sreader.ReadTimes.Clear();
                    await Task.Delay(ReadDelay);
                }
            }, cts.Token);
        }

        public void Stop()
        {
            cts.Cancel(); 
        }
        private void SreaderOnInvalidRead(object sender, (object readObject, string propPath) e)
        {
            try
            {
                Logger.Log($"{DateTime.Now:T} Error reading {e.propPath}{Environment.NewLine}");
            }
            catch (ObjectDisposedException)
            {

            }
        }

        public string GetAllDataJson()
        {
            if(!sreader.CanRead) return "Osu not Found!";

            return JsonConvert.SerializeObject(baseAddresses, Formatting.Indented);
        }

    }
}
