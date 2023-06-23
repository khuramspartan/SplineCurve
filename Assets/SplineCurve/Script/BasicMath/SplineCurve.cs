using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineCurve : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private Transform pointD;

    [SerializeField] private Transform pointAB;
    [SerializeField] private Transform pointBC;
    [SerializeField] private Transform pointCD;

    [SerializeField] private Transform pointAC;
    [SerializeField] private Transform pointBCD;
    [SerializeField] private Transform pointABCD;



    private float interpolation;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        interpolation = (interpolation + Time.deltaTime) % 1f;

        /*     pointAB.position = Vector3.Lerp(pointA.position, pointB.position, interpolation);
             pointBC.position = Vector3.Lerp(pointB.position, pointC.position, interpolation);
             pointCD.position = Vector3.Lerp(pointC.position, pointD.position, interpolation);

             pointAC.position = Vector3.Lerp(pointA.position, pointBC.position, interpolation);
             pointBCD.position = Vector3.Lerp(pointB.position, pointCD.position, interpolation);
             pointABCD.position = Vector3.Lerp(pointA.position, pointBCD.position, interpolation);*/

        pointABCD.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position, interpolation);
    }

    private Vector3 QuaderaticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);
        return Vector3.Lerp(ab, bc, interpolation);
    }

    public Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 ab_bc = QuaderaticLerp(a, b, c, t);
        Vector3 bc_cd = QuaderaticLerp(b, c, d, t);

        return Vector3.Lerp(ab_bc, bc_cd, interpolation);
    }
}
