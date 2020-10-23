using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    //  Syntaxe 'PascalCase' pour paramêtres de classe
    [SerializeField] private float m_TranslationSpeed;
    [Tooltip("Rotation in degrees per second")]
    [SerializeField] private float m_RotSpeed;

    Transform m_Transform;
    Rigidbody m_Rigidbody;

    // Getters et setters = Propriétés (en C#)
    public float GetTranslationSpeed()
    {
        return m_TranslationSpeed;
    }

    // Initializations qui concernent que l'objet lui-même
    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Initializations qui concernent les objets exterieurs (s'exécute après l'execution de tous les awake appartenant à tous les objets de la scene)
    void Start()
    {
        //  Syntaxe 'camelCase' pour variables locales
        float myVariable;
    }

    /*
    void Update()
    {
        // .forward = vecteur donné dans le référentiel global
        Vector3 moveVect = transform.forward * m_TranslationSpeed * m_TranslationSpeed * Time.deltaTime;

        Vector3 moveVectLocal = new Vector3(0,0,1) * m_TranslationSpeed * m_TranslationSpeed * Time.deltaTime;
        moveVectLocal = Vector3.forward * m_TranslationSpeed * m_TranslationSpeed * Time.deltaTime;

        //  transform.position += moveVect;

        //  plus performant que le simple 'transform' (m_Transform est mis en cache):
        //m_Transform.position += moveVect;
        

        //m_Transform.Translate(moveVect, Space.World);
        //m_Transform.Translate(moveVectLocal, Space.Self);


        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        moveVectLocal = vAxis * Vector3.forward * m_TranslationSpeed * Time.deltaTime;
        m_Transform.Translate(moveVectLocal, Space.Self);


        float rotAngle = hAxis * m_RotSpeed * Time.deltaTime;
        //m_Transform.Rotate(new Vector3(0, 1, 0), rotAngle, Space.Self);
        m_Transform.Rotate(m_Transform.up, rotAngle, Space.World);
    }
    */

    /*
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 moveVect = Vector3.ClampMagnitude(new Vector3(hAxis, 0, vAxis)* m_TranslationSpeed * Time.deltaTime, 1);

        m_Transform.Translate(moveVect, Space.Self);                                                                                                   
    }       
    */

    void FixedUpdate()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //Vector3 moveVect = vAxis * m_Transform.forward * m_TranslationSpeed * Time.fixedDeltaTime;
        //m_Rigidbody.MovePosition(m_Rigidbody.position + moveVect);

        Vector3 newVelocity = vAxis * m_Transform.forward * m_TranslationSpeed;
        Vector3 deltaVelocity = newVelocity - m_Rigidbody.velocity;

        m_Rigidbody.AddForce(deltaVelocity, ForceMode.VelocityChange);
    }
}
