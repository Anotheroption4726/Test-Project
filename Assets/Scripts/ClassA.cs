using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClassA : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log(Time.frameCount + " Awake");
    }

    private void OnEnable()
    {
        Debug.Log(Time.frameCount + " OnEnable");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
