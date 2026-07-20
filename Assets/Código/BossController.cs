using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform player;        
    public float appearRange = 5f;  
    public Animator animator;       
    public bool hasAppeared = false;

    void Update()
    {
        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia <= appearRange)
        {
            if (hasAppeared == false)
            {
                animator.SetBool("appear", true);
                hasAppeared = true;
            }
        }
    }
}