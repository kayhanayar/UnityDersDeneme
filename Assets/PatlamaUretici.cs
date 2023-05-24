using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaUretici : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]   GameObject patlamaSablon;
    private static PatlamaUretici Instance;
    void Start()
    {
        Instance = this;
    }
    public  static void PatlamaUret(Vector3 konum)
    {
        var patlama = Instantiate(Instance.patlamaSablon, konum, Quaternion.identity);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
