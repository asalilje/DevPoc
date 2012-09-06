using NServiceBus;

namespace Deviation.Bus
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With().DisableTimeoutManager();
        }
    }
}
