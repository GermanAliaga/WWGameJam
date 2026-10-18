using Unity.VisualScripting;
using UnityEngine;

public class S_SokobanManager : MonoBehaviour
{
    public enum Dir { Right, Left, Up, Down, None }

    [SerializeField] int PointsGoal;
    [SerializeField] int currentPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
