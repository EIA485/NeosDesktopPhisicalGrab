using HarmonyLib;
using NeosModLoader;
using FrooxEngine;
using System;
using System.Reflection;

namespace DesktopPhisicalGrab
{
    public class DesktopPhisicalGrab : NeosMod
    {
        public override string Name => "DesktopPhisicalGrab";
        public override string Author => "eia485";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/eia485/NeosDesktopPhisicalGrab/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.eia485.DesktopPhisicalGrab");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(CommonTool), "TryPointGrab")]
        class DesktopPhisicalGrabPatch
        {
            static bool Prefix(CommonTool __instance)
            {
                return !(bool)typeof(CommonTool).GetMethod("Grab", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(bool), typeof(ICollider) }, null).Invoke(__instance, new object[] { false, null });
            }
        }
    }
}