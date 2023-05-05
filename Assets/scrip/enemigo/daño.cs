using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daño : MonoBehaviour
{

    [SerializeField] private float tiempoEntreDaño;


    private float tiempoSiuienteDaño;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            tiempoSiuienteDaño -= Time.deltaTime;
            if (tiempoSiuienteDaño <= 0)
            {
                other.GetComponent<vida>().TomarDaño(3);
                tiempoSiuienteDaño = tiempoEntreDaño;
            }
        }
    }









    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
