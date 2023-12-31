﻿using System;
using System.Collections.Generic;
using System.Reflection;
using GalaxyBudsClient.Model.Constants;

namespace GalaxyBudsClient.Message.Decoder
{
    class SppRoleStateParser : BaseMessageParser
    {
        public override SPPMessage.MessageIds HandledType => (SPPMessage.MessageIds)115; //SPPMessage.MessageIds.SPP_ROLE_STATE;

        public Devices Device { set; get; }
        public SppRoleStates SppRoleState { set; get; }

        public override void ParseMessage(SPPMessage msg)
        {
            if (msg.Id != HandledType)
                return;

            SppRoleState = (SppRoleStates) msg.Payload[0];
            Device = (Devices) msg.Payload[1];
        }
    }
}
