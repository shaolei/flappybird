using UnityGameFramework.Runtime;

namespace FlappyBird
{
    public class MenuForm : UGuiForm
    {
        /// <summary>
        /// 菜单流程
        /// </summary>
        private ProcedureMenu m_ProcedureMenu = null;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_ProcedureMenu = (ProcedureMenu) userData;
            if (m_ProcedureMenu == null)
            {
                Log.Warning("ProcedureMenu is invalid when open MenuForm.");
                return;
            }
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            m_ProcedureMenu = null;
            base.OnClose(isShutdown, userData);
        }

        public void OnStartButtonClick()
        {
            m_ProcedureMenu.StartGame();
        }

        public void OnSettingButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.SettingForm);
        }
    }
}