using System.Collections;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    FieldOfView fov;

    Transform _player;
    public Transform Player
    {
        get => _player;
        set
        {
            if (_player != value)
            {
                _player = value;
                OnPlayerChanged();
            }
        }
    }

    private void Start()
    {
        fov = GetComponent<FieldOfView>();
    }

    void Update()
    {
        Player = fov.visibleTargets.Count > 0 ? fov.visibleTargets[0] : null;
        HandleRotation();
    }

    public void HandleRotation()
    {
        if (_player != null)
        {
            Vector3 direction = _player.transform.position - transform.position;
            direction.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 / Time.deltaTime);
        }
    }

    void OnPlayerChanged()
    {
        Debug.Log("Player target changed!");
        transform.rotation = transform.parent.rotation;
        // You can trigger sound, alert state, animation, etc. here
    }
}
