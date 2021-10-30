using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class Test1_2
{
    private LuaTable m_LuaTable;

    public Test1_2()
    {
        var function = LuaClient.GetMainState().GetFunction("CreateLua");
        m_LuaTable = function.Invoke<string, LuaTable>("TestLua1");
        Debug.Log("Test1_2 全局变量 table reference = " + m_LuaTable.GetReference());
    }

    ~Test1_2()
    {
        Debug.Log("Test1_2 析构");
    }
}