using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimiteScroller : MonoBehaviour
{
    public ScrollRect scroller;
    public float limitOfScroll;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TryGetComponent<RectTransform>(out RectTransform _recttransform))
        {
            if (transform.childCount > 10)
            {
                scroller.vertical = true;
            }
            if (transform.childCount <= 10)
            {
                scroller.vertical = false;
            }

            if (scroller.vertical)
            {
                var pos = _recttransform.localPosition;

                if (pos.y < 0)
                {
                    pos.y = 0;
                }

                if (pos.y > limitOfScroll)
                {
                    pos.y = limitOfScroll;
                }

                _recttransform.localPosition = pos;
            }
        }
    }
}
