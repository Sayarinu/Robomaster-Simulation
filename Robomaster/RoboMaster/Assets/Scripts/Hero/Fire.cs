using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Fire : NetworkBehaviour {

        private float timeBetweenBullets;        // The time between each shot.
        public float MaxFrequence = 5;
        public int CurrentFrequence;
        [SyncVar]
        public float CurrentFiringRate;
        public float MaxRate = 16;
        public float MinRate = 14;
        public int CurrentBulletnum = 20;
        private int Frequencenum;
        private float timer;
        private float FreTimer;
        private float getbulletTimer;
        public GameObject Bullet;
        private GameObject bullets;
        public Transform FirePoint1;
        public Transform FirePoint2;
        public Transform LaserPoint;
        private Rigidbody bulletsRig;
        private bool fireflag =false;
        [SyncVar]
        public Vector3 f;
        private Light Laser;
        //private IslandSupportBullet islandsupportbullet;
    void Start(){
      CurrentBulletnum = 100;
    }
    void Awake ()
        {
            Laser = LaserPoint.GetComponent<Light>();
            timeBetweenBullets = 1 / MaxFrequence;
            //islandsupportbullet = GameObject.Find("IslandCollider").GetComponent<IslandSupportBullet>();
    }


        void Update()
        {

            bool fire = true;//Input.GetKey(KeyCode.F);

            timer += Time.deltaTime;
            FreTimer += Time.deltaTime;
            getbulletTimer += Time.deltaTime;
            getbullet();
        if (FreTimer > 1.0f)
            {
                CurrentFrequence = Frequencenum;
                FreTimer = 0;
                Frequencenum = 0;
            }
            if (fire)
            {
                fireflag = true;//!fireflag;
            }
            // Add the time since Update was last called to the timer.

            if (fireflag)
            {
                Laser.enabled = true;
                //Input.GetButton("Fire1")
                if ((Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)) && timer >= timeBetweenBullets && Time.timeScale != 0 && CurrentBulletnum > 0)
                {

                    CmdShoot();
                    CurrentBulletnum--;
                    Frequencenum++;
                    timer = 0f;
                }
            }
            else { Laser.enabled = false; }




        }

    [Command]
        void CmdShoot()
        {
            f = (FirePoint1.position - FirePoint2.position).normalized;
            CurrentFiringRate = Random.Range(MinRate, MaxRate);
            bullets = (GameObject)Instantiate(Bullet,FirePoint1.position,FirePoint1.rotation);
            bulletsRig=bullets.GetComponent<Rigidbody>();
            bulletsRig.velocity = f * CurrentFiringRate;
            //Destroy(bullets,2f);
            NetworkServer.Spawn(bullets);
        }

    void getbullet()
    {/*
        if (islandsupportbullet.Islandcheckinflag && getbulletTimer >= 0.2f)
        {
            CurrentBulletnum++;
            getbulletTimer = 0f;
        }*/
    }




    }
