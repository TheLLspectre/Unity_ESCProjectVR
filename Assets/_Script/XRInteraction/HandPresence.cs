using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[AddComponentMenu("TheRed/XRInteraction/HandPresence")]
public class HandPresence : MonoBehaviour
{
    //public
    #region public statement
    public GameObject SpawnedRayCursor { get { return spawnedRayCursor; } set { spawnedRayCursor = value; } }
    public GameObject SpawnedTeleportRayCursor { get { return spawnedTeleportRayCursor; } set { spawnedTeleportRayCursor = value; } }

    public InputDeviceCharacteristics controllerCharacteristics; //Allow to select the setting of the device

    public List<GameObject> controllerPrefabs; //All the model in a prefab for each controllers in VR
    public GameObject handModelPrefab; // A model to override the controller
    public GameObject RayCursor; //The pointer Ray to spawn according to the side of the hand
    public GameObject TeleportRayCursor; //The pointer teleport ray to spawn accordint to the side of the hand

    public bool showController = false; //Allow to show or not hand controller on the controller
    public bool showHandModel = false; // Allow to show or not the hand model
    #endregion

    //private
    #region private statement
    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice targetDevice; // The device concerned by the settings

    private GameObject spawnedController = null; // The model of the controller to spawn
    private GameObject spawnedHandModel = null; // The model of the hand to spawn
    private GameObject spawnedRayCursor = null;
    private GameObject spawnedTeleportRayCursor = null;

    private Animator handAnimator;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            if (!showController && !showHandModel)
                showController = true;
            // If the showController is true spawned the controller else spawn hand models
            if (showController)
                spawnedController.SetActive(true);
            else
                spawnedController.SetActive(false);

            if (showHandModel && handModelPrefab)
            {
                spawnedHandModel.SetActive(true);
                UpdateHandAnimation();
            }
            else
                spawnedHandModel.SetActive(false);
        }
    }

    void TryInitialize()
    {
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices); //get all XR devices found with the settings selected
        foreach (var item in devices)
        {
            Debug.Log(item.name + " " + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0]; // By default the target device is the first one founded
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name); // The prefab to instantiate have to be find in the list of controller prefabs by the characteristics selected
            if (prefab)
                spawnedController = Instantiate(prefab, transform); // Spawned it
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform); // else if the controller to spawned is empty by default take the first one in the list
            }

            //If the hand model parameter is not empty spawned it
            if (handModelPrefab)
            {
                spawnedHandModel = Instantiate(handModelPrefab, transform);
                if (!handAnimator)
                {
                    handAnimator = spawnedHandModel.gameObject.GetComponent<Animator>();
                    if (!handAnimator)
                        handAnimator = spawnedHandModel.gameObject.GetComponentInChildren<Animator>();
                }
            }
        }
        RayInitialize();
    }

    private void RayInitialize()
    {
        if (spawnedController || spawnedHandModel)
        {
            bool rayCursor = false;
            bool teleportRayCursor = false;
            if (transform.childCount > 0)
            {
                foreach (Transform t in transform)
                {
                    if (t.tag.Equals("XR/Hand/RayCursor"))
                    {
                        spawnedRayCursor = t.gameObject;
                        rayCursor = true;
                    }
                    
                    if (t.tag.Equals("XR/Hand/TeleportRayCursor"))
                    {
                        spawnedTeleportRayCursor = t.gameObject;
                        teleportRayCursor = true;
                    }
                }

                if (RayCursor && !rayCursor)
                {
                    spawnedRayCursor = Instantiate(RayCursor, transform);
                    rayCursor = true;
                }
                if (TeleportRayCursor && !teleportRayCursor)
                {
                    spawnedTeleportRayCursor = Instantiate(TeleportRayCursor, transform);
                    teleportRayCursor = true;
                }
            }
            else
            {
                if (RayCursor && !rayCursor)
                {
                    spawnedRayCursor = Instantiate(RayCursor, transform);
                    rayCursor = true;
                }
                if (TeleportRayCursor && !teleportRayCursor)
                {
                    spawnedTeleportRayCursor = Instantiate(TeleportRayCursor, transform);
                    teleportRayCursor = true;
                }
            }

            spawnedRayCursor.SetActive(false);
            spawnedTeleportRayCursor.SetActive(false);
        }
    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Flex", triggerValue);
            //Debug.Log(handAnimator.GetFloat("Flex") + "Trigger " + triggerValue);
        }
        else
            handAnimator.SetFloat("Flex", 0);

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Pinch", gripValue);
            //Debug.Log(handAnimator.GetFloat("Flex") + "Trigger " + triggerValue);
        }
        else
            handAnimator.SetFloat("Pinch", 0);
    }

    #region methods action
    public void DesactivateTeleport()
    {
        spawnedTeleportRayCursor.SetActive(false);
        Debug.LogError("DesactivateTeleport");
    }
    #endregion
}