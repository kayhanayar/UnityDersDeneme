using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanUreticiKod : MonoBehaviour,IKayitEdilebilir
{
    [Serializable]
    class DusmanUreticiVerisi:OyunNesneVerisi
    {
        public float UretmeZamanSiniri;
        public float UretmeZamanSayaci;
    }
    // Start is called before the first frame update
    [SerializeField] GameObject dusmanSablon;
    float uretmeZamanSiniri = 0.5f;
    float uretmeZamanSayaci = 0.0f;
    float maxY;
    float minY;
    float X;
    
   
    void Start()
    {
        
        maxY = GameObject.Find("UretmeUstSinir").transform.position.y;
        minY = GameObject.Find("UretmeAltSinir").transform.position.y;
        X = GameObject.Find("UretmeAltSinir").transform.position.x;
        
        Kaydedici.KaydetmeListesineEkle(this);
        
    }
    private void OnDestroy()
    {
        Kaydedici.KayitListesindenCikar(this);
    }
    void dusmanUret()
    {
        if (uretmeZamanSayaci > uretmeZamanSiniri)
        {
            var yeniDusman = Instantiate(dusmanSablon, transform);
            float Y = UnityEngine.Random.Range(minY, maxY);
            yeniDusman.transform.position = new Vector3(X, Y, 0.0f);
            uretmeZamanSayaci = 0.0f;
        }

        uretmeZamanSayaci += Time.deltaTime;
    }
 
    // Update is called once per frame
    void Update()
    {
        dusmanUret();
    }

    public void KayittanOlustur(OyunNesneVerisi veri)
    {
        DusmanUreticiVerisi ureticiveri = (DusmanUreticiVerisi)veri;

        uretmeZamanSayaci = ureticiveri.UretmeZamanSayaci;
        uretmeZamanSiniri = ureticiveri.UretmeZamanSiniri;
        



    }

    public OyunNesneVerisi KayitGetir()
    {
        DusmanUreticiVerisi veri = new DusmanUreticiVerisi();
        veri.UretmeZamanSayaci = uretmeZamanSayaci;
        veri.UretmeZamanSiniri = uretmeZamanSiniri;
        veri.SablonIsmi = "DusmanUretici";
        return veri;
    }
}
