using UnityEngine;

public class AtaqueMelee : MonoBehaviour
{
    public float Daño = 10f;
    private bool YaGolpeo = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Colisionador)
    {
        if (YaGolpeo) return;

        if (Colisionador.CompareTag("Enemigo"))
        {
            Enemigo ComponenteEnemigo = Colisionador.GetComponent<Enemigo>();
            if (ComponenteEnemigo != null)
            {
                ComponenteEnemigo.DañoRecibidoEnemigo(Daño);
                YaGolpeo = true;
            }
        }
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }

}
