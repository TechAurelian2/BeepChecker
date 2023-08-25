//----------------------------------------------------------------------------
//
// <copyright file="MainForm.cs" company="TechAurelian">
// Copyright (c) 2013-2023 TechAurelian
// https://techaurelian.com
// Licensed under the MIT. See LICENSE file in the project root for full license information.
// </copyright>
//
//---------------------------------------------------------------------------

namespace BeepChecker
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;

    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // Set the form's font to the default operating system font (Segoe UI on Vista)
            this.Font = SystemFonts.MessageBoxFont;

            // Required method for designer support
            this.InitializeComponent();

            // Avoid storing a duplicate icon in the program executable
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        /// <summary>
        /// Plays a beep using Windows native API when the user clicks a Beep button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void EventBeepButtonsClick(object sender, EventArgs e)
        {
            if (sender == this.simpleBeepButton)
            {
                NativeMethods.MessageBeep(NativeMethods.SimpleBeep);
            }
            else if (sender == this.okBeepButton)
            {
                NativeMethods.MessageBeep(NativeMethods.MB_OK);
            }
            else if (sender == this.informationBeepButton)
            {
                NativeMethods.MessageBeep(NativeMethods.MB_ICONINFORMATION);
            }
            else if (sender == this.questionBeepButton)
            {
                NativeMethods.MessageBeep(NativeMethods.MB_ICONQUESTION);
            }
            else if (sender == this.warningBeepButton)
            {
                NativeMethods.MessageBeep(NativeMethods.MB_ICONWARNING);
            }
            else if (sender == this.errorBeepButton)
            {
                NativeMethods.MessageBeep(NativeMethods.MB_ICONERROR);
            }
        }

        /// <summary>
        /// Plays beeps using .NET API when the user clicks a Beep label.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void EventBeepLabelsClick(object sender, EventArgs e)
        {
            if (sender == this.simpleBeepLabel)
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else if (sender == this.okBeepLabel)
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else if (sender == this.informationBeepLabel)
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
            else if (sender == this.questionBeepLabel)
            {
                System.Media.SystemSounds.Question.Play();
            }
            else if (sender == this.warningBeepLabel)
            {
                System.Media.SystemSounds.Exclamation.Play();
            }
            else if (sender == this.errorBeepLabel)
            {
                System.Media.SystemSounds.Hand.Play();
            }
        }

        /// <summary>
        /// Plays a custom beep using Windows Native API when the user clicks the Play Beep button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void EventCustomBeepButtonClick(object sender, EventArgs e)
        {
            NativeMethods.Beep(
                (int)this.frequencyNumericUpDown.Value,
                (int)this.durationNumericUpDown.Value);
        }

        /// <summary>
        /// Opens the home site in the default browser when the Home link label is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Link label event data.</param>
        private void EventHomeLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Properties.Resources.HomeUrlString);
        }

        /// <summary>
        /// Shows the program version in the form title bar when the Home link label is hovered.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void EventHomeLinkLabelMouseHover(object sender, EventArgs e)
        {
            this.Text = string.Format(
                CultureInfo.CurrentCulture,
                Properties.Resources.TitleVersionString,
                this.ProductName,
                this.ProductVersion);
        }

        /// <summary>
        /// Restores only the program name in the form title bar when the mouse leaves the Home
        /// link label surface area.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void EventHomeLinkLabelMouseLeave(object sender, EventArgs e)
        {
            this.Text = this.ProductName;
        }
    }
}
