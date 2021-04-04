using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTouch : MonoBehaviour
{
    public GameObject circle;
    public List<TouchLocation> touches = new List<TouchLocation>();
    // Update is called once per frame
    void Update()
    {
        int cnt = 0;
        while (cnt < Input.touchCount)
        {
            Touch t = Input.GetTouch(cnt);
            print(cnt);
            if (t.phase == TouchPhase.Began)
            {
                touches.Add(new TouchLocation(t.fingerId, CreateCircle(t)));
            } else if (t.phase == TouchPhase.Ended)
            {
                TouchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                Destroy(thisTouch.circle);
                touches.RemoveAt(touches.IndexOf(thisTouch));
            } else if (t.phase == TouchPhase.Moved)
            {
                Debug.Log("Touch Moved");
                TouchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                thisTouch.circle.transform.position = getTouchPosition(t.position);
            }
            cnt ++;
        }
    }

    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 0));
    }

    GameObject CreateCircle(Touch t)
    {
        GameObject c = Instantiate(circle) as GameObject;
        c.name = "Touch" + t.fingerId;
        c.transform.position = getTouchPosition(t.position);
        return c;
    }
}
