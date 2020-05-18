using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Transform moveTransformLeft;
    [SerializeField]
    Transform moveTransformRight;
    [SerializeField]
    float movementSpeed;

    Vector3 nextPos;

    void Awake()
    {
        nextPos = moveTransformLeft.position;
    }

    void FixedUpdate()
    {
        if (transform.position == moveTransformLeft.position)
        {
            nextPos = moveTransformRight.position;
        }

        if (transform.position == moveTransformRight.position)
        {
            nextPos = moveTransformLeft.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, movementSpeed * TimeManager.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(TagHelper.PLAYER_TAG))
        {
            PlayerController.Instance.PlayerMovementController.IsOnMovingPlatform = true;
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        PlayerController.Instance.PlayerMovementController.IsOnMovingPlatform = false;
        other.transform.SetParent(ObjectPooler.Instance.ObjectContainer.transform);
    }
}
