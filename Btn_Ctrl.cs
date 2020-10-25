using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Ctrl : MonoBehaviour
{
    private SpriteRenderer SprR;
    public Sprite BtnDefault;
    public Sprite BtnPress;

    //set KeyCode when Press
    public KeyCode KeyPress;

    // Start is called before the first frame update
    void Start()
    {
        //set SpriteRenderer
        SprR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check the press
        if (Input.GetKeyDown(KeyPress))
        {
            //press
            SprR.sprite = BtnPress;
        }
        if (Input.GetKeyUp(KeyPress))
        {
            //behind the up button
            SprR.sprite = BtnDefault;
        }
    }
}
