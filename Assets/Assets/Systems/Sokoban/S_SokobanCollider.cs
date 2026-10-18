using Unity.VisualScripting;
using UnityEngine;

public class S_SokobanCollider : MonoBehaviour
{
    [SerializeField] private S_SokobanManager.Dir colDir;
    [SerializeField] private Collider2D col;
    [SerializeField] private GameObject player;
    private S_PlayerSokobanController controller;
    

    private void Start()
    {
        controller = player.GetComponent<S_PlayerSokobanController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<S_SokobanBlock>())
        {
            if (collision.gameObject.GetComponent<S_SokobanBlock>())
            {
                //controller.SetDirPush(colDir);
                player.GetComponent<S_PlayerSokobanController>().SetBlockOnList(collision.gameObject, colDir);
                collision.gameObject.GetComponent<S_SokobanBlock>().SetPushDirAnim(colDir);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<S_SokobanBlock>())
        {
           // controller.SetDirPush(colDir);
            player.GetComponent<S_PlayerSokobanController>().SetBlockOnList(collision.gameObject, colDir);
            collision.gameObject.GetComponent<S_SokobanBlock>().SetPushDirAnim(colDir);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //controller.SetDirPush(S_SokobanManager.Dir.None);
        if (collision.gameObject.GetComponent<S_SokobanBlock>())
        {
            controller.SetDirPush(colDir);
            player.GetComponent<S_PlayerSokobanController>().SetBlockOnList(null, colDir);
            collision.gameObject.GetComponent<S_SokobanBlock>().SetPushDirAnim(colDir);
        }
    }

}
