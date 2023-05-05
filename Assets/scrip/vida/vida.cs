using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    [SerializeField] int vidaa;

    [SerializeField] int maximoVida;





    // Start is called before the first frame update
    void Start()
    {
        vidaa = maximoVida;
    }


    public void TomarDaño(int daño)
    {
        vidaa -= daño;
        if (vidaa <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void Curar(int curacion)
    {
        if ((vidaa + curacion) > maximoVida)
        {
            vidaa = maximoVida;

        }
        else
        {
            vidaa += curacion;
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
