using System;
using System.Collections.Generic;



namespace Shared.Source.USC
{
    static public partial class Encode
    {
        static public Byte[] MESSAGE_STATUS(UInt64 sessionId, UInt64 forResponseSID, MessageStatus messageStatus)
        {
            return PackTogether
            (
                sessionId,
                forResponseSID,
                MainCommand.UPDATE_MESSAGE_STATUS,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK,
                ],
                [(Byte)messageStatus]
            );
        }

        static public Byte[] PING_STATUS(UInt64 responseSID, PingStatus pingStatus)
        {
            return PackTogether
            (
                responseSID,
                0,
                MainCommand.UPDATE_PING_STATUS,
                [],
                [(Byte)pingStatus]
            );
        }
        static public Byte[] PING_STATUS(UInt64 sessionId, UInt64 forResponseSID)
        {
            return PackTogether
            (
                sessionId,
                forResponseSID,
                MainCommand.UPDATE_PING_STATUS,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK,
                ],
                [(Byte)PingStatus.I_AM_CHECKING]
            );
        }



        static public Byte[] HERE_IS_SYNC(UInt64 sessionId, UInt64 forResponseSID,
            SubCommand reKeyExportType, List<Byte> reKeyExport)
        {
            return PackTogether
            (
                sessionId,
                forResponseSID,
                MainCommand.HERE_IS_SYNC,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK,
                    reKeyExportType
                ],
                [.. reKeyExport]
            );
        }
        static public Byte[] I_RECEIVED_SYNC(UInt64 sessionId, UInt64 forResponseSID)
        {
            return PackTogether
            (
                sessionId,
                forResponseSID,
                MainCommand.I_RECEIVED_SYNC,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK
                ],
                []
            );
        }

        static public Byte[] TRY_CHANGE_HEAD_DEVICE(UInt64 sessionId, UInt64 forResponseSID, Byte myNewPriority)
        {
            return PackTogether
            (
                sessionId,
                forResponseSID,
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