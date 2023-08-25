//----------------------------------------------------------------------------
//
// <copyright file="Program.cs" company="TechAurelian">
// Copyright (c) 2013-2023 TechAurelian
// https://techaurelian.com
// Licensed under the MIT. See LICENSE file in the project root for full license information.
// </copyright>
//
//---------------------------------------------------------------------------

namespace BeepChecker
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The main program class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
