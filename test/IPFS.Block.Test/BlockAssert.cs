using IPLD.ContentIdentifier;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IPFS.BlockFormat.Test
{
    public class BlockAssert : Assert
    {
        public static void CheckHash(byte[] expected, Cid actual)
        {
            var checkCid = actual.Prefix.Sum(expected);
            if (checkCid != actual)
                throw new CheckHashException(checkCid, actual);
        }

        public static void NotCheckHash(byte[] expected, Cid actual)
        {
            var checkCid = actual.Prefix.Sum(expected);
            if (checkCid == actual)
                throw new CheckHashException(checkCid, actual);
        }

        private static bool InternalCheckHash(byte[] data, Cid cid) => cid.Prefix.Sum(data) == cid;
    }
}
