using UnityEngine;

public class DropItemOnDeath : MonoBehaviour
{
    GameObject dropHolder;
    public GameObject expDrop;


    private void Start()
    {
        dropHolder = GameObject.FindGameObjectWithTag("DropHolder");
    }

    public void DropItem()
    {
        Instantiate(expDrop, transform.position, Quaternion.identity, dropHolder.transform);
    }
}
