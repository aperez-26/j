﻿using System;
using System.Collections.Generic;
using System.Reflection;
using GalaxyBudsClient.Model.Constants;

namespace GalaxyBudsClient.Message.Decoder
{
    class LogCoredumpDataSizeParser : BaseMessageParser
    {
        public override SPPMessage.MessageIds HandledType => SPPMessage.MessageIds.LOG_COREDUMP_DATA_SIZE;
        
        public int DataSize { set; get; }
        public short PartialDataMaxSize { set; get; }
        public int FragmentCount { set; get; }

        public override void ParseMessage(SPPMessage msg)
        {
            if (msg.Id != HandledType)
                return;

            DataSize = BitConverter.ToInt32(msg.Payload, 0);
            PartialDataMaxSize = BitConverter.ToInt16(msg.Payload, 4);
            FragmentCount = (int)Math.Ceiling((double)DataSize/(double)PartialDataMaxSize);
        }
    }
}
