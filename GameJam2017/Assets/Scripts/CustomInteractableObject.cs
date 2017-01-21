using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CustomInteractableObject : VRTK_InteractableObject
{

    private GameObject BlockSpace = null; //The block space where this sound block is fitted


    private bool InBlock = false;
    private Rigidbody RB;
    private BoxCollider Coll;

    protected override void Awake()
    {
        
        RB = GetComponent<Rigidbody>();
        Coll = GetComponent<BoxCollider>();
    }

    public override void Grabbed(GameObject currentGrabbingObject)
    {
        base.Grabbed(currentGrabbingObject);

        Coll.isTrigger = true;
        RB.isKinematic = false;


    }

    public override void Ungrabbed(GameObject currentGrabbingObject)
    {
        base.Ungrabbed(currentGrabbingObject);

        if (InBlock)
        {
            RB.isKinematic = true;
            transform.position = BlockSpace.transform.position;
            transform.localRotation = BlockSpace.transform.localRotation;

        }
        else
        {
            RB.isKinematic = false;
        }
        Coll.isTrigger = false;


    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BlockSpace")) //The Block Spaces
        {
            BlockSpace = other.gameObject;
            InBlock = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BlockSpace")) //The block Spaces
        {
            if (other.gameObject == BlockSpace)
            {
                BlockSpace = null;
                InBlock = false;
                //RB.isKinematic = false;
            }
        }
    }
}
