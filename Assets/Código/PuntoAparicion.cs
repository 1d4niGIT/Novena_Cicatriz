using UnityEngine;

public class PuntoAparicion : MonoBehaviour
{
    public GameObject ProyectilPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        CreayApunta();
    }
    public void CreayApunta()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (mousePos - transform.position);
        dir.z = 0;
        dir.Normalize();
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Proyectil = Instantiate(ProyectilPrefab, transform.position, Quaternion.identity);
            Proyectil.transform.up = dir;
        }
    }
}
