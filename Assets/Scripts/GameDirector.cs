using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public AmmoAR15 ammoin;
    public PlayerMovement pls;
    public Weapons weap;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pls.weaponFirst != null)
        {
            ammoin = weap.ammoAR;
            text.text = ammoin.ammo.ToString() + "/" + pls.AmmoAr15.ToString(); 
        }
        
    }
}
