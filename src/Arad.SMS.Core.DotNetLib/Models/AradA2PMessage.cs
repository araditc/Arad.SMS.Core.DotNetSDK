﻿//  --------------------------------------------------------------------
//  Copyright (c) 2005-2023 Arad ITC.
//
//  Author : Ammar Heidari <ammar@arad-itc.org>
//  Licensed under the Apache License, Version 2.0 (the "License")
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0 
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  --------------------------------------------------------------------

using System;
using System.Collections.Generic;
using static Arad.SMS.Core.DotNetLib.Helpers.Enums;

namespace Arad.SMS.Core.DotNetLib.Models
{
    public class AradA2PMessage
    {
        #region Properties
        /// <summary>
        ///     Address of short messaging entity (SME) which originated this message. If not known, set to NULL (Unknown).
        /// </summary>
        public string SourceAddress { get; set; }

        /// <summary>
        ///     Destination address of this short message. For mobile terminated messages, this is the directory number of the
        ///     recipient MS.
        /// </summary>
        public string DestinationAddress { get; set; }

        /// <summary>
        ///     Gets message text in specified data coding.
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        ///     Message encoding
        /// </summary>
        public DataCodings DataCoding { get; set; } = DataCodings.None;

        /// <summary>
        ///     The validity period of this message. Set to NULL to request the SMSC default validity period.
        ///     Format 'YYMMDDhhmmss'.
        /// </summary>
        public DateTime ValidityPeriod { get; set; }

        /// <summary>
        ///     Target data header
        /// </summary>
        public List<string> TargetUDH { get; set; }

        /// <summary>
        ///     Service ID for VAS provider
        /// </summary>
        public string ServiceID { get; set; }

        /// <summary>
        ///     Message priority in the queue generated by system.
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        ///     Message class
        /// </summary>
        public MessageClass MessageClass { get; set; }

        /// <summary>
        ///     User data header
        /// </summary>
        public string UDH { get; set; }
        #endregion
    }
}