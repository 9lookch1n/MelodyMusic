using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroll : MonoBehaviour
{
    public float Beat;

    public bool Started;

    // Start is called before the first frame update
    void Start()
    {
        //speed down
        Beat = Beat / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        //Check Start!
        if (!Started)
        {
            /*if (Input.anyKeyDown)
            {
                Started = true;
            }*/
        }
        else
        {
            transform.position -= new Vector3(0f, Beat * Time.deltaTime, 0f);
        }
    }
}
