using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static MermiKod;
using static OyuncuKod;

public class DusmanKod : MonoBehaviour, IKayitEdilebilir
{
    [Serializable]
    public class DusmanVerisi : AnimasyonluNesneVerisi
    {
        public float HizCarpani;
    }
    // Start is called before the first frame update
    float hizCarpani = 0.2f;
    Rigidbody2D rb;
    Vector3 hizVectoru;

    int baslangicAcisi;
    int yon;
    float artisMiktari;
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hizVectoru.x = -1;
        var renderer = GetComponent<SpriteRenderer>();
        float r = UnityEngine.Random.Range(0.2f, 1.0f);
        float g = UnityEngine.Random.Range(0.3f, 1.0f);
        float b = UnityEngine.Random.Range(0.5f, 1.0f);

        
        rb.velocity = hizVectoru;

        baslangicAcisi = UnityEngine.Random.Range(0, 360);
        if(UnityEngine.Random.Range(0,2)==0)
        {
            yon = 1;
        }
        else
        {
            yon = -1;
        }

        artisMiktari = UnityEngine.Random.Range(0.5f, 1.0f);


        var solSinirCollider= GameObject.Find("SolSinir").GetComponent<BoxCollider2D>();
        var dusmanCollider = GetComponent<BoxCollider2D>();
        Kaydedici.KaydetmeListesineEkle(this);
        
    }
    private void OnDestroy()
    {
        Kaydedici.KayitListesindenCikar(this);
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

    public void KayittanOlustur(OyunNesneVerisi veri)
    {
        DusmanVerisi dusmanveri  = (DusmanVerisi)veri;

        transform.position = dusmanveri.Konum;
        transform.rotation = dusmanveri.Yonlendirme;
        hizCarpani = dusmanveri.HizCarpani;
        animator.Play(dusmanveri.AnimasyonKodu, 0, dusmanveri.AnimasyonZamani);
    }

    public OyunNesneVerisi KayitGetir()
    {
        DusmanVerisi mermiVeri = new DusmanVerisi();
        mermiVeri.Konum = transform.position;
        mermiVeri.Yonlendirme = transform.rotation;
        mermiVeri.HizCarpani = hizCarpani;
        mermiVeri.SablonIsmi = "Dusman";
        mermiVeri.AnimasyonKodu = animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
        mermiVeri.AnimasyonZamani = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        return mermiVeri;
        
    }
}
