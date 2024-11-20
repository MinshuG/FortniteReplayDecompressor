using Unreal.Core.Models;
using Xunit;

namespace Unreal.Core.Test;

public class FTextTest
{
    [Theory]
    [InlineData(new byte[] {
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x21, 0x00, 0x00,
        0x00, 0x30, 0x35, 0x36, 0x36, 0x46, 0x38, 0x33, 0x43, 0x34, 0x46, 0x45,
        0x33, 0x31, 0x31, 0x45, 0x36, 0x45, 0x36, 0x34, 0x33, 0x31, 0x37, 0x39,
        0x30, 0x38, 0x43, 0x36, 0x45, 0x34, 0x31, 0x42, 0x42, 0x00, 0x10, 0x00,
        0x00, 0x00, 0x54, 0x68, 0x65, 0x20, 0x46, 0x69, 0x72, 0x73, 0x74, 0x20,
        0x4F, 0x72, 0x64, 0x65, 0x72, 0x00 }, 528)]
    [InlineData(new byte[] {
        0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x21, 0x00, 0x00,
        0x00, 0x32, 0x45, 0x30, 0x34, 0x33, 0x33, 0x30, 0x44, 0x34, 0x45, 0x39,
        0x45, 0x34, 0x34, 0x30, 0x44, 0x39, 0x43, 0x31, 0x39, 0x35, 0x44, 0x41,
        0x33, 0x34, 0x39, 0x41, 0x38, 0x44, 0x34, 0x44, 0x42, 0x00, 0x11, 0x00,
        0x00, 0x00, 0x52, 0x6F, 0x73, 0x65, 0x20, 0x54, 0x65, 0x61, 0x6D, 0x20,
        0x4C, 0x65, 0x61, 0x64, 0x65, 0x72, 0x00 }, 536)]
    [InlineData(new byte[] {
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x21, 0x00, 0x00,
        0x00, 0x35, 0x38, 0x30, 0x39, 0x44, 0x37, 0x32, 0x42, 0x34, 0x34, 0x35,
        0x42, 0x36, 0x45, 0x32, 0x33, 0x46, 0x46, 0x38, 0x43, 0x39, 0x32, 0x38,
        0x35, 0x35, 0x31, 0x35, 0x42, 0x43, 0x31, 0x35, 0x44, 0x00, 0x19, 0x00,
        0x00, 0x00, 0x42, 0x61, 0x74, 0x6D, 0x61, 0x6E, 0x20, 0x43, 0x6F, 0x6D,
        0x69, 0x63, 0x20, 0x42, 0x6F, 0x6F, 0x6B, 0x20, 0x4F, 0x75, 0x74, 0x66,
        0x69, 0x74, 0x00}, 600)]
    public void TextTest(byte[] rawData, int bitCount)
    {
        var reader = new NetBitReader(rawData, bitCount);
        var playerName = new FText();
        playerName.Serialize(reader);

        Assert.True(reader.AtEnd());
        Assert.False(reader.IsError);
    }
}
