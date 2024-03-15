using Roguelike.Skills;
using UnityEngine;

namespace Roguelike.Units
{
    public abstract class UnitBehaviour
    {
        public string Name;
        protected float speed;
        public GameObject go;
        protected Vector2 moveDirection;
        public Stats stats = new Stats();
        public ElementType type;
        private void SetStats()
        {
            stats.@Speed = 5;
            stats.@HP = 10;
        }

        public virtual void Init(float speed, GameObject go)
        {
            this.speed = speed;
            this.go = go;
            type = ElementType.Default;
            SetStats();
        }
        public virtual void SetSpeed(float speed)
        {
            this.speed = speed;
        }
        public virtual void UnitUpdate()
        {
            if (stats.HP <= 0)
            {
                go.SetActive(false);
                //change to dead method
            }
        }

        public virtual void UnitFixedUpdate()
        {
            
        }

        public abstract void Attack();

        protected Vector3 GetCameraForward()
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;
            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward.Normalize();
            cameraRight.Normalize();
            Vector3 movement = (cameraForward * moveDirection.y + cameraRight * moveDirection.x).normalized;
            return movement;
        }

    }
}