using System;
using System.Buffers;
using System.Text;


using AVcontrol;



namespace Shared.Source.USC
{
    static public partial class Encode
    {
        static public Byte[] I_REQUEST_ACTIVE_CHATS(UInt64 sessionId, UInt64 forResponseSID)
        {
            return PackTogether
            (
                sessionId,
                forResponseSID,
                MainCommand.I_REQUEST_ACTIVE_CHATS,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK
                ],
                []
            );
        }
        static public Byte[] HERE_IS_ACTIVE_CHATS(UInt64 responseSID, JN_Chat[] chats)
        {
            int totalLength = 0;
            foreach (var chat in chats)
            {
                //                 [путь к аватарке]                       [чат сюид]    [сюды юзеров]          [заголовок для парса]
                totalLength += Encoding.Unicode.GetByteCount(chat.chatAvatar) + 8 + (8 * chat.membersSUID.Count) + 2 + 2;
            }
            byte[] result = new byte[totalLength];
            int offset = 0;

            foreach (var chat in chats)
            {
                Buffer.BlockCopy(ToBinary.LittleEndian<UInt16>((UInt16)Encoding.Unicode.GetByteCount(chat.chatAvatar)), 0, result, offset, 2);
                offset += 2;
                Buffer.BlockCopy(ToBinary.LittleEndian<UInt16>((UInt16)(8 * chat.membersSUID.Count)), 0, result, offset, 2);
                offset += 2;
                Buffer.BlockCopy(ToBinary.LittleEndian<UInt64>(chat.chatSUID), 0, result, offset, 8);
                offset += 2;
                Buffer.BlockCopy(ToBinary.Utf16(chat.chatAvatar), 0, result, offset, Encoding.Unicode.GetByteCount(chat.chatAvatar));
                offset += Encoding.Unicode.GetByteCount(chat.chatAvatar);
                for (int i = 0; i < chat.membersSUID.Count; i++)
                {
                    Buffer.BlockCopy(ToBinary.LittleEndian<UInt64>(chat.membersSUID[i]), 0, result, offset, 8);
                    offset += 8;
                }
            }

            return PackTogether
            (
                responseSID,
                0,
                MainCommand.HERE_IS_ACTIVE_CHATS,
                [],
                result
            );
        }



        static public Byte[] I_REQUEST_CHAT_HISTORY_UPDATE(UInt64 sessionId, UInt64 forResponseSID, UInt32 fromMessageSUID, UInt32 chatSUID)
        {
            return PackTogether
            (
                sessionId,
                forResponseSID,
                MainCommand.I_REQUEST_CHAT_HISTORY_UPDATE,
                [
                    SubCommand.SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK
                ],
                [
                    .. ToBinary.LittleEndian(fromMessageSUID),
                    .. ToBinary.LittleEndian(chatSUID)
                ]
            );
        }


        static public byte[] HERE_IS_CHAT_HISTORY_UPDATE(JN_Message[] chatStory, UInt64 sessionId, UInt64 forResponseSID)
        {
            int totalLength = 0;
            foreach (var msg in chatStory)
            {
                totalLength += 4 + 8 + Encoding.Unicode.GetByteCount(msg.message) + 8 + 4;
            }
            byte[] result = new byte[totalLength];
            int offset = 0;

            foreach (var msg in chatStory)
            {
                Buffer.BlockCopy(ToBinary.LittleEndian(Encoding.Unicode.GetByteCount(msg.message)), 0, result, offset, 4);
                offset += 4;
                Buffer.BlockCopy(ToBinary.LittleEndian(msg.sentTime.PassedTotalMinutes), 0, result, offset, 4);
                offset += 4;
                Buffer.BlockCopy(ToBinary.LittleEndian(msg.sentTime.PassedTotalHours), 0, result, offset, 4);
                offset += 4;
                Buffer.BlockCopy(ToBinary.Utf16(msg.message), 0, result, offset, Encoding.Unicode.GetByteCount(msg.message));
                offset += Encoding.Unicode.GetByteCount(msg.message);
                Buffer.BlockCopy(ToBinary.LittleEndian(msg.authorSUID), 0, result, offset, 8);
                offset += 8;
                Buffer.BlockCopy(ToBinary.LittleEndian(msg.messageSUID), 0, result, offset, 4);
                offset += 4;
            }

            return PackTogether
            (
                sessionId,
                forResponseSID,
                MainCommand.HERE_IS_CHAT_HISTORY_UPDATE,
                [],
                result
            );
        }
    }
}