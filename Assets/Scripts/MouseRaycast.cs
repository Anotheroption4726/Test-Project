using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    [SerializeField] LayerMask m_SelectionLayerMask;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction*1000f);
        RaycastHit hit;

        if(Physics.Raycast(ray.origin, ray.direction, out hit, float.PositiveInfinity, m_SelectionLayerMask.value))
        {
            GameObject go = hit.collider.gameObject;
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            if (mr)
            {
                mr.material.color = Random.ColorHSV();
            }
        }
    }
}
