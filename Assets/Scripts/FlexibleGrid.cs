using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FlexibleGrid : GridLayoutGroup
{
    void Update()
    {
        Vector3[] corners = new Vector3[4];
        GetComponent<RectTransform>().GetLocalCorners(corners);
        Vector3 corner = corners.FirstOrDefault((corn) => corn.x != 0);

        if (corner != null)
        {
            float width = corner.x;

            float cell = (width / constraintCount) - ((width / constraintCount) / 3);

            cellSize = new Vector2(cell, cell);
            spacing = new Vector2(cell / 3, cell / 3);
        }

    }
}
