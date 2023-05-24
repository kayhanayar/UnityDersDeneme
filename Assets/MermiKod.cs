using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiKod : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float hizCarpani=3.0f;
    [SerializeField] GameObject patlamaSablon;
    Vector3 hizVectoru;
    void Start()
    {
        hizVectoru.x = 3.0f;
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
}
