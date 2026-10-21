using UnityEditor.Tilemaps;
using UnityEngine;

public class S_BadSpiritBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private float corruptionValue;
    [SerializeField] private float spiritSpeed;
    [SerializeField] public bool following;
    [SerializeField] Animator animator;

    [SerializeField] public float followTime;
    public float timeStamp;

    private S_BadSpiritSpawner spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        following = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (following)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, spiritSpeed);
            if (timeStamp <= Time.time)
            {
                following = false;
                animator.SetBool("Death", true);
            }
        }
        
    }

    public void OnDeathAnimStart()
    {

    }
    public void OnDeathAnimEnd()
    {
        Destroy(gameObject);
    }

    private void StartFollowPlayer()
    {

    }

    public void SetSpawner(S_BadSpiritSpawner spiritSpawner)
    {
        spawner = spiritSpawner;
    }
    private void OnDestroy()
    {
        if (spawner)
        {
            spawner.SubstractCurrentEnemies();
        }
    }

    public void ApplyCorruption()
    {
        spawner.worldManager.AumentoCorruption(true);
    }
    public GameObject GetPlayer() { return player; }
    public void SetPlayer(GameObject player_) {  player = player_; }

    public void SetFollowing(bool value) { following = value; }
    public float GetFollowTime() { return followTime; }
    public void SetTimeStamp(float value) { timeStamp = value; }
    public void SetAnimator(string state, bool value) { animator.SetBool(state, value); }
}
