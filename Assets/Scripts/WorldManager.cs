using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private static float soulCorruption;
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
            soulCorruption = soulCorruption + 20;
        }
        else
        {
            soulCorruption = soulCorruption + 2;
        }            
    }

    public void CorruptionDown()
    {
        soulCorruption = soulCorruption - 20;
    }
}
