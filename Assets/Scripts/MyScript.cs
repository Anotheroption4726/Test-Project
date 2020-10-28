using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    [SerializeField] private float m_TranslationSpeed;
    [SerializeField] private float m_RotSpeed;
    Transform m_Transform;
    Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float vAxis = Input.GetAxis("Vertical");

        Vector3 newVelocity = vAxis * m_Transform.forward * m_TranslationSpeed;
        Vector3 deltaVelocity = newVelocity - m_Rigidbody.velocity;

        m_Rigidbody.AddForce(deltaVelocity, ForceMode.VelocityChange);

        float hAxis = Input.GetAxis("Horizontal");
        float rotAngle = hAxis * m_RotSpeed * Time.deltaTime;

        Quaternion qRot = Quaternion.AngleAxis(rotAngle, m_Transform.up);
        m_Rigidbody.MoveRotation(qRot * m_Rigidbody.rotation);
    }
}
