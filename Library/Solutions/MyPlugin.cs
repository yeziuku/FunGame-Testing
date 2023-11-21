using Milimoe.FunGame.Core.Api.Transmittal;
using Milimoe.FunGame.Core.Interface;
using Milimoe.FunGame.Core.Library.Common.Event;
using Milimoe.FunGame.Core.Library.Common.Plugin;

namespace FunGame.Testing.Solutions
{
    public class MyPlugin : BasePlugin, ILoginEvent, IConnectEvent, IIntoRoomEvent
    {
        public override string Name => "测试插件";

        public override string Description => "My First Plugin";

        public override string Version => "1.0.0";

        public override string Author => "milimoe";

        public MyPlugin()
        {
            
        }

        public void AfterLoginEvent(object sender, LoginEventArgs e)
        {
            WritelnSystemInfo("[" + Name + "] 触发AfterLoginEvent! ");
        }

        public void BeforeLoginEvent(object sender, LoginEventArgs e)
        {
            WritelnSystemInfo("[" + Name + "] 试图登录！账号" + e.Username + "密码" + e.Password);
        }

        public void FailedLoginEvent(object sender, LoginEventArgs e)
        {
            WritelnSystemInfo("[" + Name + "] 登录失败~~");
        }

        public void SucceedLoginEvent(object sender, LoginEventArgs e)
        {
            WritelnSystemInfo("[" + Name + "] 检测到登录成功？？ ");
        }

        public void BeforeConnectEvent(object sender, ConnectEventArgs e)
        {
            WritelnSystemInfo("[" + Name + "] 试图连接服务器！！服务器IP" + e.ServerIP + ":" + e.ServerPort);
        }

        public void AfterConnectEvent(object sender, ConnectEventArgs e)
        {
            WritelnSystemInfo("[" + Name + "] 结果：" + e.ConnectResult);
        }

        public void SucceedConnectEvent(object sender, ConnectEventArgs e)
        {
            WritelnSystemInfo("[" + Name + "] 连接服务器成功！！服务器IP" + e.ServerIP + ":" + e.ServerPort);
        }

        public void FailedConnectEvent(object sender, ConnectEventArgs e)
        {
            WritelnSystemInfo("[" + Name + "] 连接服务器失败！！服务器IP" + e.ServerIP + ":" + e.ServerPort);
        }

        public void BeforeIntoRoomEvent(object sender, RoomEventArgs e)
        {
            
        }

        public void AfterIntoRoomEvent(object sender, RoomEventArgs e)
        {

        }

        public void SucceedIntoRoomEvent(object sender, RoomEventArgs e)
        {
            DataRequest request = NewDataRequest(Milimoe.FunGame.Core.Library.Constant.DataRequestType.Room_GetRoomPlayerCount);
            request.AddRequestData("roomid", e.RoomID);
            request.SendRequest();
            if (request.Result == Milimoe.FunGame.Core.Library.Constant.RequestResult.Success)
            {
                WritelnSystemInfo("[" + Name + "] " + e.RoomID + " 的玩家数量为： " + request.GetResult<int>("count"));
            }
            request.Dispose();
        }

        public void FailedIntoRoomEvent(object sender, RoomEventArgs e)
        {
            
        }
    }
}
