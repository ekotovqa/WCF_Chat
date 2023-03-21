using System.ServiceModel;

namespace WCF_Chat
{
    public interface IChatCallbackService
    {
        [OperationContract]
        void MessageCallback(string message);
    }
}
