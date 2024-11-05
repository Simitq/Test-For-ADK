using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    //[SerializeField] Transform _trans;
    public Camera fps_cam;
    int distance = 3;
    public bool take;
    public GameObject eButton;
    public GameObject gButton;
    public Transform posi;
    public Transform posBackGround;



    void Start()
    {
        Time.timeScale = 1;
          
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = fps_cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance) && hit.collider.tag == "Car" && take == true)
        {
           gButton.SetActive(true);
           if (Input.GetKeyDown(KeyCode.G))
                {
                  PushItem();
                }
        }

        if (Physics.Raycast(ray, out hit, distance) && hit.collider.tag == "TakeE" && take == false)
        {
            eButton.SetActive(true);
            
            _rb = hit.collider.gameObject.GetComponent<Rigidbody>();
            

            if (Input.GetKeyDown(KeyCode.E) && take != true)
            {
                take = true;
                TakeItem();

            }
            
        }
        else
        {
            eButton.SetActive(false);
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
    }

    public void TakeItem()
    {
        take = true;
        _rb.isKinematic = true;
        _rb.MovePosition(posi.position);
       
    }
    public void PushItem()
    {
        take = false;
        gButton.SetActive(false);
        _rb.isKinematic = false;
        _rb.position = posBackGround.position;
        

    }

    private void FixedUpdate()
    {
        if (_rb != null)
        {
            if(_rb.isKinematic != false)
                _rb.gameObject.transform.position = posi.position;
        }
    }

    

}
