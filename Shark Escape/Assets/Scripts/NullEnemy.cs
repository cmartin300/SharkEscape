using UnityEngine;

public class NullEnemy : MonoBehaviour
{
    private float deathTimer = 6f;

    private void Start()
    {
        Destroy(this.gameObject, deathTimer);
    }
}
