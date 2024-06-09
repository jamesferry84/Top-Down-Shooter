using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Projectile : MonoBehaviour
    {
        public int numberOfProjectiles;
        public int speedOfProjectiles;
        public GameObject projectileToFire;
        private SpriteRenderer renderer;

        private void Awake()
        {
            renderer = projectileToFire.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }

        void Fire()
        {
            //get coordinates of mouse click
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            transform.position = mouseWorldPos;
            var origin = mouseWorldPos;
           
            if (projectileToFire != null)
            {
                renderer.color = Color.cyan;
                
                
                Instantiate(projectileToFire, transform.position, Quaternion.identity);
                renderer = projectileToFire.GetComponent<SpriteRenderer>();
                projectileToFire.transform.RotateAround(origin + new Vector3(10,10,0), Vector3.back, 10 * Time.deltaTime);
                Color color = renderer.color;
                color.a = 0f;
                // while (color.a <= 1f)
                // {
                //    color.a += 0.00001f * Time.deltaTime;
                // }
            }
        }

        void AlphaTesting(float alphaValue)
        {
            while (alphaValue <= 1f)
            {
                alphaValue += 0.1f * Time.deltaTime;
            }
            
        }
    }
}