﻿using Unreal.Core.Models;
using Unreal.Core.Models.Enums;
using Unreal.Core.Test.Mocks;
using Xunit;

namespace Unreal.Core.Test;

public class PacketTest
{
    [Theory]
    [InlineData(new byte[] {
            0x71, 0x00, 0x00, 0x00, 0x28, 0x45, 0xC0, 0x67, 0xB0, 0x04, 0x80, 0x82,
            0x5C, 0x4A, 0x00, 0xA8, 0xC8, 0xA5, 0x04, 0x80, 0x92, 0x5C, 0x4A, 0x00,
            0xA8, 0xC9, 0xA5, 0x04, 0x80, 0xA2, 0x5C, 0x4A, 0x00, 0xA8, 0xCA, 0xA5,
            0x04, 0x80, 0xB2, 0x5C, 0x4A, 0x00, 0xA8, 0xCB, 0xA5, 0x04, 0x80, 0xC2,
            0x5C, 0x4A, 0x00, 0xA8, 0xCC, 0xA5, 0x04, 0x80, 0xD2, 0x5C, 0x4A, 0x00,
            0xC0, 0x29, 0x02, 0x3E, 0x83, 0x25, 0x00, 0x14, 0xE7, 0x52, 0x02, 0x40,
            0x75, 0x2E, 0x25, 0x00, 0x94, 0xE7, 0x52, 0x02, 0x40, 0x7D, 0x2E, 0x25,
            0x00, 0x14, 0xE8, 0x52, 0x02, 0x40, 0x85, 0x2E, 0x25, 0x00, 0x94, 0xE8,
            0x52, 0x02, 0x40, 0x8D, 0x2E, 0x25, 0x00, 0x14, 0xE9, 0x52, 0x02, 0x40,
            0x95, 0x2E, 0x25, 0x00, 0x94, 0xE9, 0x52, 0x02, 0x40
        }, PacketState.Success)]
    [InlineData(new byte[] {
            0x0D, 0x00, 0x00, 0x00, 0x48, 0x42, 0xC0, 0x10, 0xB0, 0x1C, 0x1C, 0x20,
            0xD2, 0x32, 0xA9, 0x20, 0x80
        }, PacketState.Success)]
    [InlineData(new byte[] {
            0x27, 0x00, 0x00, 0x00, 0x28, 0x44, 0xC0, 0x10, 0xB0, 0x1C, 0x1C, 0xA0,
            0x30, 0x58, 0xCA, 0x20, 0x00, 0x64, 0x22, 0x60, 0x08, 0x58, 0x0E, 0x0E,
            0x50, 0x18, 0x2C, 0x65, 0x10, 0x00, 0x2E, 0x05, 0x30, 0x04, 0x2C, 0x07,
            0x07, 0x28, 0x0C, 0x96, 0x32, 0x08, 0x20
        }, PacketState.Success)]
    [InlineData(new byte[] {
            0x00, 0x00, 0x00, 0x00
        }, PacketState.End)]
    [InlineData(new byte[] {
            0x01, 0x08, 0x00, 0x00
        }, PacketState.Error)]
    [InlineData(new byte[] {
            0x48, 0xF4, 0xFF, 0xFF
        }, PacketState.Error)]
    public void ReadPacketTest(byte[] rawData, PacketState state)
    {
        using var stream = new MemoryStream(rawData);
        using var archive = new Unreal.Core.BinaryReader(stream);
        var reader = new MockReplayReader();
        reader.SetReplay(new MockReplay
        {
            Header = new ReplayHeader
            {
                EngineNetworkVersion = EngineNetworkVersionHistory.HISTORY_OPTIONALLY_QUANTIZE_SPAWN_INFO,
                NetworkVersion = NetworkVersionHistory.HISTORY_CHARACTER_MOVEMENT_NOINTERP,
                Flags = ReplayHeaderFlags.HasStreamingFixes
            }
        });
        var result = reader.ReadPacket(archive);
        Assert.True(archive.AtEnd());
        Assert.False(archive.IsError);
        Assert.Equal(state, result);
    }
}
