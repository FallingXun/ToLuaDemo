using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class Test1_1 : MonoBehaviour
{
    private LuaTable m_LuaTable;

    private void Awake()
    {
        var function = LuaClient.GetMainState().GetFunction("CreateLua");
        m_LuaTable = function.Invoke<string, LuaTable>("TestLua1");
        m_LuaTable.SetTable("gameObject", gameObject);
        Debug.Log("Test1_1 全局变量 table reference = " + m_LuaTable.GetReference());
    }


    public static void Test(LuaTable table)
    {
        Debug.LogFormat("Test1_1.Test table reference = {0}, count = {1}", table.GetReference(),table.GetCount());
    }

    public void Dispose()
    {
        if(m_LuaTable != null)
        {
            m_LuaTable.Dispose();
            m_LuaTable = null;
        }
    }

    private void OnDestroy()
    {
        Dispose();
    }
}
