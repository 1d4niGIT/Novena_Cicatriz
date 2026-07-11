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

    public enum AlmaEnum {None, Idle, Perseguir, Liberar}
    public AlmaEnum estado = AlmaEnum.Idle;

    public float TiempoHastaLiberarse = 5f;
    public bool Liberarse = false;
    private bool ProcesoDeLiberacion = false;

    public float VelocidadSubida = 1.5f;   
    public float TiempoParaDesaparecer = 1.5f;

    public BarraVida BarraDemonio;
    void Start()
    {
        ObjetivoDemonio = GameObject.FindWithTag("CabezaDemonio");
    }

    void Update()
    {
        if(!Liberarse) 
        {
            TiempoParaLiberar();
        }
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
                    if (Vector3.Distance(DemonioPos, MiPos) < RadioDeteccion) { estado = AlmaEnum.Perseguir; }

                    if (Liberarse) { estado = AlmaEnum.Liberar; }
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

                    if (Vector3.Distance(DemonioPos, MiPos) > RadioDeteccion) { estado = AlmaEnum.Idle; }

                    if (Liberarse) { estado = AlmaEnum.Liberar; }

                }
                break;

            case AlmaEnum.Liberar:
                {

                    if (!ProcesoDeLiberacion)
                    {
                        ProcesoDeLiberacion = true;
                        Destroy(gameObject, TiempoParaDesaparecer);
                    }

                    transform.position += Vector3.up * VelocidadSubida * Time.deltaTime;

                }
                break;

            default:
                break;
        }
    }

    public void TiempoParaLiberar()
    {
        TiempoHastaLiberarse -= Time.deltaTime;
        if (TiempoHastaLiberarse < 0 )
        {
            Liberarse = true;
        }
          
    }

    private void OnTriggerEnter2D(Collider2D Colisionador)
    {
        if (Colisionador.CompareTag("CabezaDemonio"))
        {
            Jugador ComponenteJugador = GetComponent<Jugador>();
            ComponenteJugador.SaciedadActual += 2;
            BarraDemonio.ActualizarBarra(ComponenteJugador.SaciedadActual, ComponenteJugador.SaciedadMaxima);
            Destroy(gameObject);
        }
    }
}
