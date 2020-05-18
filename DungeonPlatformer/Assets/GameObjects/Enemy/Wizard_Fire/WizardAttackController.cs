using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttackController : MonoBehaviour
{
    [SerializeField]
    GameObject fireball;
    [SerializeField]
    Transform projectTilePos;

    public void ShootFireball()
    {
        GameObject tmpObject = ObjectPooler.Instance.SpawnPoolObject(fireball.name, projectTilePos.position, transform.rotation);
        ObjectPooler.Instance.ReturnToPool(tmpObject.name, tmpObject, 5f);
    }
}
