﻿using System.Linq;
using Terraria.ModLoader.IO;

namespace MarvelTerrariaUniverse.Utilities.Extensions;
public static class TagCompoundExtensions
{
    public static bool TryGet<T>(this TagCompound tag, string name, ref T value)
    {
        if (tag.ContainsKey(name))
        {
            value = (T)tag[name];
            return true;
        }
        return false;
    }

    public static void SaveNullable<T>(this TagCompound tag, string name, T? value) where T : struct
    {
        tag[name + "_hasValue"] = value.HasValue;
        tag[name] = value ?? default;
    }

    public static T? LoadNullable<T>(this TagCompound tag, string name) where T : struct
    {
        return tag.GetBool(name + "_hasValue") ? tag.Get<T>(name) : null;
    }
}
