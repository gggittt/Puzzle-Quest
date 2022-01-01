using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dot))]
public class DotMove : MonoBehaviour
{
    private bool _isMoving;
    [SerializeField] private float _moveTime = .4f;

    public void Move(Vector3 destination)
    {
        if (_isMoving)
            return;
        StartCoroutine(MoveRoutine(destination, _moveTime));
    }

    private IEnumerator MoveRoutine(Vector3 destination, float timeToMove)
    {
        Vector3 startPosition = transform.position;

        float elapsedTime = 0f;

        _isMoving = true;

        while (true)
        {
            bool isReachTarget = Vector3.Distance(transform.position, destination) < 0.01f;

            if (isReachTarget)
            {
                //m_board.PlaceGamePiece(this, (int) destination.x, (int) destination.y);

                break;
            }

            // track the total running time
            elapsedTime += Time.deltaTime;

            // calculate the Lerp value
            float t = Mathf.Clamp(elapsedTime / timeToMove, 0f, 1f);


            transform.position = Vector3.Lerp(startPosition, destination, t);

            // wait until next frame
            yield return null;
        }

        _isMoving = false;
    }

}


