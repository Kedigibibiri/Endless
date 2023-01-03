using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnTriggerExit(Collider other) => Destroy(this.gameObject.transform.parent.gameObject);
}
