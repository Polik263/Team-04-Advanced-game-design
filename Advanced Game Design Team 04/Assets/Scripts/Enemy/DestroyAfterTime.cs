using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float time;

    private void Update()
    {
        time -= 1 * Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
