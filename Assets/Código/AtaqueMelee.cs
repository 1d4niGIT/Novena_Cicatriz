using UnityEngine;
using System.Collections.Generic;

public class AtaqueMelee : MonoBehaviour
{
    public float Daño = 10f;
    private HashSet<Enemigo> EnemigosGolpeados = new HashSet<Enemigo>();

    void OnTriggerEnter2D(Collider2D Colisionador)
    {
        if (Colisionador.CompareTag("Enemigo"))
        {
            Enemigo ComponenteEnemigo = Colisionador.GetComponent<Enemigo>();
            if (ComponenteEnemigo != null && !EnemigosGolpeados.Contains(ComponenteEnemigo))
            {
                ComponenteEnemigo.DañoRecibidoEnemigo(Daño);
                EnemigosGolpeados.Add(ComponenteEnemigo);
            }
        }
    }

}
