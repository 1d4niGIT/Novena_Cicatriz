using UnityEngine;

public class Alma : MonoBehaviour
{
    public GameObject ObjetivoDemonio;
    public float VelocidadAlma = 0.5f;
    public float RadioDeteccion = 3f;

    public float TiempoCambioDireccion = 0.5f; // Cada cuánto cambia de lado
    public float FuerzaSerpenteo = 1.5f;
    private float Temporizador;
    private float DireccionLateral = 1f;
    public enum AlmaEnum {None, Idle, Perseguir}
    public AlmaEnum estado = AlmaEnum.Idle;
    void Start()
    {
        ObjetivoDemonio = GameObject.FindWithTag("CabezaDemonio");
    }

    void FixedUpdate()
    {
        EstadoAlma();
    }
    public void EstadoAlma()
    {
        Vector3 DemonioPos = ObjetivoDemonio.transform.position;
        Vector3 MiPos = transform.position;
        Vector3 Dir = (DemonioPos - MiPos).normalized;

        switch (estado)
        {
            case AlmaEnum.None:
                break;

            case AlmaEnum.Idle:
                {
                    if (Vector3.Distance(DemonioPos, MiPos) < RadioDeteccion)
                        estado = AlmaEnum.Perseguir;
                }
                break;

            case AlmaEnum.Perseguir:
                {
                    // Cambiamos de lado cada cierto tiempo
                    Temporizador += Time.deltaTime;

                    if (Temporizador >= TiempoCambioDireccion)
                    {
                        DireccionLateral *= -1f; // invierte el lado
                        Temporizador = 0f;
                    }

                    Vector3 Perpendicular = new Vector3(-Dir.y, Dir.x, 0f);
                    Vector3 MovimientoFinal = (Dir * VelocidadAlma) + (Perpendicular * DireccionLateral * FuerzaSerpenteo);

                    transform.position += MovimientoFinal * Time.deltaTime;

                    if (Vector3.Distance(DemonioPos, MiPos) > RadioDeteccion)
                        estado = AlmaEnum.Idle;
                }
                break;

            default:
                break;
        }
    }
}
