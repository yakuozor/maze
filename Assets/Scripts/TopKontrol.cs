using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopKontrol : MonoBehaviour
{
    private Rigidbody rb;

    public TextMeshProUGUI Zaman;
    public TextMeshProUGUI Can;
    public TextMeshProUGUI Win;
    public TextMeshProUGUI Lose;
    public GameObject buton;

    public bool Oyundevam=true;


    float zamanSayaci = 10f;
    int canSayaci = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {
        if (zamanSayaci > 0 && Oyundevam)
        {
            zamanSayaci -= Time.deltaTime;
            Zaman.text = "ZAMAN: " + (int)zamanSayaci;
        }
        Can.text = "CAN: " + canSayaci;
        
        if(zamanSayaci==0 || canSayaci == 0)
        {          
            Lose.gameObject.SetActive(true);
            Oyundevam = false;
        }
        if (!Oyundevam)
        {
            buton.gameObject.SetActive(true);
        }
    
    
    }

    private void FixedUpdate()
    {
        if (Oyundevam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(yatay, 0, dikey);
            rb.AddForce(kuvvet);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string objismi = collision.gameObject.name;
        string objtag = collision.gameObject.tag;


        if (objismi.Equals("AmaçZemin"))
        {
            print("Oyun Tamamlandý");
            Win.gameObject.SetActive(true);
            Oyundevam = false;
        }
        else if (objtag.Equals("Duvar"))
        {
            if (canSayaci > 0)
            {
                canSayaci -= 1;
            }
        }    
    }
}
