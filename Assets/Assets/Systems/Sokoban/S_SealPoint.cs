using UnityEngine;

public class S_SealPoint : MonoBehaviour
{
    [SerializeField] private S_SokobanManager sokobanManager;
    [SerializeField] private BoxCollider2D col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.CompareTag("Block"))
            {
                sokobanManager.AddPoints();
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.CompareTag("Block"))
            {
                sokobanManager.SubPoints();
            }
        }
    }
}
