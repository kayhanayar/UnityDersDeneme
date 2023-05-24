using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKod : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 hizVectoru;
    Yon yon;
    public float hizCarpani;
    Transform kareTransform;
    public GameObject mermiSablon;
    enum Yon
    {
        Sol,
        Sag,
        Yukari,
        Asagi
    }
    float mermiAtisAraligi = 0.2f;
    float mermiAtisZamani = 0.0f;
    float sinirX;
    float sinirY;
    float colliderYarimYukseklik;
    float colliderYarimGenislik;
    float colliderX;
    float colliderY;
    float xMove;
    float yMove;
     Rigidbody2D rb;
    Animator animator;
    List<GameObject> mermiler;
    int yasam = 5;
    void Start()
    {
        var cameraObj = GameObject.Find("Main Camera");

        var camera = cameraObj.GetComponent<Camera>();
        sinirY = camera.orthographicSize;
        sinirX = camera.orthographicSize * camera.aspect;
        
        hizVectoru.x = hizCarpani;
        yon = Yon.Sag;
        rb = GetComponent<Rigidbody2D>();


        hizCarpani = 2.0f;
        kareTransform = GameObject.Find("MermiCikisNoktasi").transform;
        mermiler = new List<GameObject>();
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }
    public List<GameObject> Mermiler
    {
        get;
    }
    void girisKontrol()
    {
        bool yukariBasildimi = false;
        bool asagiBasildimi = false;
         xMove = Input.GetAxis("Horizontal");
         yMove = Input.GetAxis("Vertical");
        yukariBasildimi = yMove > 0;
        asagiBasildimi = yMove < 0;

        animator.SetBool("AsagiBasildimi", asagiBasildimi);
        animator.SetBool("YukariBasildimi", yukariBasildimi);

    }
    void konumGuncelle()
    {
        hizVectoru.x = xMove*hizCarpani;
        hizVectoru.y = yMove*hizCarpani;

        rb.velocity = hizVectoru;

    }
  
    void atesKontrol()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(mermiAtisZamani>=mermiAtisAraligi)
            {
                var yeniMermi = Instantiate(mermiSablon);
                yeniMermi.transform.position = kareTransform.position;
                mermiler.Add(yeniMermi);
                mermiAtisZamani = 0.0f;
            }
            
        }
        mermiAtisZamani += Time.deltaTime;
    }
    void mermiKonumKontrol()
    {
        for(int i=0;i<mermiler.Count;i++)
        {
            var mermi = mermiler[i];
            var collider = mermi.GetComponent<BoxCollider2D>();
           
            var colX = collider.bounds.min.x;
            if(colX>sinirX)
            {
                Destroy(mermi);
                mermiler.Remove(mermi);
            }
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Vurulabilir"))
        {
            PatlamaUretici.PatlamaUret(collision.gameObject.transform.position);
            Destroy(collision.gameObject);
            yasam--;
            if(yasam==0)
            {
                PatlamaUretici.PatlamaUret(transform.position);
                
                Destroy(gameObject);
            }

        }
    }
    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        
        girisKontrol();
        atesKontrol();
        //mermiKonumKontrol();
        konumGuncelle();




    }
}
