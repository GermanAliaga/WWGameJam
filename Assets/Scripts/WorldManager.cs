using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private float rotation = 10;

    private bool ayudar;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ayudar = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CorruptionUp()
    {
        if(ayudar)
        {
            if(transform.rotation.z > -90 && ayudar == true)
            {
                transform.localEulerAngles = new Vector3(0, 0, transform.rotation.z - rotation);
            }
        }
    }

    public void CorruptionDown()
    {
        if(transform.rotation.z < 90 && ayudar == true)
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.rotation.z + rotation);
        }
    }
}
