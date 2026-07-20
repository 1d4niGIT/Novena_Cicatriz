using UnityEngine;
public class Jugador : MonoBehaviour
{
    public float VelocidadJugador = 1.6f;
    public float VidaJugador = 100f;
    public float VidaMaximaJugador = 100f;
    public BarraVida BarraDeVida;
    public float X;
    public float Y;
    public float UltimaX;
    public float UltimaY;
    public Vector3 Entrada;
    public float SaciedadActual = 0f;
    public float SaciedadMaxima = 100f;

    private void Start()
    {
        
    }

    void Update()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");

        if (X != 0 || Y != 0)
        {
            UltimaX = X;
            UltimaY = Y;
        }

        Entrada = new Vector3(X, Y, 0).normalized;

        if (Entrada != Vector3.zero)
            transform.position += Entrada * VelocidadJugador * Time.deltaTime;
    }

    public void DañoRecibidoJugador(float Cantidad)
    {
        VidaJugador -= Cantidad;
        Debug.Log($"Vida de Shushu: {VidaJugador}");
        BarraDeVida.ActualizarBarra(VidaJugador, VidaMaximaJugador);
    }
   
}
