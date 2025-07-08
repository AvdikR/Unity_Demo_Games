using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float acceleration;
    public float maxSpeed;

    private int desiredLane = 1;
    public float laneDistance = 2;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce;
    public float Gravity = -20f;

    public Animator animator;
    private bool isSliding = false;

    public float interval = 0.5f; 
    public int scoreToAdd = 3;

    //private GameObject objectToAppear;
    private GameObject[] objectToAppear;
    private Rigidbody objectToAppearRigidbody;
    private Renderer[] renderers;
    private Dictionary<GameObject, bool> triggeredObjects = new Dictionary<GameObject, bool>();
    public float radius = 10f; 
    public LayerMask dangerPointLayer; 

    public Boost[] boost;
    static public bool Dash;

    public Image DashImage;
    public Image CoinMultiplierImage;
    public Image RecoveryImage;

    public GameObject DashEffect;
    public GameObject CoinMultiplierEffect;
    public GameObject RecoveryEffect;
    public GameObject DashEffect1;
    public GameObject CoinMultiplierEffect1;
    public GameObject RecoveryEffect1;
    public GameObject DashEffect2;
    public GameObject CoinMultiplierEffect2;
    public GameObject RecoveryEffect2;
    public GameObject DashEffect3;
    public GameObject CoinMultiplierEffect3;
    public GameObject RecoveryEffect3;
    public GameObject DashEffect4;
    public GameObject CoinMultiplierEffect4;
    public GameObject RecoveryEffect4;
    public GameObject DashEffect5;
    public GameObject CoinMultiplierEffect5;
    public GameObject RecoveryEffect5;
    public GameObject DashEffect6;
    public GameObject CoinMultiplierEffect6;
    public GameObject RecoveryEffect6;
    public GameObject DashEffect7;
    public GameObject CoinMultiplierEffect7;
    public GameObject RecoveryEffect7;
    public GameObject DashEffect8;
    public GameObject CoinMultiplierEffect8;
    public GameObject RecoveryEffect8;

    public TMP_Text EndGameText;
    public bool EndGame;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        boost = FindObjectsOfType<Boost>();
        
        foreach(Boost s in boost)
        {
            if(s.status == true && s.Name == "Dash")
            {
                StartCoroutine(DashTimer());
                DashController();
            }
            if(s.status == true && s.Name == "Recovery")
            {
                PlayerManager.Recovery = true;
                RecoveryController();
            }
            if(s.status == true && s.Name == "CoinMultiplier")
            {
                // StartCoroutine(CoinMultiplierController());
                Coin.CoinMultiplier = true;
                CoinMultiplierController();
            }
        }
        DashController();
        CoinMultiplierController();
        RecoveryController();

        GameObject[] objectsToAppear = GameObject.FindGameObjectsWithTag("DangerPoint");

        foreach (GameObject objectToApp in objectsToAppear)
        {
            bool alreadyTriggered = false;
            triggeredObjects.TryGetValue(objectToApp, out alreadyTriggered);

            if (!alreadyTriggered)
            {
                float distanceToTrigger = Vector3.Distance(transform.position, objectToApp.transform.position);
                if (distanceToTrigger < radius) // Порігова відстань, коли спрацьовує тригер
                {
                    renderers = objectToApp.GetComponentsInChildren<Renderer>();
                    objectToAppearRigidbody = objectToApp.GetComponent<Rigidbody>();

                    objectToAppearRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
                    foreach (Renderer renderer in renderers)
                    {
                        renderer.enabled = true;
                    }

                    triggeredObjects[objectToApp] = true;
                }
            }
        }

        /*
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/

        //Object that appears in time
        /*
        objectToAppear = GameObject.FindGameObjectWithTag("DangerPoint");
        
        if (objectToAppear != null)
        {
            renderers = objectToAppear.GetComponentsInChildren<Renderer>();
            objectToAppearRigidbody = objectToAppear.GetComponent<Rigidbody>();
        }
        */


        //Player control
        if (!PlayerManager.isGameStarted)
           return;

        //Increase speed
        if (forwardSpeed < maxSpeed + UpgradeManager.MaxSpeedUP)
        {
            forwardSpeed += 0.02f * Time.deltaTime;
            acceleration += 0.02f * Time.deltaTime; 
        }

        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);/*
        if (isGrounded && velocity.y < 0)
            velocity.y = -1f;*/

        if (isGrounded)
        {
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //transform.position = Vector3.Lerp(transform.position, targetPosition, 400 * Time.deltaTime);
        if(transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            {
                controller.Move(moveDir);
            }
            else
            {
                controller.Move(diff);
            }
        }
        /*
        if(transform.position == targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }*/

        //Move Player
        controller.Move(direction * Time.deltaTime);

        if(Dash == true)
        {
            forwardSpeed = 16;
        }
        if(EndGame == true)
        {
            forwardSpeed = 6;
        }
        if(Dash == false && EndGame == false)
        {
            forwardSpeed = acceleration;
        }
    }
    /*
    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted) 
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }*/

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            if(Dash == false)
            {
                PlayerManager.currentHealth -= 20;
            }
            //PlayerManager.currentHealth -= 20;
            Destroy(hit.gameObject);
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.7f, 0);
        controller.height = 1;

        yield return new WaitForSeconds(1.3f);

        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;
    }

    void OnTriggerEnter(Collider other)
    {
        //Trigger appear objects
        /*
        if (other.gameObject.tag == "PlayerTrigger")
        {
            objectToAppearRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
            foreach (Renderer renderer in renderers)
            {
                renderer.enabled = true;
            }
        }
        */
        Collider[] dangerPointsInRange = Physics.OverlapSphere(transform.position, radius, dangerPointLayer);

        float closestDistance = float.MaxValue;
        GameObject closestDangerPoint = null;

        foreach (Collider dangerPointCollider in dangerPointsInRange)
        {
            GameObject dangerPoint = dangerPointCollider.gameObject;
            float distanceToDangerPoint = Vector3.Distance(transform.position, dangerPoint.transform.position);

            if (distanceToDangerPoint < closestDistance)
            {
                closestDistance = distanceToDangerPoint;
                closestDangerPoint = dangerPoint;
            }
        }

        if (closestDangerPoint != null)
        {
            Rigidbody closestDangerPointRigidbody = closestDangerPoint.GetComponent<Rigidbody>();
            Renderer[] closestDangerPointRenderers = closestDangerPoint.GetComponentsInChildren<Renderer>();

            closestDangerPointRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
            foreach (Renderer renderer in closestDangerPointRenderers)
            {
                renderer.enabled = true;
            }
        }

        //End Game
        if(other.gameObject.tag == "EndGame")
        {
            EndGameText.gameObject.SetActive(true);
            EndGame = true;
            StartCoroutine(DeactiveEndGame());
        }
    }

    private IEnumerator DeactiveEndGame()
    {
        yield return new WaitForSeconds(10);
        EndGameText.gameObject.SetActive(false);
        EndGame = false;
    }

    IEnumerator DashTimer()
    {
        foreach (Boost s in boost)
        {
            if (s.Name == "Dash" && s.status == true)
            {
                Dash = true;
                yield return new WaitForSeconds(s.TimeOfAction + UpgradeManager.DashTimeUP);
                Dash = false;
            }
        }
    }

    void DashController()
    {
        if (Dash == true)
        {
            if (VisualEffectManager.number == 1)
            {
                DashEffect.SetActive(true);
            }
            if (VisualEffectManager.number == 2)
            {
                DashEffect1.SetActive(true);
            }
            if (VisualEffectManager.number == 3)
            {
                DashEffect2.SetActive(true);
            }
            if (VisualEffectManager.number == 4)
            {
                DashEffect3.SetActive(true);
            }
            if (VisualEffectManager.number == 5)
            {
                DashEffect4.SetActive(true);
            }
            if (VisualEffectManager.number == 6)
            {
                DashEffect5.SetActive(true);
            }
            if (VisualEffectManager.number == 7)
            {
                DashEffect6.SetActive(true);
            }
            if (VisualEffectManager.number == 8)
            {
                DashEffect7.SetActive(true);
            }
            if (VisualEffectManager.number == 9)
            {
                DashEffect8.SetActive(true);
            }

            /*
            DashEffect.SetActive(true);*/
            DashImage.gameObject.SetActive(true);
        }
        if (Dash == false)
        {
            DashEffect.SetActive(false);
            DashEffect1.SetActive(false);
            DashEffect2.SetActive(false);
            DashEffect3.SetActive(false);
            DashEffect4.SetActive(false);
            DashEffect5.SetActive(false);
            DashEffect6.SetActive(false);
            DashEffect7.SetActive(false);
            DashEffect8.SetActive(false);

            DashImage.gameObject.SetActive(false);
        }
    }
    
    void CoinMultiplierController()
    {
        if(Coin.CoinMultiplier == true)
        {
            if (VisualEffectManager.number == 1)
            {
                CoinMultiplierEffect.SetActive(true);
            }
            if (VisualEffectManager.number == 2)
            {
                CoinMultiplierEffect1.SetActive(true);
            }
            if (VisualEffectManager.number == 3)
            {
                CoinMultiplierEffect2.SetActive(true);
            }
            if (VisualEffectManager.number == 4)
            {
                CoinMultiplierEffect3.SetActive(true);
            }
            if (VisualEffectManager.number == 5)
            {
                CoinMultiplierEffect4.SetActive(true);
            }
            if (VisualEffectManager.number == 6)
            {
                CoinMultiplierEffect5.SetActive(true);
            }
            if (VisualEffectManager.number == 7)
            {
                CoinMultiplierEffect6.SetActive(true);
            }
            if (VisualEffectManager.number == 8)
            {
                CoinMultiplierEffect7.SetActive(true);
            }
            if (VisualEffectManager.number == 9)
            {
                CoinMultiplierEffect8.SetActive(true);
            }

            /*
            CoinMultiplierEffect.SetActive(true);*/
            CoinMultiplierImage.gameObject.SetActive(true);
        }
        if(Coin.CoinMultiplier == false)
        {
            CoinMultiplierEffect.SetActive(false);
            CoinMultiplierEffect1.SetActive(false);
            CoinMultiplierEffect2.SetActive(false);
            CoinMultiplierEffect3.SetActive(false);
            CoinMultiplierEffect4.SetActive(false);
            CoinMultiplierEffect5.SetActive(false);
            CoinMultiplierEffect6.SetActive(false);
            CoinMultiplierEffect7.SetActive(false);
            CoinMultiplierEffect8.SetActive(false);

            CoinMultiplierImage.gameObject.SetActive(false);
        }
    }

    void RecoveryController()
    {
        if(PlayerManager.Recovery == true)
        {
            if (VisualEffectManager.number == 1)
            {
                RecoveryEffect.SetActive(true);
            }
            if (VisualEffectManager.number == 2)
            {
                RecoveryEffect1.SetActive(true);
            }
            if (VisualEffectManager.number == 3)
            {
                RecoveryEffect2.SetActive(true);
            }
            if (VisualEffectManager.number == 4)
            {
                RecoveryEffect3.SetActive(true);
            }
            if (VisualEffectManager.number == 5)
            {
                RecoveryEffect4.SetActive(true);
            }
            if (VisualEffectManager.number == 6)
            {
                RecoveryEffect5.SetActive(true);
            }
            if (VisualEffectManager.number == 7)
            {
                RecoveryEffect6.SetActive(true);
            }
            if (VisualEffectManager.number == 8)
            {
                RecoveryEffect7.SetActive(true);
            }
            if (VisualEffectManager.number == 9)
            {
                RecoveryEffect8.SetActive(true);
            }
            /*
            RecoveryEffect.SetActive(true);*/
            RecoveryImage.gameObject.SetActive(true);
        }
        if(PlayerManager.Recovery == false)
        {
            RecoveryEffect.SetActive(false);
            RecoveryEffect1.SetActive(false);
            RecoveryEffect2.SetActive(false);
            RecoveryEffect3.SetActive(false);
            RecoveryEffect4.SetActive(false);
            RecoveryEffect5.SetActive(false);
            RecoveryEffect6.SetActive(false);
            RecoveryEffect7.SetActive(false);
            RecoveryEffect8.SetActive(false);

            RecoveryImage.gameObject.SetActive(false);
        }
    }

}
