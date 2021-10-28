using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using System;
using System.IO;

public class CustomLuaFileUtil : LuaFileUtils
{
    public override byte[] ReadFile(string fileName)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Asset/Lua/" + fileName + ".lua");
        var lua = File.ReadAllBytes(path);
        return lua;
    }
}
