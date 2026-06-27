using System.ComponentModel;
using UnityEngine;

public class AtaqueRango : MonoBehaviour
{
    public float VelocidadProyectil = 3f;
    public float TiempoVivo = 3f;
    public float DañoRango = 5f;
    
    void Start()
    {
        Destroy(gameObject, TiempoVivo);
    }
    private void OnTriggerEnter2D(Collider2D Colisionador)
    {
        if (Colisionador.CompareTag("Enemigo"))
        {
            Enemigo ComponenteEnemigo = Colisionador.GetComponent<Enemigo>(); //Asigno el componente del objeto que chocó
            ComponenteEnemigo.VidaEnemigo -= DañoRango;
            Destroy(gameObject);
        }
        
    }

    void Update()
    {

        transform.position += transform.up * VelocidadProyectil * Time.deltaTime;

    }
}
