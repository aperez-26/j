﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace GalaxyBudsClient.Message.Decoder
{
    class DebugSkuParser : BaseMessageParser
    {
        public override SPPMessage.MessageIds HandledType => SPPMessage.MessageIds.DEBUG_SKU;

        public char a { set; get; }
        public char b { set; get; }
        public char c { set; get; }
        public char d { set; get; }
        public override void ParseMessage(SPPMessage msg)
        {
            if (msg.Id != HandledType)
                return;

            a = (char)msg.Payload[12];
            b = (char)msg.Payload[13];
            c = (char)msg.Payload[26];
            d = (char)msg.Payload[27];
        }
    }
}
