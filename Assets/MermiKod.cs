using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using static DusmanKod;

public class MermiKod : MonoBehaviour,IKayitEdilebilir
{
    [Serializable]
    public class MermiVerisi : OyunNesneVerisi
    {
        public float HizCarpani;
    }
    // Start is called before the first frame update
    [SerializeField] float hizCarpani=3.0f;
    [SerializeField] GameObject patlamaSablon;
    Vector3 hizVectoru;
    void Start()
    {
        
        hizVectoru.x = 3.0f;
        Kaydedici.KaydetmeListesineEkle(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Vurulabilir"))
        {
            PatlamaUretici.PatlamaUret(collision.gameObject.transform.position);
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
    public void OnDestroy()
    {
        Kaydedici.KayitListesindenCikar(this);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "SahneSagSinir")
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += hizVectoru*Time.deltaTime;
    }

    public void KayittanOlustur(OyunNesneVerisi veri)
    {
        MermiVerisi mermiveri = (MermiVerisi)veri;

        transform.position = mermiveri.Konum;
        transform.rotation = mermiveri.Yonlendirme;
        hizCarpani = mermiveri.HizCarpani;
    }

    public OyunNesneVerisi KayitGetir()
    {
        MermiVerisi mermiVeri = new MermiVerisi();
        mermiVeri.Konum = transform.position;
        mermiVeri.Yonlendirme = transform.rotation;
        mermiVeri.HizCarpani = hizCarpani;
        mermiVeri.SablonIsmi = "Mermi";
        return mermiVeri;

    }
}
