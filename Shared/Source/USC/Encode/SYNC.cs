using System;
using System.Collections.Generic;



namespace Shared.Source.USC
{
    static public partial class Encode
    {
        static public Byte[] HERE_IS_SYNC(UInt64 sessionId, List<Byte> reKeyExport)
        {
            return PackTogether
            (
                sessionId,
                MainCommand.HERE_IS_SYNC,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK
                ],
                [.. reKeyExport]
            );
        }
        static public Byte[] I_RECEIVED_SYNC(UInt64 sessionId)
        {
            return PackTogether
            (
                sessionId,
                MainCommand.I_RECEIVED_SYNC,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK
                ],
                []
            );
        }

        static public Byte[] TRY_CHANGE_HEAD_DEVICE(UInt64 sessionId, Byte myNewPriority)
        {
            return PackTogether
            (
                sessionId,
                MainCommand.TRY_CHANGE_MY_DEVICE_PRIORITY,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK
                ],
                [
                    myNewPriority
                ]
            );
        }
    }
}