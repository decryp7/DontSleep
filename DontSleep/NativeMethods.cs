#region FileHeader
// (c) Copyright 2020 - Yokogawa Electric Corporation.
// All Right Reserved
// 
// This software [both binary and source (if released)] (hereafter, Software)
// is intellectual property owned by Yokogawa Electric Corporation and is
// copyright of Yokogawa Electric Corporation in all countries in the world,
// and ownership remains with Yokogawa Electric Corporation.
// 
// Origin:
// 
// Description:
#endregion

using System;
using System.Runtime.InteropServices;

namespace DontSleep
{
    internal static class NativeMethods
    {

        public static void PreventSleep()
        {
            SetThreadExecutionState(ExecutionState.EsContinuous | ExecutionState.EsSystemRequired);
        }

        public static void AllowSleep()
        {
            SetThreadExecutionState(ExecutionState.EsContinuous);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern ExecutionState SetThreadExecutionState(ExecutionState esFlags);

        [Flags]
        private enum ExecutionState : uint
        {
            EsAwaymodeRequired = 0x00000040,
            EsContinuous = 0x80000000,
            EsDisplayRequired = 0x00000002,
            EsSystemRequired = 0x00000001
        }
    }
}