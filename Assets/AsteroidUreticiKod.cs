using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidUreticiKod : MonoBehaviour,IKayitEdilebilir
{
    [Serializable]
    public class AsteroidUreticiVeri:OyunNesneVerisi
    {
        public float UretmeZamanSiniri;
        public float UretmeZamanSayaci;
    }
    [SerializeField] GameObject asteroidSablon;
    [SerializeField] Transform UstSinir;
    [SerializeField] Transform AltSinir;
    float uretmeZamanSiniri = 7.5f;
    float uretmeZamanSayaci = 0.0f;
    float maxY;
    float minY;
    float X;

    public OyunNesneVerisi KayitGetir()
    {
        AsteroidUreticiVeri veri = new AsteroidUreticiVeri();
        veri.UretmeZamanSayaci = uretmeZamanSayaci;
        veri.UretmeZamanSiniri = uretmeZamanSiniri;
        veri.SablonIsmi = "AsteroidUretici";
        return veri;
    }

    public void KayittanOlustur(OyunNesneVerisi veri)
    {
        AsteroidUreticiVeri ureticiveri = (AsteroidUreticiVeri)veri;

        uretmeZamanSayaci = ureticiveri.UretmeZamanSayaci;
        uretmeZamanSiniri = ureticiveri.UretmeZamanSiniri;
       
    }
    void AsteroidUret()
    {
        if (uretmeZamanSayaci > uretmeZamanSiniri)
        {
            var yeniDusman = Instantiate(asteroidSablon, transform);
            float Y = UnityEngine.Random.Range(minY, maxY);
            yeniDusman.transform.position = new Vector3(X, Y, 0.0f);
            uretmeZamanSayaci = 0.0f;
        }

        uretmeZamanSayaci += Time.deltaTime;
    }

    void Start()
    {
        maxY = UstSinir.position.y;
        minY = AltSinir.position.y;
        X = AltSinir.position.x;

        Kaydedici.KaydetmeListesineEkle(this);
    }
    private void OnDestroy()
    {
        Kaydedici.KayitListesindenCikar(this);
    }
    // Update is called once per frame
    void Update()
    {
        AsteroidUret();
    }
}
