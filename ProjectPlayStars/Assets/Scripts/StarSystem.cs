using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : MonoBehaviour
{
	public List<Vector2> Stars;

	[ContextMenu("ReConfigureStars")]
    public void TransformToVector()
    {
        Stars.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            float _PosX = Mathf.Round(childTransform.position.x * 1000f) / 1000f;
            float _PosY = Mathf.Round(childTransform.position.y * 1000f) / 1000f;

            Vector2 childPosition = new Vector2(_PosX, _PosY);
            Stars.Add(childPosition);
        }
    }
}
