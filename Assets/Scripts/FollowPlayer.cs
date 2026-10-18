using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject referencia;

    public bool seguirX;
    public bool seguirY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(seguirX)
        {
            transform.position = new Vector3(referencia.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
