using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    //  Syntaxe 'PascalCase' pour paramêtres de classe
    [SerializeField] private float m_TranslationSpeed;

    // Getters et setters = Propriétés (en C#)
    public float GetTranslationSpeed()
    {
        return m_TranslationSpeed;
    }


    void Start()
    {
        //  Syntaxe 'camelCase' pour variables locales
        float myVariable;
    }

    void Update()
    {
        
    }
}
