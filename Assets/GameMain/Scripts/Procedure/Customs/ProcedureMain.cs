
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace FlappyBird
{
    /// <summary>
    /// 主流程
    /// </summary>
    public class ProcedureMain : ProcedureBase
    {
        /// <summary>
        /// 管道产生时间
        /// </summary>
        private float m_PipeSpawnTime = 0f;
 
        /// <summary>
        /// 管道产生计时器
        /// </summary>
        private float m_PipeSpawnTimer = 0f;
        
        /// <summary>
        /// 结束界面ID
        /// </summary>
        private int m_ScoreFormId = -1;
        
        /// <summary>
        /// 是否返回主菜单
        /// </summary>
        private bool m_IsReturnMenu = false;
        
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
 
            m_ScoreFormId = GameEntry.UI.OpenUIForm(UIFormId.ScoreForm).Value;
            GameEntry.Entity.ShowBg(new BgData(GameEntry.Entity.GenerateSerialId(), 1, 1f, 0));
            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(), 3, 5f));
            //设置初始管道产生时间
            m_PipeSpawnTime = Random.Range(3f, 5f);
            
            //订阅事件
            GameEntry.Event.Subscribe(ReturnMenuEventArgs.EventId, OnReturnMenu);
        }
        
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
 
            m_PipeSpawnTimer += elapseSeconds;
            if (m_PipeSpawnTimer >= m_PipeSpawnTime)
            {
                m_PipeSpawnTimer = 0;
                //随机设置管道产生时间
                m_PipeSpawnTime = Random.Range(3f, 5f);
 
                //产生管道
                GameEntry.Entity.ShowPipe(new PipeData(GameEntry.Entity.GenerateSerialId(), 2, 1f));
 
            }
            
            //切换场景
            if (m_IsReturnMenu)
            {
                m_IsReturnMenu = false;
                procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Menu"));
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }
        
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
 
            GameEntry.UI.CloseUIForm(m_ScoreFormId);
            //取消订阅事件
            GameEntry.Event.Unsubscribe(ReturnMenuEventArgs.EventId, OnReturnMenu);
        }
        
        private void OnReturnMenu(object sender, GameEventArgs e)
        {
            m_IsReturnMenu = true;
        }
    }
}
