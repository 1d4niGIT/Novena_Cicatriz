using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image RellenoVida;
    private Jugador ControlJugador;
    private float vidaMaxima;
    void Start()
    {
        ControlJugador = GameObject.Find("Shushu").GetComponent<Jugador>();
        vidaMaxima = ControlJugador.VidaJugador;
    }

    void Update()
    {
        RellenoVida.fillAmount = ControlJugador.VidaJugador / vidaMaxima;
    }
}
