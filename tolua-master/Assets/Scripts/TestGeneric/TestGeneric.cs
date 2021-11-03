using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class TestGeneric : MonoBehaviour
{
    public List<GameObject> m_List = null;
    public Dictionary<int, GameObject> m_Dic = null;

    // Start is called before the first frame update
    void Start()
    {
        // 测试临时变量触发析构函数
        var function = LuaClient.GetMainState().GetFunction("CreateLua");
        var tb = function.Invoke<string, LuaTable>("TestGenericLua");
        tb.SetTable("gameObject", gameObject);
        tb.SetTable("TestGeneric", this);
        tb.GetLuaFunction("Init").Call(tb);
    }

    public void TestList(List<GameObject> list)
    {
        m_List = list;
        Debug.LogFormat("TestGeneric m_List.Count = {0}", m_List.Count);
    }

    public void TestDictionary(Dictionary<int, GameObject> dic)
    {
        m_Dic = dic;
        Debug.LogFormat("TestGeneric m_Dic.Count = {0}", m_Dic.Count);
    }
}
