using UnityEngine;

public class InstanciadorAtaqueMelee : MonoBehaviour
{
    public GameObject PrefabAtaqueMelee;
    public float DistanciaAtaque = 0.3f;
    private Jugador ComponenteJugador;

    void Start()
    {
        ComponenteJugador = GetComponentInParent<Jugador>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            InstanciarAtaque(ComponenteJugador.UltimaX, ComponenteJugador.UltimaY);
        }
    }

    private void InstanciarAtaque(float X, float Y)
    {
        Vector3 PosicionSpawn = ComponenteJugador.transform.position + new Vector3(X, Y, 0) * DistanciaAtaque;

        GameObject Ataque = Instantiate(PrefabAtaqueMelee, PosicionSpawn, Quaternion.identity);

        Animator AnimAtaque = Ataque.GetComponentInChildren<Animator>();
        AnimAtaque.SetFloat("X", X);
        AnimAtaque.SetFloat("Y", Y);
    }
}