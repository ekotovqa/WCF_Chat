using System.ServiceModel;

namespace WCF_Chat
{
    public interface IChatCallbackService
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string message);
    }
}
