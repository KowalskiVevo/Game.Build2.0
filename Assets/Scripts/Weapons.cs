using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor.Animations;

public class Weapons : MonoBehaviour
{
    [Header ("Классы для ссылки")] 
    public PlayerMovement pls;
    public AmmoAR15 ammoAR;
    //string[] pattern = new string[] {};
    //Регулярки для поиска оружия
    public float _RateOfFireAR = 15f;
    private float _TimeOfFire = 0f;
    Regex Rar15 = new Regex (@"^ar15[\W\d\w]*");
    Regex Rshotgun = new Regex (@"^shotgun[\W\d]*");
    Regex Rpistol = new Regex (@"^pistol[\W\d]*");
    Regex Rsubmachine = new Regex (@"^submachine[\W\d]*");
    [Header ("Основные префабы ружбаек")] 
    public GameObject ar15;
    [Header ("Выбранный объект")] 
    [SerializeField]
    private Collider2D col;

    [Header ("Поля для пули")]
    public float bulletForce = 20f;
    public Transform firePoint;
    public GameObject bulletPrefab; 
    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _TimeOfFire = _RateOfFireAR;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if (pls.weaponFirst == null)
            {
                if(Rar15.IsMatch(pls.col.name) == true)
                {   
                    col=pls.col;
                    m_SpriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
                    Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
                    ammoAR = col.gameObject.GetComponent<AmmoAR15>();
                    rb.simulated = false;
                    pls.weaponFirst = ar15;
                    //Destroy(pls.col.gameObject);
                    m_SpriteRenderer.enabled = false;
                    col.transform.SetParent(firePoint.GetComponent<Transform>());
                    pls.animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("GGar15");
                }
                //pls.col.transform.SetParent(pls.plr);
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (pls.weaponFirst != null)
            {
                pls.animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("GGrun");
                //GameObject weapon = Instantiate(pls.weaponFirst.gameObject, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
                col.transform.SetParent(null);
                rb.AddForce(firePoint.up * 15, ForceMode2D.Impulse);
                m_SpriteRenderer.enabled = true;
                rb.simulated = true;
                pls.weaponFirst = null;
            }
        }
        if (pls.weaponFirst == ar15)
        {
            if (ammoAR.ammo < 30)
                if (pls.AmmoAr15 != 0)
                    if (Input.GetKeyDown(KeyCode.R))
                    {  
                        ReloadAR();
                    }
        }
 

    }
    void FixedUpdate()
    {
        if (pls.weaponFirst.name == "ar15") 
            if(Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse0) )
            {
                ShootAR();
                _TimeOfFire+=1f;
        } 
    }
    void ShootAR()
    {
        if(_TimeOfFire>_RateOfFireAR)
        if (ammoAR.ammo != 0)
        {
            ammoAR.ammo -= 1;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            _TimeOfFire=0f;
        }
        
    }
    void ReloadAR()
    {
        pls.AmmoAr15 = ammoAR.ammo + pls.AmmoAr15;
        ammoAR.ammo = 0; 
            if (pls.AmmoAr15 >= 30) 
            {
                pls.AmmoAr15 = pls.AmmoAr15 - 30;
                ammoAR.ammo = 30; 
            }
            else 
            {
                ammoAR.ammo = pls.AmmoAr15;
                pls.AmmoAr15 = 0;
            }
    }
}
