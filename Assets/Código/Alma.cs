using UnityEngine;

public class Alma : MonoBehaviour
{
    public GameObject ObjetivoDemonio;
    public float VelocidadAlma = 0.5f;
    public float RadioDeteccion = 3f;

    public float FrecuenciaSerpenteo = 5f;
    public float AmplitudSerpenteo = 1.5f;
    private float offsetAleatorio;
    public enum AlmaEnum {None, Idle, Perseguir}
    public AlmaEnum estado = AlmaEnum.Idle;
    void Start()
    {
        ObjetivoDemonio = GameObject.FindWithTag("CabezaDemonio");
        offsetAleatorio = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
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
                    Vector3 perpendicular = new Vector3(-Dir.y, Dir.x, 0f);
                    float serpenteo = Mathf.Sin((Time.time + offsetAleatorio) * FrecuenciaSerpenteo) * AmplitudSerpenteo;
                    Vector3 movimientoFinal = (Dir * VelocidadAlma) + (perpendicular * serpenteo);
                    transform.position += movimientoFinal * Time.deltaTime;
                    //transform.position += Dir * VelocidadAlma * Time.deltaTime;

                    if (Vector3.Distance(DemonioPos, MiPos) > RadioDeteccion)
                        estado = AlmaEnum.Idle;
                }
                break;

            default:
                break;
        }
    }
}
