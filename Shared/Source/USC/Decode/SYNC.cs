using System;
using System.Collections.Generic;
using System.Linq;



namespace Shared.Source.USC
{
    static public partial class Decode
    {
        static public UnpackedContent HERE_IS_SYNC(Byte[] packedContent)
            => UnPack(packedContent);
        static public UnpackedContent I_RECEIVED_SYNC(Byte[] packedContent)
            => UnPack(packedContent);

        static public Unpacked_TRY_CHANGE_HEAD_DEVICE TRY_CHANGE_HEAD_DEVICE(Byte[] packedContent)
        {
            Unpacked_TRY_CHANGE_HEAD_DEVICE unpacked = new (UnPack(packedContent));
            unpacked.requestedPriority = unpacked.PackedContent.FirstOrDefault();

            return unpacked;
        }



        public class Unpacked_TRY_CHANGE_HEAD_DEVICE
            (UnpackedContent unpackedContent) : UnpackedContent(unpackedContent)
        {
            public Byte requestedPriority = 0;
        }
    }
}