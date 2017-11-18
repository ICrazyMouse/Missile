using MissileText.Missile;
using MissileText.Missile.Api;
using MissileText.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MissileText.MissileController
{
    public class NormalMissileController : Form, IMissileController
    {
        //文字渲染列表
        private List<IMissile> textRenderList;
        //图片渲染列表
        private List<IMissile> imgRenderList;
        //霸屏图片渲染列表
        private List<IMissile> fsImgRenderList;
        //释放队列
        private List<IMissile> releaseRenderList;
        //已全部展示队列
        private List<IMissile> alreadyShowAllList;
        //已全部展示,并且已释放通道队列
        private List<IMissile> releasePipeList;
        //文本等待队列
        private List<IMissile> textQueueList;
        //图片等待队列
        private List<IMissile> imageQueueList;
        //霸屏等待队列
        private List<IMissile> fullScreenQueueList;
        //状态
        private bool started = false;
        //文本通道高度
        private int textPipeHeight = Screen.PrimaryScreen.Bounds.Height / 12;
        //文本四个通道
        private bool[] textPipeUsed;
        //图片通道高度
        private int imgPipeHeight = Screen.PrimaryScreen.Bounds.Height / 3;
        private bool imgPipeUsed = false;
        //霸屏通道
        private bool fsPipeUsed = false;

        //信息检测Timer
        private Timer tmrCheckMissile;
        //队列消费Timer
        private Timer tmrConsumerMissile;

        public NormalMissileController()
        {
            this.InitializeComponent();
            //不在任务栏中显示
            this.ShowInTaskbar = false;
            //最大化，无边框
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            //置顶(ShowInTaskbar = false的操作会使置顶无效化，要在此之后执行)
            Win32.SetWindowPos(this.Handle, -1, 0, 0, 0, 0, 1 | 2);
            //初始化渲染列表
            this.textRenderList = new List<IMissile>();
            this.imgRenderList = new List<IMissile>();
            this.fsImgRenderList = new List<IMissile>();
            this.releaseRenderList = new List<IMissile>();
            this.alreadyShowAllList = new List<IMissile>();
            this.textQueueList = new List<IMissile>();
            this.imageQueueList = new List<IMissile>();
            this.fullScreenQueueList = new List<IMissile>();
            this.releasePipeList = new List<IMissile>();
            //初始化数组
            this.textPipeUsed = new bool[4];
            //初始化信息检测Timer
            tmrCheckMissile = new Timer();
            tmrCheckMissile.Interval = 10;
            tmrCheckMissile.Tick += TmrCheckMissile_Tick;
            //初始化队列消费Timer
            tmrConsumerMissile = new Timer();
            tmrConsumerMissile.Interval = 10;
            tmrConsumerMissile.Tick += TmrConsumerMissile_Tick;
        }
        /// <summary>
        /// 扩展窗口样式值的安位组合，透明
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_TOOLWINDOW = 0x00000080;
                const int WS_EX_LAYERED = 0x00080000;
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle = cParms.ExStyle | WS_EX_LAYERED | WS_EX_TOOLWINDOW;
                return cParms;
            }
        }
        /// <summary>
        /// 检测弹幕信息
        /// 已ShowAll的，释放占用通道
        /// 已Over的，移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrCheckMissile_Tick(object sender, EventArgs e)
        {
            //重置释放池
            this.releaseRenderList.Clear();
            this.alreadyShowAllList.Clear();
            //渲染流程Action
            Action<IMissile> renderAction = missile =>
            {
                //如果弹幕结束，移除
                if (missile.IsOver())
                {
                    this.releaseRenderList.Add(missile);
                }
                if (missile.IsShowAll() && !missile.IsOver() && !this.releasePipeList.Contains(missile))
                {
                    this.alreadyShowAllList.Add(missile);
                }
            };
            //渲染img
            imgRenderList.ForEach(renderAction);
            //渲染text
            textRenderList.ForEach(renderAction);
            //渲染霸屏图片
            fsImgRenderList.ForEach(renderAction);
            //释放失效弹幕
            foreach (IMissile item in this.releaseRenderList)
            {
                this.textRenderList.Remove(item);
                this.imgRenderList.Remove(item);
                this.fsImgRenderList.Remove(item);
                this.releasePipeList.Remove(item);
                this.Controls.Remove((Control)item);
                item.Close();
            }
            //释放通道
            foreach (IMissile item in this.alreadyShowAllList)
            {
                switch (item.Type())
                {
                    case MISSILE_TYPE.TEXT:
                        int pipe = item.getPos().Y == 0 ? 0 : item.getPos().Y / 50;
                        this.textPipeUsed[pipe] = false;
                        this.releasePipeList.Add(item);
                        break;
                    case MISSILE_TYPE.IMAGE:
                        this.imgPipeUsed = false;
                        this.releasePipeList.Add(item);
                        break;
                    case MISSILE_TYPE.FS_IMAGE:
                        this.fsPipeUsed = false;
                        break;
                }
            }
        }
        /// <summary>
        /// 消费等待队列的弹幕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrConsumerMissile_Tick(object sender, EventArgs e)
        {
            if (textQueueList.Count > 0)
            {
                this.SendMissile(textQueueList[0]);
            }
            if (imageQueueList.Count > 0)
            {
                this.SendMissile(imageQueueList[0]);
            }
            if (fullScreenQueueList.Count > 0)
            {
                this.SendMissile(fullScreenQueueList[0]);
            }
        }
        /// <summary>
        /// 获取可用通道
        /// </summary>
        /// <param name="mISSILE_TYPE"></param>
        /// <returns></returns>
        private int getAvaliblePipe(MISSILE_TYPE type)
        {
            int pipe = -1;
            switch (type)
            {
                case MISSILE_TYPE.TEXT:
                    for (int i = 0; i < 4; i++)
                    {
                        if (!this.textPipeUsed[i])
                        {
                            pipe = i;
                            this.textPipeUsed[i] = true;
                            break;
                        }
                    }
                    break;
                case MISSILE_TYPE.IMAGE:
                    if (!this.imgPipeUsed)
                    {
                        this.imgPipeUsed = true;
                        pipe = 1;
                    }
                    break;
                case MISSILE_TYPE.FS_IMAGE:
                    if (!this.fsPipeUsed)
                    {
                        this.fsPipeUsed = true;
                        pipe = 1;
                    }
                    break;
            }
            return pipe;
        }
        /// <summary>
        /// 发送一条新弹幕
        /// </summary>
        /// <param name="obj"></param>
        public void SendMissile(IMissile obj)
        {
            if (!this.isStarted()) return;
            switch (obj.Type())
            {
                case MISSILE_TYPE.TEXT:
                    //队列中还有消息，后来者排队
                    if (textQueueList.Count > 0 && !textQueueList.Contains(obj))
                    {
                        textQueueList.Add(obj);
                    }
                    else
                    {
                        //获取可用通道
                        int textPipe = this.getAvaliblePipe(obj.Type());
                        if (textPipe < 0)//无可用通道，排队
                        {
                            if (!textQueueList.Contains(obj))
                            {
                                textQueueList.Add(obj);
                            }
                        }
                        else
                        {
                            this.addNewMissile(obj, textPipe);
                        }
                    }
                    break;
                case MISSILE_TYPE.IMAGE:
                    //队列中还有消息，后来者排队
                    if (imageQueueList.Count > 0 && !imageQueueList.Contains(obj))
                    {
                        imageQueueList.Add(obj);
                    }
                    else
                    {
                        //获取可用通道
                        int imgPipe = this.getAvaliblePipe(obj.Type());
                        if (imgPipe < 0)//无可用通道，排队
                        {
                            if (!imageQueueList.Contains(obj))
                            {
                                imageQueueList.Add(obj);
                            }
                        }
                        else
                        {
                            this.addNewMissile(obj, imgPipe);
                        }
                    }
                    break;
                case MISSILE_TYPE.FS_IMAGE:
                    if (this.fullScreenQueueList.Count > 0 && !this.fullScreenQueueList.Contains(obj))
                    {
                        this.fullScreenQueueList.Add(obj);
                    }
                    else
                    {
                        //获取可用通道
                        int fsPipe = this.getAvaliblePipe(obj.Type());
                        if (fsPipe < 0)//无可用通道，排队
                        {
                            if (!this.fullScreenQueueList.Contains(obj))
                            {
                                this.fullScreenQueueList.Add(obj);
                            }
                        }
                        else
                        {
                            this.addNewMissile(obj, fsPipe);
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// 新增弹幕
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="pipe"></param>
        private void addNewMissile(IMissile obj, int pipe) {
            this.Controls.Add((Control)obj);
            switch (obj.Type())
            {
                case MISSILE_TYPE.TEXT:
                    textQueueList.Remove(obj);
                    obj.SetStartPos(new Point(Screen.PrimaryScreen.Bounds.Width, pipe * textPipeHeight));
                    obj.Start();
                    this.textRenderList.Add(obj);
                    break;
                case MISSILE_TYPE.IMAGE:
                    imageQueueList.Remove(obj);
                    obj.SetStartPos(new Point(Screen.PrimaryScreen.Bounds.Width, pipe * imgPipeHeight));
                    obj.Start();
                    this.imgRenderList.Add(obj);
                    break;
                case MISSILE_TYPE.FS_IMAGE:
                    ((Control)obj).BringToFront();
                    this.fullScreenQueueList.Remove(obj);
                    obj.Start();
                    this.fsImgRenderList.Add(obj);
                    break;
            }
        }
        /// <summary>
        /// 开始
        /// </summary>
        public void Start()
        {
            this.Show();
            this.started = true;
            tmrCheckMissile.Start();
            tmrConsumerMissile.Start();
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            this.Hide();
            this.started = false;
        }
        /// <summary>
        /// 是否已开始
        /// </summary>
        /// <returns></returns>
        public bool isStarted()
        {
            return this.started;
        }
        /// <summary>
        /// 缩小窗体
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NormalMissileController
            // 
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.Name = "NormalMissileController";
            this.ResumeLayout(false);
        }
    }
}
