using UnityEngine;
public class ControlCámara : MonoBehaviour
{
    public GameObject Enfocado;
    public float VelocidadCamara = 12f;

    void Update()
    {
        Seguimiento();
    }

    public void Seguimiento()
    {
        Vector3 Dir = (Enfocado.transform.position - transform.position).normalized;
        Dir.z = 0;
        transform.position += Dir * VelocidadCamara * Time.deltaTime;
    }
}
