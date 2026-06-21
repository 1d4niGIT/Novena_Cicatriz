using UnityEngine;

public class EstadoEnemigo : MonoBehaviour
{
    public GameObject Objetivo;
    public float radioDeteccion = 2f;
    public float radioAtaque = 0.2f;
    public float VelocidadEnemigo = 1f;
    public bool AtaqueEnemigoDisponible = true;
    public float Daño = 1f;
    public float TiempoActual;
    public float TiempoMaximo = 2f;
    public enum EnemigoEnum {None, Idle, Perseguir, Atacar}
    public EnemigoEnum estado = EnemigoEnum.Idle;

    void Start()
    {
        Objetivo = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 ObjetivoPos = Objetivo.transform.position;
        Vector3 MiPos = transform.position;
        Vector3 dir = (ObjetivoPos - MiPos).normalized;

        if (!AtaqueEnemigoDisponible)
            CooldownEnemigo();

        switch (estado)
        {
            case EnemigoEnum.None:
                break;
            case EnemigoEnum.Idle:
                { 
                    if (Vector3.Distance(ObjetivoPos, MiPos) < radioDeteccion)
                        estado = EnemigoEnum.Perseguir;
                }
                break;
            case EnemigoEnum.Perseguir:
                {
                    transform.position += dir * VelocidadEnemigo * Time.deltaTime;

                    if (Vector3.Distance(ObjetivoPos, MiPos) > radioDeteccion)
                        estado = EnemigoEnum.Idle;

                    if (Vector3.Distance(ObjetivoPos, MiPos) < radioAtaque)
                        estado = EnemigoEnum.Atacar;
                }
                break;
            case EnemigoEnum.Atacar:
                {
                    if (AtaqueEnemigoDisponible)
                    {
                        Objetivo.GetComponent<Jugador>().Vida -= Daño;
                        AtaqueEnemigoDisponible = false;
                    }

                    if (Vector3.Distance(ObjetivoPos, MiPos) > radioAtaque)
                        estado = EnemigoEnum.Perseguir;
                }
                break;
            default:
                break;
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
