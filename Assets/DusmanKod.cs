using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKod : MonoBehaviour
{
    // Start is called before the first frame update
    float hizCarpani = 0.2f;
    Rigidbody2D rb;
    Vector3 hizVectoru;

    int baslangicAcisi;
    int yon;
    float artisMiktari;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hizVectoru.x = -1;
        var renderer = GetComponent<SpriteRenderer>();
        float r = Random.Range(0.2f, 1.0f);
        float g = Random.Range(0.3f, 1.0f);
        float b = Random.Range(0.5f, 1.0f);

        
        rb.velocity = hizVectoru;

        baslangicAcisi = Random.Range(0, 360);
        if(Random.Range(0,2)==0)
        {
            yon = 1;
        }
        else
        {
            yon = -1;
        }

        artisMiktari = Random.Range(0.5f, 1.0f);


        var solSinirCollider= GameObject.Find("SolSinir").GetComponent<BoxCollider2D>();
        var dusmanCollider = GetComponent<BoxCollider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name=="SolSinir")
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
