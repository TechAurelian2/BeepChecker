//----------------------------------------------------------------------------
//
// <copyright file="NativeMethods.cs" company="TechAurelian">
// Copyright (c) 2013-2023 TechAurelian
// https://techaurelian.com
// Licensed under the MIT. See LICENSE file in the project root for full license information.
// </copyright>
//
//---------------------------------------------------------------------------

namespace BeepChecker
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Windows API native methods and constants class.
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// A simple beep. If the sound card is not available, the sound is generated using the
        /// speaker.
        /// </summary>
        public const uint SimpleBeep = 0xFFFFFFFF;

        /// <summary>
        /// The sound specified as the Windows Default Beep sound.
        /// </summary>
        public const uint MB_OK = 0;

        /// <summary>
        /// The sound specified as the Windows Asterisk sound.
        /// </summary>
        public const uint MB_ICONINFORMATION = 0x40;

        /// <summary>
        /// The sound specified as the Windows Question sound.
        /// </summary>
        public const uint MB_ICONQUESTION = 0x20;

        /// <summary>
        /// The sound specified as the Windows Exclamation sound.
        /// </summary>
        public const uint MB_ICONWARNING = 0x30;

        /// <summary>
        /// The sound specified as the Windows Critical Stop sound.
        /// </summary>
        public const uint MB_ICONERROR = 0x10;

        [DllImport("user32.dll", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MessageBeep(uint type);

        [DllImport("Kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Beep(int frequency, int duration);
    }
}