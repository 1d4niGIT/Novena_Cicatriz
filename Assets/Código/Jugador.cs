using UnityEngine;
public class Jugador : MonoBehaviour
{
    public float VelocidadJugador = 2f;
    public float VidaJugador = 100f;

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
}
