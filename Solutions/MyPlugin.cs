using Milimoe.FunGame.Core.Interface;
using Milimoe.FunGame.Core.Library.Common.Event;
using Milimoe.FunGame.Core.Library.Common.Plugin;
using Milimoe.FunGame.Core.Library.Constant;

namespace FunGame.Testing.Solutions
{
    internal class MyPlugin : BasePlugin, ILoginEvent
    {
        public override string Name => "FunGame Testing Plugin";

        public override string Description => "My First Plugin";

        public override string Version => "1.0.0";

        public override string Author => "FunGamer";

        public MyPlugin()
        {
            
        }

        public EventResult AfterLoginEvent(object sender, LoginEventArgs e)
        {
            return EventResult.Success;
        }

        public EventResult BeforeLoginEvent(object sender, LoginEventArgs e)
        {
            return EventResult.Success;
        }

        public EventResult FailedLoginEvent(object sender, LoginEventArgs e)
        {
            return EventResult.Success;
        }

        public EventResult SucceedLoginEvent(object sender, LoginEventArgs e)
        {
            return EventResult.Success;
        }
    }
}
