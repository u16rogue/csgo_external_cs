using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using csgo_external_cs.Extensions;

namespace csgo_external_cs
{
    public static class CSGO
    {
        public static Process Process = null;
        public static IntPtr  Handle  = IntPtr.Zero;

        public static class Modules
        {
            public static Classes.CSGOModule Client = null;
            public static Classes.CSGOModule Engine = null;
        }

        public static class Offsets
        {
            public static int m_iHealth      = 0;
            public static int m_iCrosshairId = 0;
            public static int m_bDormant     = 0;
            public static int m_iTeamNum     = 0;
            public static int m_bSpotted     = 0x93D;
            public static int m_iGlowIndex   = 0;
        }

        public static class Values
        {
            public static IntPtr LocalPlayerPointer  = IntPtr.Zero;
            public static IntPtr dwForceAttack       = IntPtr.Zero;
            public static IntPtr dwEntityList        = IntPtr.Zero;
            public static IntPtr dwGlowObjectManager = IntPtr.Zero;
        }

        public static void Initialize()
        {
            Program.Log("Initializing...");

            Program.Log("\n" + (Program.Status = "Waiting for CS:GO... "));
            CSGOInit.FindCSGO();


            if (!CSGOInit.OpenCSGO() || !CSGOInit.LoadModules() || !CSGOInit.LoadOffsets() || !CSGOInit.LoadValues())
            {
                Program.Log("ERROR: Initialization failed!");
                return;
            }

            Program.Status = "Initializing features";
            CSGOInit.LoadFeatures();

            Program.Status = "Ready!";
        }
    }

    static class CSGOInit
    {
        public static void FindCSGO()
        {
            while (CSGO.Process == null)
            {
                Thread.Sleep(500);

                Process[] ProcList = Process.GetProcessesByName("csgo");
                if (ProcList.Length < 1)
                    continue;

                CSGO.Process = ProcList[0];
                Program.Log("Found!");
            }
        }

        public static bool OpenCSGO()
        {
            Program.Log("\n" + (Program.Status = "Creating handle to CS:GO... "));

            CSGO.Handle = PInvoke.kernel32.OpenProcess(
                PInvoke.kernel32.ProcessAccessFlags.CreateThread | PInvoke.kernel32.ProcessAccessFlags.QueryInformation | PInvoke.kernel32.ProcessAccessFlags.VirtualMemoryOperation | PInvoke.kernel32.ProcessAccessFlags.VirtualMemoryRead | PInvoke.kernel32.ProcessAccessFlags.VirtualMemoryWrite,
                false,
                CSGO.Process.Id
            );

            if (CSGO.Handle == IntPtr.Zero)
            {
                Program.Log("Failed!");
                Program.Status = "Failed to create handle!";
                return false;
            }

            Program.Log("Success!");
            return true;
        }

        public static bool LoadModules()
        {
            Program.Status = "Loading modules...";

            Program.Log("\nWaiting for modules to load...");
            try
            {
                while (CSGO.Process.Modules.Cast<ProcessModule>().FirstOrDefault(x => x.ModuleName == "serverbrowser.dll") == null)
                    Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Program.Log("\nFailed to check for modules! Restart application.");
                return false;
            }

            // Initialize all the modules
            CSGO.Modules.Client = new Classes.CSGOModule("client.dll");
            CSGO.Modules.Engine = new Classes.CSGOModule("engine.dll");

            Program.Log("\nModule Found: ");
            foreach (ProcessModule Module in CSGO.Process.Modules)
            {
                foreach (KeyValuePair<string, Classes.CSGOModule> CSModuleEntry in Classes.CSGOModule.Instances)
                {
                    if (CSModuleEntry.Key != Module.ModuleName)
                        continue;

                    Program.Log("\n\t>> " + Module.ModuleName + " ( 0x" + Module.BaseAddress.ToString("X") + " - " + Module.ModuleMemorySize + " byte(s) )");
                    CSModuleEntry.Value.BaseAddress = Module.BaseAddress;
                    CSModuleEntry.Value.Size = Module.ModuleMemorySize;
                }
            }

            var UnfoundModules = Classes.CSGOModule.Instances.Where(x => x.Value.BaseAddress == IntPtr.Zero).ToArray();
            if (UnfoundModules.Length > 0)
            {
                Program.Log("\n\nThe following modules were not found, initialization failed!");
                foreach (var Module in UnfoundModules)
                    Program.Log("\n\t>> " + Module.Key);

                return false;
            }

            return true;
        }

        public static bool LoadOffsets()
        {
            Program.Log("\n" + (Program.Status = "Loading offsets..."));

            Program.Log("\n\t>> m_iHealth = ");
            CSGO.Offsets.m_iHealth = (int)CSGO.Modules.Client.PatternScan(new byte[] { 0x83, 0xB9, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F, 0x2D }, "xx?????xx", 0x2, true);
            Program.Log("0x" + CSGO.Offsets.m_iHealth.ToString("X"));
            if (CSGO.Offsets.m_iHealth == 0)
                return false;

            Program.Log("\n\t>> m_iCrosshairId = ");
            CSGO.Offsets.m_iCrosshairId = (int)CSGO.Modules.Client.PatternScan(new byte[] { 0x8B, 0x81, 0x00, 0x00, 0x00, 0x00, 0x85, 0xC0, 0x75, 0x19 }, "xx????xxxx", 0x2, true);
            Program.Log("0x" + CSGO.Offsets.m_iCrosshairId.ToString("X"));
            if (CSGO.Offsets.m_iCrosshairId == 0)
                return false;

            Program.Log("\n\t>> m_bDormant = ");
            CSGO.Offsets.m_bDormant = (int)CSGO.Modules.Client.PatternScan(new byte[] { 0x8A, 0x81, 0x00, 0x00, 0x00, 0x00, 0xC3, 0x32, 0xC0 }, "xx????xxx", 0x2, true) + 0x8;
            Program.Log("0x" + CSGO.Offsets.m_bDormant.ToString("X"));
            if (CSGO.Offsets.m_bDormant <= 0x8)
                return false;

            Program.Log("\n\t>> m_iTeamNum = ");
            CSGO.Offsets.m_iTeamNum = (int)CSGO.Modules.Client.PatternScan(new byte[] { 0x8B, 0x89, 0x00, 0x00, 0x00, 0x00, 0xE9 }, "xx????x", 0x2, true);
            Program.Log("0x" + CSGO.Offsets.m_iTeamNum.ToString("X"));
            if (CSGO.Offsets.m_iTeamNum == 0)
                return false;

            // TODO: find proper sig
            Program.Log("\n\t>> m_bSpotted (HARDCODED) = 0x" + CSGO.Offsets.m_bSpotted.ToString("X"));

            Program.Log("\n\t>> m_iGlowIndex = ");
            CSGO.Offsets.m_iGlowIndex = (int)CSGO.Modules.Client.PatternScan(new byte[] { 0x8B, 0xB3, 0x00, 0x00, 0x00, 0x00, 0xE8, 0x00, 0x00, 0x00, 0x00, 0x8A }, "xx????x????x", 0x2, true);
            Program.Log("0x" + CSGO.Offsets.m_iGlowIndex.ToString("X"));
            if (CSGO.Offsets.m_iGlowIndex == 0)
                return false;

            return true;
        }

        public static bool LoadValues()
        {
            Program.Log("\n" + (Program.Status = "Loading Values..."));

            Program.Log("\n\t>> LocalPlayerPointer = ");
            CSGO.Values.LocalPlayerPointer = CSGO.Modules.Client.PatternScan(new byte[] { 0x0F, 0x45, 0x15, 0x00, 0x00, 0x00, 0x00, 0x56 }, "xxx????x", 0x3, true);
            Program.Log("0x" + CSGO.Values.LocalPlayerPointer.ToString("X"));
            if (CSGO.Values.LocalPlayerPointer == IntPtr.Zero)
                return false;

            Program.Log("\n\t>> dwForceAttack = ");
            CSGO.Values.dwForceAttack = CSGO.Modules.Client.PatternScan(new byte[] { 0x89, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x8B, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x8B, 0xF2, 0x8B, 0xC1, 0x83, 0xCE, 0x04 }, "xx????xx????xxxxxxx", 0x2, true);
            Program.Log("0x" + CSGO.Values.dwForceAttack.ToString("X"));
            if (CSGO.Values.dwForceAttack == IntPtr.Zero)
                return false;

            Program.Log("\n\t>> dwEntityList = ");
            CSGO.Values.dwEntityList = CSGO.Modules.Client.PatternScan(new byte[] { 0xBB, 0x00, 0x00, 0x00, 0x00, 0x83, 0xFF, 0x01, 0x0F, 0x8C, 0x00, 0x00, 0x00, 0x00, 0x3B, 0xF8 }, "x????xxxxx????xx", 0x1, true);
            Program.Log("0x" + CSGO.Values.dwEntityList.ToString("X"));
            if (CSGO.Values.dwEntityList == IntPtr.Zero)
                return false;

            Program.Log("\n\t>> dwGlowObjectManager = ");
            CSGO.Values.dwGlowObjectManager = CSGO.Modules.Client.PatternScan(new byte[] { 0x0F, 0x11, 0x05, 0x00, 0x00, 0x00, 0x00, 0x83, 0xC8, 0x01 }, "xxx????xxx", 0x3, true);
            Program.Log("0x" + CSGO.Values.dwGlowObjectManager.ToString("X"));
            if (CSGO.Values.dwGlowObjectManager == IntPtr.Zero)
                return false;


            return true;
        }

        public static void LoadFeatures()
        {
            foreach (Hacks.HackBase Feature in Program.HackInstances)
            {
                Program.Log("\nInitializing feature: " + Feature.Name);
                Feature.Initialize();
            }
        }
    }
}
