using System;
using System.Linq;
using System.Collections.Generic;
using AVcontrol;



namespace Shared.Source.USC
{
    static public partial class Encode
    {
        static internal Byte[] PackTogether(UInt64 sessionId,
            MainCommand mainCommand, SubCommand[] subCommands,
            Byte[] packedContent)
        {
            return
            [
                .. ToBinary.BigEndian(sessionId),
                (Byte)mainCommand,
                (Byte)subCommands.Length,
                .. subCommands.Select(e => (Byte)e).ToArray(),
                .. packedContent
            ];
        }

        static internal Byte[] PackTogether(UInt64 sessionId,
            MainCommand mainCommand, SubCommand[] subCommands,
            List<Byte> reKeyExport, Byte[] packedContent)
        {
            return
            [
                .. ToBinary.BigEndian(sessionId),
                (Byte)mainCommand,
                (Byte)subCommands.Length,
                .. subCommands.Select(cmd => (Byte)cmd).ToArray(),
                .. reKeyExport,
                .. packedContent
            ];
        }
    }
}