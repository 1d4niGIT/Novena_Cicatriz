using UnityEngine;

public class Enemigo_bebeDuende : MonoBehaviour
{
    public GameObject Objetivo;
    public float radioMovimiento = 3f;
    public float radioAtaque = 0.2f;
    public float VelocidadBebeDuende = 0.7f;
    public bool AtaqueEnemigoDisponible = true;
    public float Daño = 1f;
    public float TiempoActual;
    public float TiempoMaximo = 2f;

    void Start()
    {
        Objetivo = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        SeguirObjetivo();
        if (!AtaqueEnemigoDisponible)
            CooldownEnemigo();
    }
    public void SeguirObjetivo()
    {
        Vector3 dir = (Objetivo.transform.position - transform.position).normalized;
        if (Vector3.Distance(Objetivo.transform.position, transform.position) < radioMovimiento)
        {
            if (Vector3.Distance(Objetivo.transform.position, transform.position) < radioAtaque)
            {
                if (AtaqueEnemigoDisponible)
                {
                    Objetivo.GetComponent<Jugador>().VidaJugador -= Daño;
                    AtaqueEnemigoDisponible = false;
                }
            }
            else
            {
                transform.position += dir * VelocidadBebeDuende * Time.deltaTime;
            }
        }
    }
    public void CooldownEnemigo()
    {
        TiempoActual += Time.deltaTime;
        if (TiempoActual >= TiempoMaximo)
        {
            AtaqueEnemigoDisponible = true;
            TiempoActual = 0;
        }
    }

}
