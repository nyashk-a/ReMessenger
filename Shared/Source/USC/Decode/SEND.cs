using System;
using AVcontrol;



namespace Shared.Source.USC
{
    static public partial class Decode
    {
        static public JN_Message SEND_MSG(byte[] packedContent)
        {
            var len = FromBinary.LittleEndian<int>(packedContent.AsSpan(0, 4));
            return new JN_Message(
                    new DateTime4b(
                        FromBinary.LittleEndian<uint>(packedContent.AsSpan(4, 4)),
                        FromBinary.LittleEndian<uint>(packedContent.AsSpan(4 + 4, 4))),
                    FromBinary.Utf16(packedContent.AsSpan(4 + 4 + 4, len)),
                    FromBinary.LittleEndian<ulong>(packedContent.AsSpan(4 + 4 + 4 + len, 8)),
                    FromBinary.LittleEndian<UInt32>(packedContent.AsSpan(4 + 4 + 4 + len + 8, 4))
                );
        }
        static public JN_Message SEND_PIC(byte[] packedContent)                 //в текст сообщения суется строка с именем картинки. сама картинка летит отдельно через пересылку файлов.
        {
            return SEND_MSG(packedContent);
        }
        static public JN_Message SEND_FILE(byte[] packedContent)                //аналагично картинке
        {
            return SEND_MSG(packedContent);
        }
        static public JN_Message SEND_MUSIC(byte[] packedContent)               //аналогично картинке
        {
            return SEND_MSG(packedContent);
        }
        static public UInt32 DELETE_MSG(byte[] packedContent)                   //айди сообщения, которое надо удалить
        {
            return FromBinary.LittleEndian<UInt32>(packedContent);
        }
    }
}