using UnityEngine;
public class Jugador : MonoBehaviour
{
    public float VelocidadJugador = 2f;
    public float VidaJugador = 100f;
    public float VidaMaximaJugador = 100f;
    public BarraVida BarraDeVida;

    void Update()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 Dir = new Vector3(x, y, 0).normalized;

        if (Dir != Vector3.zero)
            transform.position += Dir * VelocidadJugador * Time.deltaTime;
    }
    public void DañoRecibidoJugador(float Cantidad)
    {
        VidaJugador -= Cantidad;
        Debug.Log($"Vida de Shushu: {VidaJugador}");
        BarraDeVida.ActualizarBarra(VidaJugador, VidaMaximaJugador);
    }
}
