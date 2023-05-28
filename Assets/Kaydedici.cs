using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



[Serializable]
public class OyunNesneVerisi
{
    public Vector3      Konum;
    public Quaternion   Yonlendirme;
    public string       SablonIsmi;
}
[Serializable]
public class AnimasyonluNesneVerisi:OyunNesneVerisi
{
    public int AnimasyonKodu;
    public float AnimasyonZamani;
}
[Serializable]
public class Anim
{
    public int AnimasyonKodu;
    public float AnimasyonZamani;
}
[Serializable]
public class Son
{
    public Anim anim;
    public OyunNesneVerisi nesne;
}
public interface IKayitEdilebilir
{
    public void     KayittanOlustur(OyunNesneVerisi veri);
    public OyunNesneVerisi KayitGetir();
}
[Serializable]
public class Kayit
{
    public Kayit(System.Object sinif)
    {
        TurIsmi = sinif.GetType().FullName;
        Nesne = JsonUtility.ToJson(sinif);
    }
    public string TurIsmi ;
    
    public string Nesne;
}
public class Kaydedici : MonoBehaviour
{
    
    static Kaydedici kaydedici;

    [SerializeField] public List<GameObject> SablonListesi;

    Dictionary<string, GameObject> SablonSozlugu;

    List<IKayitEdilebilir> oyunNesneleri = new List<IKayitEdilebilir>();
    public static void KaydetmeListesineEkle(IKayitEdilebilir nesne )
    {
        kaydedici.oyunNesneleri.Add(nesne);
    }
    public static void KayitListesindenCikar(IKayitEdilebilir nesne)
    {
        kaydedici.oyunNesneleri.Remove(nesne);
    }
    public Kaydedici()
    {
        kaydedici = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SablonSozluguOlustur();
        SahneOlustur();

    }
    void SablonSozluguOlustur()
    {
        SablonSozlugu = new Dictionary<string, GameObject>();
        foreach(var siradaki in SablonListesi)
        {
            SablonSozlugu[siradaki.name] = siradaki;
        }
        
    }
    public void DosyadanOku()
    {
        using StreamReader okuyucu = new StreamReader("Kayit.txt");
        while (okuyucu.EndOfStream == false)
        {
            var satir = okuyucu.ReadLine();

            Kayit kayit = JsonUtility.FromJson<Kayit>(satir);

            var nesne = JsonUtility.FromJson(kayit.Nesne, Type.GetType(kayit.TurIsmi));
            
            var siradaki = Instantiate(SablonSozlugu[((OyunNesneVerisi)nesne).SablonIsmi]);

            siradaki.GetComponent<IKayitEdilebilir>().KayittanOlustur((OyunNesneVerisi)nesne);
           
        }
    }
    public void DosyayaYaz()
    {
        using StreamWriter yazici = new StreamWriter("Kayit.txt");

        foreach (var siradaki in oyunNesneleri)
        {
            Kayit kayit = new Kayit(siradaki.KayitGetir());

            var kayitjson = JsonUtility.ToJson(kayit);

            yazici.WriteLine(kayitjson);

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            DosyayaYaz();
            Time.timeScale = 0.0f;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }
    public void SahneOlustur()
    {
        if(File.Exists("Kayit.Txt"))
        {
            DosyadanOku();
            Time.timeScale = 0.0f;
        }
        else
        {
            Instantiate(SablonSozlugu["Oyuncu"]);
            Instantiate(SablonSozlugu["DusmanUretici"]);
            Instantiate(SablonSozlugu["AsteroidUretici"]);
        }
    }
}
