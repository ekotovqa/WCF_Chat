using System.ServiceModel;

namespace WCF_Chat
{
    public class ChatUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OperationContext OperationContext { get; set; }
    }
}
