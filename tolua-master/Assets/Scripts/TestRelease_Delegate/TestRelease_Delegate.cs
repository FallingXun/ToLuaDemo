using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using System;

public class TestRelease_Delegate : MonoBehaviour
{
    public LuaTable m_LuaTable;
    public Action m_Action = null;

    private void Awake()
    {
        // 测试临时变量触发析构函数
        var function = LuaClient.GetMainState().GetFunction("CreateLua");
        m_LuaTable = function.Invoke<string, LuaTable>("TestDelegate");
        m_LuaTable.SetTable("gameObject", gameObject);
        m_LuaTable.SetTable("del", this);
        m_LuaTable.GetLuaFunction("Init").Call(m_LuaTable);
        Debug.Log("TestRelease_Delegate 成员变量 table reference = " + m_LuaTable.GetReference());
        LuaClient.GetMainState().translator.Getudata(gameObject, out int udata1);
        LuaClient.GetMainState().translator.Getudata(this, out int udata2);
        Debug.Log("TestRelease_Delegate gameObject udata = " + udata1);
        Debug.Log("TestRelease_Delegate del udata = " + udata2);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Action?.Invoke();
    }

    public void Dispose()
    {
        if (m_LuaTable != null)
        {
            m_LuaTable.Dispose();
            m_LuaTable = null;

            Debug.Log("TestRelease_Delegate LuaTable Dispose");
        }
    }
}