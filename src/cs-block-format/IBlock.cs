using IPLD.ContentIdentifier;
using System;

namespace IPFS.Blocks
{
    public interface IBlock
    {
        byte[] RawData { get; }
        Cid Cid { get; }
    }


}
