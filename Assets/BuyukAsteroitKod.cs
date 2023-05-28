using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyukAsteroitKod : MonoBehaviour,IKayitEdilebilir
{
    [Serializable]
    class BuyukAsteroitVeri:OyunNesneVerisi
    {
        public int yasam;
        public float hizCarpani;
    }
    // Start is called before the first frame update
    [SerializeField] GameObject Asteroit;
    [SerializeField] TextMeshPro Yazi;
    [SerializeField] float Hiz;
    float hizCarpani = 0.1f;
    int yasam = 6;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * Hiz*hizCarpani;
        Yazi.text = yasam.ToString();
        Kaydedici.KaydetmeListesineEkle(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Mermi"))
        {
            
            yasam--;

            if (yasam == 0)
            {
                Destroy(gameObject);
                PatlamaUretici.PatlamaUret(Asteroit.transform.position);
                
            }
            Destroy(collision.gameObject);
            Yazi.text = yasam.ToString();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        Asteroit.transform.Rotate(0.0f, 0.0f, 0.5f);
        
    }
    private void OnDestroy()
    {
        Kaydedici.KayitListesindenCikar(this);
    }
    public void KayittanOlustur(OyunNesneVerisi veri)
    {
        BuyukAsteroitVeri asteroidveri=(BuyukAsteroitVeri) veri;
        transform.position = asteroidveri.Konum;
        transform.rotation = asteroidveri.Yonlendirme;
        yasam = asteroidveri.yasam;
        hizCarpani = asteroidveri.hizCarpani;
        Yazi.text = yasam.ToString();
    }

    public OyunNesneVerisi KayitGetir()
    {
        BuyukAsteroitVeri veri = new BuyukAsteroitVeri();
        veri.Konum = transform.position;
        veri.Yonlendirme = transform.rotation;
        veri.yasam = yasam;
        veri.hizCarpani = hizCarpani;
        veri.SablonIsmi = "BuyukAsteroid";
        return veri;
    }
}
