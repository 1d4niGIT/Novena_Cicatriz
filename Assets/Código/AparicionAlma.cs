using UnityEngine;

public class AparicionAlma : MonoBehaviour
{
    public GameObject AlmaPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Aparicion()
    {
        GameObject Alma = Instantiate(AlmaPrefab, transform.position, Quaternion.identity);
    }
}
