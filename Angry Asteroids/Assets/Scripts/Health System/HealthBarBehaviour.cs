using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour
{
    public Transform HealthBarFill;
    private Vector3 _initialOffset;

    public void SetHealthBarFillValue(float healthFillValue)
    {
        HealthBarFill.localScale = new Vector3(healthFillValue, 1,1);
    }

    public void Start()
    {
        _initialOffset = transform.localPosition;
    }
        public void Update()
    {
        var parentObject = gameObject.transform.parent;
        var parentEulerAngles = parentObject.rotation.eulerAngles;
        transform.position = parentObject.position + _initialOffset;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
