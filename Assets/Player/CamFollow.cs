using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;
    [SerializeField] float lerpTime;


    void Start() => offset = transform.position - player.transform.position;
    void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, offset + player.transform.position, lerpTime * Time.deltaTime);
        transform.position = newPos;
    }
}
