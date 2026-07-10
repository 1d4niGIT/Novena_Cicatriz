using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimacionesShushuYDemonio : MonoBehaviour
{
    public Animator Animacion;
    private bool Moviendose;
    private Jugador ComponenteJugador;
    private bool EstaMuerto = false;
    void Start()
    {
        ComponenteJugador = GetComponentInParent<Jugador>();
        Animacion.SetFloat("X", 0f);
        Animacion.SetFloat("Y", -1f);
    }

    void Update()
    {
        Animar(ComponenteJugador.X, ComponenteJugador.Y, ComponenteJugador.Entrada);
        VerificarMuerte();
    }

    private void Animar(float X, float Y, Vector3 Entrada)
    {
        if (Entrada.magnitude > 0.1f || Entrada.magnitude < -0.1f)
        {
            Moviendose = true;
        }
        else
        {
            Moviendose = false;
        }

        if(Moviendose)
        {
            Animacion.SetFloat("X", X);
            Animacion.SetFloat("Y", Y);
        }

        Animacion.SetBool("Moviendose", Moviendose);
    }
    public void VerificarMuerte()
    {
        {
            if ((ComponenteJugador.VidaJugador <= 0) && (!EstaMuerto))
            {
                Animacion.SetTrigger("Muerto");
                EstaMuerto = true;
            }
        }
    }
}
