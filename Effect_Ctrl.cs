using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Ctrl : MonoBehaviour
{
    public float lifeTime = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,lifeTime);
    }
}
