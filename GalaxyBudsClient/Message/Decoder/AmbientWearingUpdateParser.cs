﻿using System;
using System.Collections.Generic;
using System.Reflection;
using GalaxyBudsClient.Model.Constants;

namespace GalaxyBudsClient.Message.Decoder
{
    /*
     * Mostly unused if (versionOfMR < 2). Refer to ExtendedStatusUpdateParser
     */
    class AmbientWearingUpdateParser : BaseMessageParser
    {
        public override SPPMessage.MessageIds HandledType => SPPMessage.MessageIds.AMBIENT_WEARING_STATUS_UPDATED;

        public WearStates WearState { set; get; }
        public int LeftDetectionCount { set; get; }
        public int RightDetectionCount { set; get; }

        public override void ParseMessage(SPPMessage msg)
        {
            if (msg.Id != HandledType)
                return;

            WearState = (WearStates) msg.Payload[0];
            LeftDetectionCount = BitConverter.ToInt16(msg.Payload, 1);
            RightDetectionCount = BitConverter.ToInt16(msg.Payload, 3);
        }
    }
}
