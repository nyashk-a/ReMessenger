using System;



namespace Shared.Source.USC
{
    static public partial class Encode
    {
        static public Byte[] MESSAGE_RECEIVED(UInt64 sessionId)
        {
            return PackTogether
            (
                sessionId,
                MainCommand.SEND_MSG,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK,
                ],
                [(Byte)MessageStatus.RECEIVED_BY_SERVER]
            );
        }
        static public Byte[] MESSAGE_READ(UInt64 sessionId)
        {
            return PackTogether
            (
                sessionId,
                MainCommand.SEND_MSG,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK,
                ],
                [(Byte)MessageStatus.READ_BY_USER]
            );
        }

        static public Byte[] PING_STATUS_CHECK(UInt64 sessionId, PingStatus statusCheck)
        {
            return PackTogether
            (
                sessionId,
                MainCommand.SEND_MSG,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK,
                ],
                [(Byte)statusCheck]
            );
        }
    }
}