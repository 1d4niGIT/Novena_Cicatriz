using UnityEngine;

public class AnimacionAtacar : MonoBehaviour
{
    public Animator Animacion;
    private Jugador ComponenteJugador;

    void Start()
    {
        ComponenteJugador = GetComponentInParent<Jugador>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            AnimarAtaque(ComponenteJugador.UltimaX, ComponenteJugador.UltimaY);
        }
    }

    private void AnimarAtaque(float X, float Y)
    {
        Animacion.SetFloat("X", X);
        Animacion.SetFloat("Y", Y);
        Animacion.ResetTrigger("Atacando");
        Animacion.SetTrigger("Atacando");
    }
}