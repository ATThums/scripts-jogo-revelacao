using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteration : MonoBehaviour
{

    public float rayDistance = 2f;
    public float rotateSpeed = 200;

    public AudioClip pickUpSound;
    public Transform objectViewer;

    public UnityEvent OnView;
    public UnityEvent OnFinishView;

    private Camera myCam;

    private bool isViewing;
    private bool canFinish;

    private Interactables currentInteratables;
    private Item currentItem;
    private Vector3 originPosition;
    private Quaternion originRotation;

    private AudioPlayer audioPlayer;
    private PlayerInventory inventory;
    [SerializeField]
    private GameObject flashLight;
    public AudioSource flashLigthSound; 

    public Animator anim;

    public GameObject lanterna;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioPlayer>();
        inventory = GetComponent<PlayerInventory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractables();

        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLight.SetActive(!flashLight.activeInHierarchy);
            flashLigthSound.Play();
        }
    }

    void CheckInteractables()
    {
        if (isViewing)
        {
            if (currentInteratables.item.grabbable && Input.GetMouseButton(0))
            {
                RotateObject();
            }
            if(canFinish && Input.GetMouseButtonDown(1))
            {
                FinishView();
                //UIManager.instance.SetCaptions("");
            }
            return;
        }
        RaycastHit hit;
        Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));

        if (Physics.Raycast(rayOrigin, myCam.transform.forward, out hit, rayDistance))
        {
            Interactables interactable = hit.collider.GetComponent<Interactables>();
            if (interactable != null)
            {                
                UIManager.instance.SetHandCursor(true);
                if (Input.GetMouseButtonDown(0))
                {
                    if (interactable.isMoving)
                    {
                        return;
                    }
                    currentInteratables = interactable;

                    currentInteratables.OnInteract.Invoke();

                    if (currentInteratables.item != null)
                    {
                        OnView.Invoke();

                        UIManager.instance.SetHandCursor(false);

                        isViewing = true;

                        bool hasPreviusItem = false;                                                

                        for(int i = 0; i < currentInteratables.previusItem.Length; i++)
                        {
                            if (inventory.itens.Contains(currentInteratables.previusItem[i].requiredItem))
                            {
                                Interact(currentInteratables.previusItem[i].interactionItem);
                                currentInteratables.previusItem[i].OnInteract.Invoke();
                                hasPreviusItem = true;
                                break;
                            }
                        }

                        if (hasPreviusItem)
                        {
                            return;
                        }

                        Interact(currentInteratables.item);

                        if (currentInteratables.item.grabbable)
                        {
                            originPosition = currentInteratables.transform.position;
                            originRotation = currentInteratables.transform.rotation;
                            StartCoroutine(MovingObject(currentInteratables, objectViewer.position));
                        }                        
                    }                    
                }
            }
            else
            {
                UIManager.instance.SetHandCursor(false);
            }
        }
        else
        {
            UIManager.instance.SetHandCursor(false);
        }
    }

    void Interact(Item item)
    {
        currentItem = item;

        if(item.image != null)
        {
            UIManager.instance.SetImage(item.image);
        }
        //audioPlayer.PlayAudio(item.audioClip);
        if (!item.message)
        {
            UIManager.instance.SetCaptions(item.text);
        }
        if (item.audioClip != null)
        {
            Invoke("CanFinish", item.audioClip.length + 0.5f);
        }
        else
        {
            Invoke("CanFinish", 0.1f);
        }
    }
    void CanFinish()
    {
        canFinish = true;

        if(currentItem.image == null && !currentItem.grabbable)
        {
            FinishView();
        }
        else
        {
            UIManager.instance.SetBackImage(true);
        }
        if (!currentItem.message)
        {
            UIManager.instance.SetCaptions("");
        }
    }

    void FinishView()
    {
        canFinish = false;
        isViewing = false;
        UIManager.instance.SetBackImage(false);

        if (currentItem.inventoryItem)
        {
            inventory.AddItem(currentItem);
            audioPlayer.PlayAudio(pickUpSound);
            currentInteratables.CollecItem.Invoke();
        }

        if (currentItem.grabbable)
        {
            currentInteratables.transform.rotation = originRotation;
            StartCoroutine(MovingObject(currentInteratables, originPosition));
        }
        OnFinishView.Invoke();
    }
    IEnumerator MovingObject(Interactables obj, Vector3 position)
    {
        obj.isMoving = true;
        float timer = 0;
        while (timer < 1)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, position, Time.deltaTime * 5);
            timer += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = position;
        obj.isMoving = false;
    }

    void RotateObject()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        currentInteratables.transform.Rotate(myCam.transform.right, Mathf.Deg2Rad * y * rotateSpeed, Space.World);
        currentInteratables.transform.Rotate(myCam.transform.up, -Mathf.Deg2Rad * x * rotateSpeed, Space.World);
    }
}
