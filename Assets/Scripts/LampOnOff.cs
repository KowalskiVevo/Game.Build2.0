using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LampOnOff : MonoBehaviour
{
    public PlayerMovement pls;
    public UnityEngine.Experimental.Rendering.Universal.Light2D lightLamps1;
    // Start is called before the first frame update
    void Start()
    {
        //pls = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if (pls.fl1 == true)
                if (lightLamps1.intensity==0f){ lightLamps1.intensity = 1f; }  
                else lightLamps1.intensity = 0f;
        }
    }
}
