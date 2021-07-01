﻿using GameFramework;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace FlappyBird
{
    /// <summary>
    /// 游戏结束界面
    /// </summary>
    public class GameOverForm : UGuiForm
    {
        public Text Score;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            //获取分数
            int score = GameEntry.DataNode.GetNode("Score").GetData<VarInt32>();
            Score.text = "你的总分：" + score;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
            Score.text = string.Empty;
        }

        public void OnRestartButtonClick()
        {
            Close(true);
            //派发重新开始游戏事件
            GameEntry.Event.Fire(this, ReferencePool.Acquire<RestartEventArgs>());

            //显示小鸟
            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(), 3, 5f));
        }

        public void OnReturnButtonClick()
        {
            Close(true);
            //派发返回菜单场景事件
            GameEntry.Event.Fire(this, ReferencePool.Acquire<ReturnMenuEventArgs>());
        }
    }
}