using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Audio;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    GameObject checkPointSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagHelper.PLAYER_TAG))
        {
            AudioManager.Instance.PlaySoundOnPool(checkPointSound.name, transform.position, Quaternion.identity);
            //GameManager.Instance.Save();
        }
    }
}
