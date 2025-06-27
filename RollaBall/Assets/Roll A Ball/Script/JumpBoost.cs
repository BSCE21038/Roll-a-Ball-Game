using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float boostForce = 1200f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * boostForce);
            }
            gameObject.SetActive(false);
        }
    }
}
