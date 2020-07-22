﻿using System;
using System.Globalization;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using FistVR;
using HarmonyLib;
using RUST.Steamworks;
using Steamworks;
using UnityEngine;
using Valve.VR;

[assembly: AssemblyVersion("1.2")]
namespace Cursed.LoadScene
{
    [BepInPlugin("dll.cursed.loadscene", "CursedDlls - Load Scene", "1.2")]
    public class LoadScenePlugin : BaseUnityPlugin
    {
        private static ConfigEntry<string> _sceneLoad1;
        private static ConfigEntry<string> _sceneLoad2;
        private static ConfigEntry<string> _sceneLoad3;
        private static ConfigEntry<string> _sceneLoad4;
        private static ConfigEntry<string> _sceneLoad5;
        private static ConfigEntry<string> _sceneLoad6;
        private static ConfigEntry<string> _sceneLoad7;
        private static ConfigEntry<string> _sceneLoad8;
        private static ConfigEntry<string> _sceneLoad9;
        private static ConfigEntry<string> _sceneLoad0;

        private void Awake()
        {
            _sceneLoad1 = Config.Bind("General", "SceneLoad1", "", "What scene will load when CTRL+1 are pressed.");
            _sceneLoad2 = Config.Bind("General", "SceneLoad2", "", "What scene will load when CTRL+2 are pressed.");
            _sceneLoad3 = Config.Bind("General", "SceneLoad3", "", "What scene will load when CTRL+3 are pressed.");
            _sceneLoad4 = Config.Bind("General", "SceneLoad4", "", "What scene will load when CTRL+4 are pressed.");
            _sceneLoad5 = Config.Bind("General", "SceneLoad5", "", "What scene will load when CTRL+5 are pressed.");
            _sceneLoad6 = Config.Bind("General", "SceneLoad6", "", "What scene will load when CTRL+6 are pressed.");
            _sceneLoad7 = Config.Bind("General", "SceneLoad7", "", "What scene will load when CTRL+7 are pressed.");
            _sceneLoad8 = Config.Bind("General", "SceneLoad8", "", "What scene will load when CTRL+8 are pressed.");
            _sceneLoad9 = Config.Bind("General", "SceneLoad9", "", "What scene will load when CTRL+9 are pressed.");
            _sceneLoad0 = Config.Bind("General", "SceneLoad0", "", "What scene will load when CTRL+0 are pressed.");
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    SteamVR_LoadLevel.Begin(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

                if (Input.GetKeyDown(KeyCode.Alpha1))
                    SteamVR_LoadLevel.Begin(_sceneLoad1.Value);
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                    SteamVR_LoadLevel.Begin(_sceneLoad2.Value);
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                    SteamVR_LoadLevel.Begin(_sceneLoad3.Value);
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                    SteamVR_LoadLevel.Begin(_sceneLoad4.Value);
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                    SteamVR_LoadLevel.Begin(_sceneLoad5.Value);
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                    SteamVR_LoadLevel.Begin(_sceneLoad6.Value);
                else if (Input.GetKeyDown(KeyCode.Alpha7))
                    SteamVR_LoadLevel.Begin(_sceneLoad7.Value);
                else if (Input.GetKeyDown(KeyCode.Alpha8))
                    SteamVR_LoadLevel.Begin(_sceneLoad8.Value);
                else if (Input.GetKeyDown(KeyCode.Alpha9))
                    SteamVR_LoadLevel.Begin(_sceneLoad9.Value);
                else if (Input.GetKeyDown(KeyCode.Alpha0))
                    SteamVR_LoadLevel.Begin(_sceneLoad0.Value);
            }
        }

        /*
         * Skiddie prevention
         */
        [HarmonyPatch(typeof(HighScoreManager), nameof(HighScoreManager.UpdateScore), new Type[] { typeof(string), typeof(int), typeof(Action<int, int>) })]
        [HarmonyPatch(typeof(HighScoreManager), nameof(HighScoreManager.UpdateScore), new Type[] { typeof(SteamLeaderboard_t), typeof(int) })]
        [HarmonyPrefix]
        public static bool HSM_UpdateScore()
        {
            return false;
        }
    }
}