using System;
using System.Collections.Generic;
using System.Text;
using IPLD.ContentIdentifier;
using Multiformats.Hash;

namespace IPFS.Blocks
{
    public class Block : IBlock
    {
        public Block(byte[] data) : this(data, new Cid(Multihash.Sum(HashType.SHA2_256, data)))
        {

        }

        public Block(byte[] data, Cid cid)
        {
            this.RawData = data;
            this.Cid = cid;
        }

        public byte[] RawData { get; }

        public Cid Cid { get; }

        public Multihash Hash => this.Cid.Hash;

        public override string ToString() => $"[Block { this.Cid }]";
    }

}
