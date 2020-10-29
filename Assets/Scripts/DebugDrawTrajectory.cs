using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawTrajectory : MonoBehaviour
{
    [SerializeField] int m_NMaxPositions; //    nombre maximum de positions stockables
    [SerializeField] int m_NDisplayedPositions; //    nombre maximum de positions affichées (on affiche les dernières)
    [SerializeField] int m_MinDistBetweenPos;   //  la distance minimum entre deux positions pour stockage
    [SerializeField] Color m_DisplayColor;  // couleur d'affichage
    Vector3[] m_Positions;  // décalage de position pour affichage

    int m_CurrentIndex = 0;

    Transform m_Transform;

    void Awake()
    {
        m_Transform = transform;
        m_Positions = new Vector3[m_NMaxPositions];
    }

    private void Update()
    {
        // enregistrement des positions successives
        if(m_CurrentIndex < m_Positions.Length - 1)
        {
            Vector3 pos = m_Transform.position;

            if(m_CurrentIndex < 0 || Vector3.Distance(pos, m_Positions[m_CurrentIndex]) > m_MinDistBetweenPos)
            {
                m_Positions[++m_CurrentIndex] = pos;
            }
        }

        //  affichage de la trajectoire
        if(m_CurrentIndex >= 1)
        {
            int startIndex = Mathf.Max(0, m_CurrentIndex - m_NDisplayedPositions);  // on affiche les dernières positions stockées

            for (int i = startIndex; i < m_CurrentIndex; i++)
            {
                Debug.DrawLine(m_Positions[i], m_Positions[i + 1], m_DisplayColor, 0);

            }
        }
    }

    private void OnDrawGizmos()
    {
        //  affichage de la trajectoire
        if (m_CurrentIndex >= 1)
        {
            int startIndex = Mathf.Max(0, m_CurrentIndex - m_NDisplayedPositions);  // on affiche les dernières positions stockées

            for (int i = startIndex; i < m_CurrentIndex; i++)
            {
                Gizmos.color = m_DisplayColor;
                Gizmos.DrawLine(m_Positions[i], m_Positions[i + 1]);

                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(m_Positions[i], 0.025f);
            }
        }
    }
}
