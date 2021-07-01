using UnityEngine;

namespace FlappyBird
{
    /// <summary>
    /// 子弹实体数据
    /// </summary>
    public class BulletData : EntityData
    {
        /// <summary>
        /// 发射位置
        /// </summary>
        public Vector2 ShootPostion { get; private set; }
        
        [SerializeField]
        private CampType m_OwnerCamp = CampType.Unknown;
        
        [SerializeField]
        private int m_Attack = 0;
 
        /// <summary>
        /// 飞行速度
        /// </summary>
        public float FlySpeed { get; private set; }
 
        public BulletData(int entityId, int typeId,Vector2 shootPositoin,float flySpeed) : base(entityId, typeId)
        {
 
            ShootPostion = shootPositoin;
            FlySpeed = flySpeed;
 
        }
        
        public CampType OwnerCamp
        {
            get
            {
                return m_OwnerCamp;
            }
        }
        
        public int Attack
        {
            get
            {
                return m_Attack;
            }
        }
    }
}