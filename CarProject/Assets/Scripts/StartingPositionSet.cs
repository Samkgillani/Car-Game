using UnityEngine;

public class StartingPositionSet : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.startingPosition = transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(0, 255, 47, 180);
        }
    }
}
