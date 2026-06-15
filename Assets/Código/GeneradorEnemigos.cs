using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject EnemigoPrefab;
    public float GeneradorTiempo = 0.5f;
    public float Rango = 0.5f;
    public int MaximodeGeneraciones = 10;


    void Start()
    {
        int i = 0;
        while (i  < MaximodeGeneraciones)
        {
            GeneradorEnemigo();
            i++;
        }
    }
    void Update()
    {
        
    }
    public void MecanicaTiempo()
    {
        GeneradorTiempo -= Time.deltaTime;
        if (GeneradorTiempo < 0)
        {
            GeneradorEnemigo();
            GeneradorTiempo = 0.5f;
        }
    }
    public void GeneradorEnemigo()
    {
        Vector3 DirAleatorio = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        Vector3 LargoTotalDireccion = DirAleatorio * Random.Range(0f, Rango);
        GameObject enemigo = Instantiate(EnemigoPrefab, transform.position, Quaternion.identity);
        enemigo.transform.position += LargoTotalDireccion;
    
        //->A
        // enemy.transform.position = fullLenghtDir;//->B

    }
}
