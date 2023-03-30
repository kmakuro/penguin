using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestroyer : MonoBehaviour
{
    public float lifetime = 5.0f;
    private float timeAlive = 0.0f;
    public bool destroyChildrenOnDeath = true;
    public static bool quitting = false;
    // Start is called before the first frame update
    void Start()
    {
        quitting = true;
        DestroyImmediate(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAlive > lifetime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timeAlive += Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        if (destroyChildrenOnDeath && !quitting && Application.isPlaying)
        {
            int childcount = transform.childCount;
            for (int i = childcount - 1; i >= 0; i--)
            {
                GameObject childObject = transform.GetChild(i).gameObject;
                if (childObject != null)
                {
                    DestroyImmediate(childObject);
                }
            }
        }
    }
}
