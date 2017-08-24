using IPFS.Blocks;
using IPLD.ContentIdentifier;
using System;
using System.Text;
using Xunit;

namespace IPFS.BlockFormat.Test
{
    public class BlockTests
    {
        [Fact]
        public void TestBlock()
        {
            var empty = new byte[] { };
            new Block(Encoding.ASCII.GetBytes("Hello World!"));

        }
        [Fact]
        public void TestData()
        {
            var data = Encoding.ASCII.GetBytes("some data");
            var block = new Block(data);
            Assert.Equal(data, block.RawData);
        }

        [Fact]
        public void TestHash()
        {
            var data = Encoding.ASCII.GetBytes("some other data");
            var block = new Block(data);
            var hash = Multiformats.Hash.Multihash.Sum(Multiformats.Hash.HashType.SHA2_256, data);
            Assert.Equal(hash, block.Hash);

        }
       
        [Fact]
        public void TestManualHash()
        {
            var data = Encoding.ASCII.GetBytes("I can't figure out more names .. data");
            var hash = Multiformats.Hash.Multihash.Sum(Multiformats.Hash.HashType.SHA2_256, data);
            var cid = new Cid(hash);

            var block = new Block(data, cid);
            Assert.Equal(hash, block.Hash);

            data[5] = Convert.ToByte(((int)data[5] + 5) % 256);
            var blockChanged = new Block(data, cid);
            Assert.Equal(hash, blockChanged.Hash);
            BlockAssert.NotCheckHash(data, cid);
            
        }
    }
}
