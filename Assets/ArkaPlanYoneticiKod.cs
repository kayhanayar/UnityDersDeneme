using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanYoneticiKod : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] resimler;
    [SerializeField] float HizCarpani;
    Vector3 Hiz;
    Vector3 Merkez;
    int merkezdekiIndeks;
    int tasinanIndeks;
    float Genislik;
    void Start()
    {
        Merkez = resimler[0].transform.position;
        merkezdekiIndeks = 0;
        tasinanIndeks = 1;
        Genislik = resimler[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        Genislik = resimler[0].transform.localScale.x * Genislik;
        
    }
    void Degistir()
    {
        if (resimler[tasinanIndeks].transform.position.x<Merkez.x)
        {
            resimler[merkezdekiIndeks].transform.position = resimler[tasinanIndeks].transform.position+
                                                            new Vector3(Genislik, 0.0f, 0.0f);
            int temp = merkezdekiIndeks;
            merkezdekiIndeks = tasinanIndeks;
            tasinanIndeks = temp;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Hiz.x = HizCarpani;
        resimler[0].transform.position-=Hiz*Time.deltaTime;
        resimler[1].transform.position -= Hiz * Time.deltaTime;
        Degistir();
    }
}
