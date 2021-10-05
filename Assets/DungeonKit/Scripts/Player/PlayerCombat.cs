using System;
using UnityEngine;

namespace DungeonKIT
{
    public class PlayerCombat : MonoBehaviour
    {
        [Header("Prefabs")]
        public GameObject rangeWeaponPrefab;

        [Header("Parameters")]
        float timeBtwShots;
        public float startTimeBtnShots;

        private void Update() //Every frame
        {
            if (!UIManager.Instance.isPause && GameManager.Instance.isGame) //If pause disable, and is game
            {
                Attack();
            }
        }

        private void FixedUpdate() //Every second considering the physics
        {
            if (!UIManager.Instance.isPause) //if pause disable
            {


                if (InputManager.Attack) //if player press attack button
                {
                    AttackByRate();
                }

            }
        }

        //Attack method
        void Attack()
        {

            if (InputManager.Attack)
            {
                return;
            }
            else
            {
                timeBtwShots = 0;
            }


        }

        //Range attack method
        void RangeAttack()
        {
            GameObject rangeWeapon = Instantiate(rangeWeaponPrefab); //spawn weapon
            rangeWeapon.transform.position = transform.position; //Set weapon postion


            Vector3 mousePosition = Input.mousePosition; //Cache mouse position
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //calculate the mouse position relative to the screen and the world

            Vector2 dir = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y); //calculate angle

            rangeWeapon.transform.up = dir; //Set angle rotation


        }

        //Attack by rate method
        void AttackByRate()
        {
            if (timeBtwShots <= 0)
            {
                RangeAttack(); //Attack
                timeBtwShots = startTimeBtnShots; //set timer again
            }
            else
            {
                timeBtwShots -= Time.deltaTime; //timer - 1 sec
            }

        }

    }
}
