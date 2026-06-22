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
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 Dir = (MousePos - transform.position);
        Dir.z = 0;
        Dir.Normalize();
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Proyectil = Instantiate(ProyectilPrefab, transform.position, Quaternion.identity);
            Proyectil.transform.up = Dir;
        }
    }
}
