using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawTrajectory : MonoBehaviour
{
    [SerializeField] int m_NMaxPositions;
    [SerializeField] int m_NDisplayedPositions;
    [SerializeField] int m_MinDistBetweenPos;
    [SerializeField] Color m_DisplayColor;
    Vector3[] m_Positions;

    int m_CurrentIndex = 0;

    Transform m_Transform;

    void Awake()
    {
        m_Transform = transform;
        m_Positions = new Vector3[m_NMaxPositions];
    }

    private void Update()
    {
        if(m_CurrentIndex < m_Positions.Length - 1)
        {
            Vector3 pos = m_Transform.position;

            if(m_CurrentIndex < 0 || Vector3.Distance(pos, m_Positions[m_CurrentIndex]) > m_MinDistBetweenPos)
            {
                m_Positions[++m_CurrentIndex] = pos;
            }
        }

        if(m_CurrentIndex >= 1)
        {
            int startIndex = Mathf.Max(0, m_CurrentIndex - m_NDisplayedPositions);

            for (int i = startIndex; i < m_CurrentIndex; i++)
            {
                Debug.DrawLine(m_Positions[i], m_Positions[i + 1], m_DisplayColor, 0);

            }
        } 
    }
}
