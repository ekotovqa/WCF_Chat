using System.ServiceModel;

namespace WCF_Chat
{
    [ServiceContract(CallbackContract = typeof(IChatCallbackService)]
    public interface IChatService
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = false)]
        void SendMessage(string message);
    }
}
