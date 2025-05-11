using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    public GameObject enemyToActivate;

    public void ActivateEnemy()
    {
        enemyToActivate.SetActive(true);
    }
}
