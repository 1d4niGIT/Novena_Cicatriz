using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private GameObject Objetivo;
    public float VidaEnemigo = 50f;
    public float VidaMaximaEnemigo = 50f;
    public float RadioDeteccion = 2f;
    public float RadioAtaque = 0.4f;
    public float VelocidadEnemigo = 0.8f;
    public bool AtaqueEnemigoDisponible = true;
    public float DañoEnemigo = 1f;
    public BarraVida BarraDeVida;
    public float TiempoActual;
    public float TiempoMaximoAtaque = 2f;
    public enum EnemigoEnum {None, Idle, Perseguir, Atacar, Morir}
    public EnemigoEnum estado = EnemigoEnum.Idle;
    private Jugador ComponenteJugador; //Jugador es un tipo de referencia a componente (un script)
    private AparicionAlma ComponenteAparicion;
    public Animator Animacion;
    public SpriteRenderer Sprite;

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
        Vector3 Dir = (ObjetivoPos - MiPos).normalized;

        if (!AtaqueEnemigoDisponible)
            TiempoAtaqueEnemigo();

        if (VidaEnemigo <= 0)
            estado = EnemigoEnum.Morir;

        switch (estado)
        {
            case EnemigoEnum.None:
                break;

            case EnemigoEnum.Idle:
                {
                    Animacion.SetBool("Perseguir", false);

                    if (Vector3.Distance(ObjetivoPos, MiPos) < RadioDeteccion) { estado = EnemigoEnum.Perseguir; }
                        
                }
                break;

            case EnemigoEnum.Perseguir:
                {
                    Animacion.SetBool("Perseguir", true);

                    transform.position += Dir * VelocidadEnemigo * Time.deltaTime;

                    Voltear(Dir.x);

                    if (Vector3.Distance(ObjetivoPos, MiPos) > RadioDeteccion) { estado = EnemigoEnum.Idle; }  

                    if (Vector3.Distance(ObjetivoPos, MiPos) < RadioAtaque) { estado = EnemigoEnum.Atacar; }
                        
                }
                break;

            case EnemigoEnum.Atacar:
                {
                    if (AtaqueEnemigoDisponible)
                    {
                        Animacion.SetBool("Perseguir", false);
                        Animacion.SetTrigger("Atacar");
                        ComponenteJugador.DañoRecibidoJugador(DañoEnemigo);
                        AtaqueEnemigoDisponible = false;
                    }

                    if (Vector3.Distance(ObjetivoPos, MiPos) > RadioAtaque) { estado = EnemigoEnum.Perseguir; }
                       
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

    public void TiempoAtaqueEnemigo()
    {
        TiempoActual += Time.deltaTime;
        if (TiempoActual >= TiempoMaximoAtaque)
        {
            AtaqueEnemigoDisponible = true;
            TiempoActual = 0;
        }
    }
    public void DañoRecibidoEnemigo(float Cantidad)
    {
        VidaEnemigo -= Cantidad;
        BarraDeVida.ActualizarBarra(VidaEnemigo, VidaMaximaEnemigo);
    }

    public void Voltear(float DireccionX)
    {
        if (DireccionX > 0.1f)
        {
            Sprite.flipX = true; 
        }
        else if (DireccionX < -0.1f)
        {
            Sprite.flipX = false; 
        }
    }
}
