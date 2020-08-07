﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerImun player;

    private NPC currentTarget;
	
	// Update is called once per frame
	void Update ()
    {
        ClickTarget();
	}

    private void ClickTarget()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) //if we click the left mouse button
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity,512);

            if (hit.collider != null)
            {
                if (currentTarget != null)
                {
                    currentTarget.DeSelect();
                }

                currentTarget = hit.collider.GetComponent<NPC>();

                player.MyTarget = currentTarget.Select();

                UIManager.MyInstance.ShowTargetFrame(currentTarget);
            }
            else
            {
                UIManager.MyInstance.HideTargetFrame();

                if (currentTarget != null)
                {
                    currentTarget.DeSelect();
                }

                currentTarget = null;
                player.MyTarget = null;
            }
        }
    }
}