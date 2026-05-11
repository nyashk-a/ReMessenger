using System;
using System.Collections.Generic;

using AVcontrol;



namespace Shared.Source.USC
{
    static public partial class Decode
    {
        static public UnpackedContent UnPack(Byte[] packedContent)
        {
           throw new NotImplementedException();
            //..  UInt64 sessionId = FromBinary.BigEndian(packedContent.AsSpan(0, 4));
            //  ну там на подобии этого будет для всего контента,
            //  знай что reKeyExport может и не быть, если в subcommands нету ничего из разряда про новый ключ
            //  в таком случае просто сетни reKeyExport в []
            //  тоже самое с subcommands, если не будет - сеттаешь в []
        }



        public class UnpackedContent(UInt64 sessionId,
            MainCommand mainCommand, SubCommand[] subCommands,
            List<Byte> reKeyExport, Byte[] packedContent)
        {
            public UInt64 SessionId = sessionId;

            public MainCommand  MainCommand = mainCommand;
            public SubCommand[] SubCommands = subCommands;

            public List<Byte> ReKeyExport = reKeyExport;
            public Byte[]   PackedContent = packedContent;
        }
    }
}