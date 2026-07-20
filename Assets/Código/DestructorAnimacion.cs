using UnityEngine;

public class DestructorAnimacion : MonoBehaviour
{
    public void Destruir()
    {
        Destroy(transform.parent.gameObject);
    }
}
