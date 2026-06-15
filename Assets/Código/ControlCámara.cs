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
        Vector3 dir = (Enfocado.transform.position - transform.position).normalized;
        dir.z = 0;
        transform.position += dir * VelocidadCamara * Time.deltaTime;
    }
}
