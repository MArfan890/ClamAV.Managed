﻿/*
 * ClamAV.Managed.PowerShell - Managed bindings for ClamAV - PowerShell cmdlets
 * Copyright (C) 2011, 2013-2014 Rupert Muchembled
 * 
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along
 * with this program; if not, write to the Free Software Foundation, Inc.,
 * 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 */

using System;
using System.Management.Automation;

namespace ClamAV.Managed.PowerShell
{
    /// <summary>
    /// Cmdlet wrapping the ClamEngine constructor.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ClamEngine")]
    public class NewClamEngineCmdlet : Cmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Initialize libclamav in debug mode.")]
        public SwitchParameter DebugMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Path to the database to load.")]
        public string WithDatabase { get; set; }

        protected override void ProcessRecord()
        {
            ClamEngine clamEngine;

            if (DebugMode.IsPresent)
                clamEngine = new ClamEngine(true);
            else
                clamEngine = new ClamEngine();

            if (!String.IsNullOrEmpty(WithDatabase))
                clamEngine.LoadDatabase(WithDatabase);

            WriteObject(clamEngine);
        }
    }
}
