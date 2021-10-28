using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using UnityEngine.SceneManagement;

public class TestLog1 : MonoBehaviour
{
    public int m_Index = -1;
    public Test1 m_Test;

    private int m_Width = 200;
    private int m_Height = 40;
    private int m_Space = 60;
    private int m_StartX = 200;
    private int m_StartY = 10;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        var test = GameObject.Find("Test");
        m_Test = test.GetComponent<Test1>();
        LuaClient.GetMainState().translator.Getudata(test, out m_Index);
        Debug.Log("index = " + m_Index);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(m_StartX, m_StartY, m_Width, m_Height), "查看lua引用的C#对象"))
        {
            var o = LuaClient.GetMainState().translator.GetObject(m_Index);
            if (o != null)
            {
                if (o.Equals(null))
                {
                    Debug.LogFormat("object equal null,index = {0}, object = {1}", m_Index, ((GameObject)o).GetInstanceID());
                }
                else
                {
                    Debug.LogFormat("object != null, index = {0}, object = {1}", m_Index, ((GameObject)o).GetInstanceID());
                }
            }
            else
            {
                Debug.LogFormat("index = {0}, object = null", m_Index);
            }
        }
        else if (GUI.Button(new Rect(m_StartX, m_StartY + m_Space, m_Width, m_Height), "释放LuaTable"))
        {
            if (m_Test != null)
            {
                m_Test.Dispose();
            }
        }
    }

}
