using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<PlayerMovement>()) return;

        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
        Destroy(gameObject);
    }

    void Update() => transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
}
