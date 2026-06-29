using UnityEngine;

public class MovimientoAlma : MonoBehaviour
{
    public GameObject ObjetivoDemonio;
    public float VelocidadAlma = 0.5f;
    public float RadioDeteccion = 3f;
    public enum AlmaEnum {None, Idle, Perseguir}
    public AlmaEnum estado = AlmaEnum.Idle;
    void Start()
    {
        ObjetivoDemonio = GameObject.FindWithTag("CabezaDemonio");
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
                    transform.position += Dir* VelocidadAlma * Time.deltaTime;
                    
                    if (Vector3.Distance(DemonioPos, MiPos) > RadioDeteccion)
                        estado = AlmaEnum.Idle;
                }
                break;

            default:
                break;
        }
    }
}
