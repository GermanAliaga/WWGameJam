using UnityEngine;

public class S_BadSpiritTrigger : MonoBehaviour
{
    [SerializeField] private S_BadSpiritBehaviour parent;
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
        if (!parent.GetPlayer())
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                parent.SetPlayer(collision.gameObject);
                parent.SetFollowing(true);
                parent.SetTimeStamp(Time.time + parent.GetFollowTime());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (parent.GetPlayer())
        {
                parent.SetFollowing(true);
        }
    }
}
