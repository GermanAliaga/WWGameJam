using UnityEngine;

public class S_BlockCollider : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    public bool willOverlap = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Wall"))
        {
            
            willOverlap = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Wall"))
        {

            willOverlap = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Wall"))
        {

            willOverlap = false;
        }
    }
}
