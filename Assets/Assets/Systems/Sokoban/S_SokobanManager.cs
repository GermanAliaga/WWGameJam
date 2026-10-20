using Unity.VisualScripting;
using UnityEngine;

public class S_SokobanManager : MonoBehaviour
{
    public enum Dir { Right, Left, Up, Down, None }

    [SerializeField] int PointsGoal;
    [SerializeField] int currentPoints;

    [SerializeField] float soulCorruption;

    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnManager;
    [SerializeField] GameObject UI;

    [SerializeField] float startTime;
    [SerializeField] float timeStamp;

    bool start = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager");
        UI = GameObject.FindGameObjectWithTag("UI");
        timeStamp = startTime + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStamp <= Time.time)
        {
            if (!start)
            {
                UI.SetActive(false);
                player.GetComponent<S_PlayerSokobanController>().SetStart();
                spawnManager.GetComponent<S_BadSpiritSpawner>().SetStart();
                start = true;
            }
        }
    }

    public void AddPoints()
    {
        currentPoints++;
        CheckGoal();
    }

    public void SubPoints()
    {
        currentPoints--;
    }

    private void CheckGoal()
    {
        if(currentPoints == PointsGoal)
        {
            //Finish game
        }
    }
}
