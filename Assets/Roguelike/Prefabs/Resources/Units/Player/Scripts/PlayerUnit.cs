using System.Collections.Generic;
using System.Linq;
using Roguelike.Skills;
using UnityEngine;
namespace Roguelike.Units
{
    public class PlayerUnit : UnitBehaviour, IService
    {
        private Rigidbody rb;
        private PlayerActions input;
        private List<Skill> m_skills;
        private EffectsList _effectsList;
        
        public override void Init(float speed, GameObject go)
        {
            _effectsList = ServiceLocator.current.Get<EffectsList>();
            InitSkills();
            base.Init(speed, go);
            rb = go.GetComponent<Rigidbody>();
            input = new PlayerActions();
            input.Enable();
            type = ElementType.Fire;
            Name = "Player";
            ServiceLocator.current.Register(this);
        }
        //override stats if u need
        private void InitSkills()
        {
            m_skills = new List<Skill>
            {
                new Fire(_effectsList.GetEffect("Fire")),
                new Water(_effectsList.GetEffects("Water"))
            };
            foreach (var skill in m_skills)
            {
                skill.Set();
            }
        }
        #region Updates
        public override void UnitUpdate()
        {
            base.UnitUpdate();
            m_skills[1].Cooldown(m_skills[1].CooldownTime);
            base.moveDirection = input.Main.Move.ReadValue<Vector2>();
            if(Input.GetKey(KeyCode.E))
                Attack();
            if (Input.GetKeyUp(KeyCode.E))
                StopAttack();
        }
        public override void UnitFixedUpdate()
        {
            Move();
        }
        #endregion
        private void Move()
        {
            rb.velocity = base.GetCameraForward() * speed * Time.fixedDeltaTime;
            LookAtMove();
        }
        private void LookAtMove()
        { 
            if (rb.velocity.magnitude > 0.1f)
            {
                go.transform.rotation = Quaternion.Lerp(go.transform.rotation, Quaternion.LookRotation(rb.velocity.normalized), 10 * Time.deltaTime);
            }
        }
        public override void Attack()
        {
            m_skills[1].Cast(go);
        }
        private void StopAttack()
        {
            m_skills[1].StopCast();
            
        }
    }
}

