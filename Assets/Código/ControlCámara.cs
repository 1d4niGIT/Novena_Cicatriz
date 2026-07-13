using UnityEngine;
public class ControlCámara : MonoBehaviour
{
    public GameObject Enfocado;
    public float VelocidadCamara = 12f;

    public Vector2 LimiteMin;
    public Vector2 LimiteMax;
    private Camera Camara;

    private void Start()
    {
        Camara = GetComponent<Camera>();

    }
    void Update()
    {
        Seguimiento();
    }

    public void Seguimiento()
    {
        Vector3 Dir = (Enfocado.transform.position - transform.position).normalized;
        Dir.z = 0;

        Vector3 NuevaPos = transform.position + Dir * VelocidadCamara * Time.deltaTime;

        // Calculamos la mitad del alto y ancho visibles de la cámara
        float AlturaCamara = Camara.orthographicSize;
        float AnchoCamara = AlturaCamara * Camara.aspect;

        // Recortamos la posición para que la cámara no muestre más allá del límite
        NuevaPos.x = Mathf.Clamp(NuevaPos.x, LimiteMin.x + AnchoCamara, LimiteMax.x - AnchoCamara);
        NuevaPos.y = Mathf.Clamp(NuevaPos.y, LimiteMin.y + AlturaCamara, LimiteMax.y - AlturaCamara);

        transform.position = NuevaPos;
    }
}
