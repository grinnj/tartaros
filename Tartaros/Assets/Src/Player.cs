using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Player : Character
{
    protected override void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //
    // Members
    //

    private static Player Instance;

    //
    // Construction
    //

    Player()
    {
        Instance = this;
    }

    //
    // Unity events
    //

    public static Player GetPlayer()
    {
        return Instance;
    }

    Vector3 GetPosition()
    {
        return new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y,
            gameObject.transform.position.z);
    }

    void Update()
    {
        Vector3 TargetDirection = new Vector3();

        if (Input.GetKey(KeyCode.A))
            TargetDirection += new Vector3(-0.05f, 0f, 0f);

        if (Input.GetKey(KeyCode.D))
            TargetDirection += new Vector3(0.05f, 0f, 0f);

        if (Input.GetKey(KeyCode.S))
            TargetDirection += new Vector3(0f, -0.05f, 0f);

        if (Input.GetKey(KeyCode.W))
            TargetDirection += new Vector3(0f, 0.05f, 0f);

        MoveToDirection(TargetDirection);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    }

    //
    // Interface
    //

    void MoveToDirection(Vector3 _Dir)
    {
        if (Level.GetLevel().CanPass(_Dir))
            gameObject.transform.Translate(_Dir);
    }
}
