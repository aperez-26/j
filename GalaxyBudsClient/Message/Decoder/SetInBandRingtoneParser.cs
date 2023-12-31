﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace GalaxyBudsClient.Message.Decoder
{
    /*
     * Buds+ only
     */
    class SetInBandRingtoneParser : BaseMessageParser
    {
        public override SPPMessage.MessageIds HandledType => SPPMessage.MessageIds.SET_IN_BAND_RINGTONE;

        public byte Status { set; get; }

        public override void ParseMessage(SPPMessage msg)
        {
            if (msg.Id != HandledType)
                return;

            Status = msg.Payload[0];
        }
    }
}