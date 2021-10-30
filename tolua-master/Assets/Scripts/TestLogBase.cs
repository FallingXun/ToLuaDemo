using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogBase : MonoBehaviour
{
    public int m_Width = 200;
    public int m_Height = 40;
    public int m_SpaceX = 220;
    public int m_SpaceY = 60;
    public int m_StartX = 200;
    public int m_StartY = 10;

    private List<LogFunc> m_Funcs = new List<LogFunc>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    protected void AddFunc(string name, System.Action action)
    {
        m_Funcs.Add(new LogFunc(name, action));
    }

    private void OnGUI()
    {
        int x = 0;
        int y = 0;
        for (int i = 0; i < m_Funcs.Count; i++)
        {
            if (GUI.Button(new Rect(m_StartX + m_SpaceX * x, m_StartY + m_SpaceY * y++, m_Width, m_Height), m_Funcs[i].name))
            {
                m_Funcs[i].action?.Invoke();
            }
            if (y > 5)
            {
                ++x;
                y = 0;
            }
        }
    }
}

public struct LogFunc
{
    public string name;
    public System.Action action;

    public LogFunc(string n, System.Action a)
    {
        name = n;
        action = a;
    }
}