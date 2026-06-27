using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image RellenoVida;
    public Jugador ComponenteJugador;
    private float vidaMaxima;
    void Start()
    {
        vidaMaxima = ComponenteJugador.VidaJugador;
    }

    void Update()
    {
        RellenoVida.fillAmount = ComponenteJugador.VidaJugador / vidaMaxima;
    }
}
