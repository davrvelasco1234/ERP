
using System;
using System.Runtime.Serialization;
using static ERP_Common.Helpers.Constantes;

namespace ERP_Common
{
    [DataContract]
    public class ErpResponse
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public int MessageCode { get; set; }
        [DataMember]
        public MessageType MessageType { get; set; }
        [DataMember]
        public object Result { get; set; }

        public int ExceptionType { get; set; }
        public Exception Exception { get; set; }


        public ErpResponse()
        {

        }


        public ErpResponse(string message)
        {
            this.IsSuccess = false;
            this.Message = message;
            this.MessageCode = 0;
            this.MessageType = MessageType.Bug;
            this.Result = null;
        }

        public ErpResponse(string message, int messageCode)
        {
            this.IsSuccess = false;
            this.Message = message;
            this.MessageCode = messageCode;
            this.MessageType = MessageType.Bug;
            this.Result = null;
        }

        public ErpResponse(string message, MessageType messageType)
        {
            this.IsSuccess = false;
            this.Message = message;
            this.MessageCode = 0;
            this.MessageType = messageType;
            this.Result = null;
        }

        public ErpResponse(string message, int messageCode, MessageType messageType)
        {
            this.IsSuccess = false;
            this.Message = message;
            this.MessageCode = messageCode;
            this.MessageType = messageType;
            this.Result = null;
        }

        public ErpResponse(bool isSuccess, string message, object result)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.MessageCode = isSuccess ? 1 : 0;
            this.MessageType = isSuccess ? MessageType.Success : MessageType.Bug;
            this.Result = result;
        }

        public ErpResponse(object result)
        {
            this.IsSuccess = true;
            this.Message = "";
            this.MessageCode = 1;
            this.MessageType = MessageType.Success;
            this.Result = result;
        }

        public ErpResponse(bool isSuccess, string message, int messageCode, MessageType messageType, object result)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.MessageCode = messageCode;
            this.MessageType = messageType;
            this.Result = result;
        }
    }
}
