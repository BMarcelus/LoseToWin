using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public GameObject model;
    private ShootingController pewpew;
    private PlayerController brain;

    void Start() {
      pewpew = GetComponentInChildren<ShootingController>();
      brain = GetComponent<PlayerController>();
    }

    public void SetModel(GameObject newModel) {
      GameObject instantiated = Instantiate(newModel, model.transform);
      instantiated.transform.parent = model.transform.parent;
      Destroy(model);
      Animator animator = instantiated.GetComponent<Animator>();
      pewpew.animator = animator;
      brain.animator = animator;
      model = instantiated;
    }
}
