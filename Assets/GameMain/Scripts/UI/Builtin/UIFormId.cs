namespace FlappyBird
{
    /// <summary>
    /// 界面编号（对应界面配置表上的界面编号。
    /// </summary>
    public enum UIFormId
    {
        Undefined = 0,

        /// <summary>
        /// 弹出框。
        /// </summary>
        DialogForm = 1,

        /// <summary>
        /// 菜单界面
        /// </summary>
        MenuForm = 100,
 
        /// <summary>
        /// 设置界面
        /// </summary>
        SettingForm = 101,
 
        /// <summary>
        /// 积分界面
        /// </summary>
        ScoreForm = 102,
 
        /// <summary>
        /// 游戏结束界面
        /// </summary>
        GameOverForm = 103
    }
}
