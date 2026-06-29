using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private GameObject Objetivo;
    public float VidaEnemigo = 50f;
    public float RadioDeteccion = 2f;
    public float RadioAtaque = 0.2f;
    public float VelocidadEnemigo = 1f;
    public bool AtaqueEnemigoDisponible = true;
    public float DañoEnemigo = 1f;
    public float TiempoActual;
    public float TiempoMaximo = 2f;
    public enum EnemigoEnum {None, Idle, Perseguir, Atacar, Morir}
    public EnemigoEnum estado = EnemigoEnum.Idle;
    private Jugador ComponenteJugador; //Jugador es un tipo de referencia a componente (un script)
    private AparicionAlma ComponenteAparicion;

    void Start()
    {
        Objetivo = GameObject.FindWithTag("Player");
        ComponenteJugador = Objetivo.GetComponent<Jugador>();
        ComponenteAparicion = GetComponent<AparicionAlma>();
    }

    void Update()
    {
        EstadoEnemigo();
    }

    public void EstadoEnemigo()
    {
        Vector3 ObjetivoPos = Objetivo.transform.position;
        Vector3 MiPos = transform.position;
        Vector3 dir = (ObjetivoPos - MiPos).normalized;

        if (!AtaqueEnemigoDisponible)
            CooldownEnemigo();

        if (VidaEnemigo <= 0)
            estado = EnemigoEnum.Morir;

        switch (estado)
        {
            case EnemigoEnum.None:
                break;

            case EnemigoEnum.Idle:
                {
                    if (Vector3.Distance(ObjetivoPos, MiPos) < RadioDeteccion)
                        estado = EnemigoEnum.Perseguir;
                }
                break;

            case EnemigoEnum.Perseguir:
                {
                    transform.position += dir * VelocidadEnemigo * Time.deltaTime;

                    if (Vector3.Distance(ObjetivoPos, MiPos) > RadioDeteccion)
                        estado = EnemigoEnum.Idle;

                    if (Vector3.Distance(ObjetivoPos, MiPos) < RadioAtaque)
                        estado = EnemigoEnum.Atacar;
                }
                break;

            case EnemigoEnum.Atacar:
                {
                    if (AtaqueEnemigoDisponible)
                    {
                        ComponenteJugador.VidaJugador -= DañoEnemigo;
                        Debug.Log($"Vida de Shushu: {ComponenteJugador.VidaJugador}");
                        AtaqueEnemigoDisponible = false;
                    }

                    if (Vector3.Distance(ObjetivoPos, MiPos) > RadioAtaque)
                        estado = EnemigoEnum.Perseguir;
                }
                break;

            case EnemigoEnum.Morir:
                {
                    ComponenteAparicion.Aparicion();
                    Destroy(gameObject);
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
