using UnityEngine;

public class S_BadSpiritHitBox : MonoBehaviour
{
    [SerializeField] S_BadSpiritBehaviour parent;
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
        if (parent.GetPlayer())
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                parent.SetAnimator("Death", true);
                // set corruption
            }
        }
    }
}
