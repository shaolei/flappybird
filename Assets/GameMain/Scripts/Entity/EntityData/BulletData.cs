﻿using UnityEngine;

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
 
        /// <summary>
        /// 飞行速度
        /// </summary>
        public float FlySpeed { get; private set; }
 
        public BulletData(int entityId, int typeId,Vector2 shootPositoin,float flySpeed) : base(entityId, typeId)
        {
 
            ShootPostion = shootPositoin;
            FlySpeed = flySpeed;
 
        }
    }
}