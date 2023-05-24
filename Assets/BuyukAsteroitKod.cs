using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyukAsteroitKod : MonoBehaviour
{
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
        Asteroit.transform.Rotate(0.0f, 0.0f, 1.0f);
        
    }
}
