using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using UnityEngine.SceneManagement;

public class TestLog1 : MonoBehaviour
{
    public GameObject m_TestGo;
    public GameObject m_TestGo_1;
    public int m_Index = -1;
    public Test1 m_Test;
    public Test1_1 m_Test1_1;
    public Test1_2 m_Test1_2;

    private int m_Width = 200;
    private int m_Height = 40;
    private int m_SpaceX = 220;
    private int m_SpaceY = 60;
    private int m_StartX = 200;
    private int m_StartY = 10;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnGUI()
    {
        int x = 0;
        int y = 0;
        if (GUI.Button(new Rect(m_StartX + m_SpaceX * x, m_StartY + m_SpaceY * y++, m_Width, m_Height), "创建GameObject Test1"))
        {
            if (m_TestGo != null)
            {
                var test = Instantiate(m_TestGo);
                m_Test = test.GetComponent<Test1>();
                LuaClient.GetMainState().translator.Getudata(test, out m_Index);
                Debug.Log("index = " + m_Index);
            }
        }
        else if (GUI.Button(new Rect(m_StartX + m_SpaceX * x, m_StartY + m_SpaceY * y++, m_Width, m_Height), "销毁GameObject Test1"))
        {
            if (m_Test != null)
            {
                Destroy(m_Test.gameObject);
                m_Test = null;
            }
        }
        else if (GUI.Button(new Rect(m_StartX + m_SpaceX * x, m_StartY + m_SpaceY * y++, m_Width, m_Height), "释放Test1.LuaTable"))
        {
            if (m_Test != null)
            {
                m_Test.Dispose();
            }
        }
        y = 0;
        ++x;
        if (GUI.Button(new Rect(m_StartX + m_SpaceX * x, m_StartY + m_SpaceY * y++, m_Width, m_Height), "创建GameObject Test1_1"))
        {
            if (m_TestGo_1 != null)
            {
                var test = Instantiate(m_TestGo_1);
                m_Test1_1 = test.GetComponent<Test1_1>();
                LuaClient.GetMainState().translator.Getudata(test, out m_Index);
                Debug.Log("index = " + m_Index);
            }
        }
        else if (GUI.Button(new Rect(m_StartX + m_SpaceX * x, m_StartY + m_SpaceY * y++, m_Width, m_Height), "销毁GameObject Test1_1"))
        {
            if (m_Test1_1 != null)
            {
                Destroy(m_Test1_1.gameObject);
                m_Test1_1 = null;
            }
        }
        else if (GUI.Button(new Rect(m_StartX + m_SpaceX * x, m_StartY + m_SpaceY * y++, m_Width, m_Height), "释放Test1_1.LuaTable"))
        {
            if (m_Test1_1 != null)
            {
                m_Test1_1.Dispose();
            }
        }
        y = 0;
        ++x;
        if (GUI.Button(new Rect(m_StartX + m_SpaceX * x, m_StartY + m_SpaceY * y++, m_Width, m_Height), "创建Class Test1_2"))
        {
            m_Test1_2 = new Test1_2();
        }
        else if (GUI.Button(new Rect(m_StartX + m_SpaceX * x, m_StartY + m_SpaceY * y++, m_Width, m_Height), "销毁Class Test1_2"))
        {
            m_Test1_2 = null;
        }
        else if (GUI.Button(new Rect(m_StartX + m_SpaceX * x, m_StartY + m_SpaceY * y++, m_Width, m_Height), "查看lua引用的C#对象"))
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

    }

}
