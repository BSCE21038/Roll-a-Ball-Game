using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float boostAmount = 20f;
    public float boostDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ApplyBoost(other));
            gameObject.SetActive(false);
        }
    }

    IEnumerator ApplyBoost(Collider player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            float originalSpeed = pm.speed;
            pm.speed += boostAmount;
            yield return new WaitForSeconds(boostDuration);
            pm.speed = originalSpeed;
        }
    }
}
