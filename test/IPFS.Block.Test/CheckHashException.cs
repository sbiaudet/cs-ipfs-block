using System;
using System.Runtime.Serialization;
using IPLD.ContentIdentifier;
using Xunit.Sdk;

namespace IPFS.BlockFormat.Test
{
    [Serializable]
    internal class CheckHashException : AssertActualExpectedException
    {
        private Cid actual;
        private Cid expected;

        public CheckHashException(Cid actual, Cid expected): base(actual, expected, "data did not match given hash")
        {
            this.actual = actual;
            this.expected = expected;
        }

    }
}