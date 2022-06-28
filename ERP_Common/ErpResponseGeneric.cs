

using System;
using System.Runtime.Serialization;
using static ERP_Common.Helpers.Constantes;

namespace ERP_Common
{
    /// <summary>
    ///  validar messagetype
    /// </summary>
    [DataContract]
    public class ErpResponse<T>
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
        public T Result { get; set; }


        public Exception Exception { get; set; }


        public ErpResponse()
        {

        }


        //message
        public ErpResponse(string message)
        {
            this.IsSuccess = false;
            this.Message = message;
            this.MessageCode = 0;
            this.MessageType = MessageType.Warning;
            this.Exception = null;
        }

        public ErpResponse(string message, int messageCode)
        {
            this.IsSuccess = false;
            this.Message = message;
            this.MessageCode = messageCode;
            this.MessageType = MessageType.Warning;
            this.Exception = null;
        }

        public ErpResponse(string message, MessageType messageType)
        {
            this.IsSuccess = false;
            this.Message = message;
            this.MessageCode = 0;
            this.MessageType = messageType;
            this.Exception = null;
        }

        public ErpResponse(string message, int messageCode, MessageType messageType)
        {
            this.IsSuccess = false;
            this.Message = message;
            this.MessageCode = messageCode;
            this.MessageType = messageType;
            this.Exception = null;
        }


        //Exception
        public ErpResponse(Exception exception)
        {
            this.IsSuccess = false;
            this.Message = exception.Message;
            this.MessageCode = 0;
            this.MessageType = MessageType.Bug;
            this.Exception = exception;
        }

        public ErpResponse(Exception exception, int messageCode)
        {
            this.IsSuccess = false;
            this.Message = exception.Message;
            this.MessageCode = messageCode;
            this.MessageType = MessageType.Bug;
            this.Exception = exception;
        }

        public ErpResponse(Exception exception, MessageType messageType)
        {
            this.IsSuccess = false;
            this.Message = exception.Message;
            this.MessageCode = 0;
            this.MessageType = messageType;
            this.Exception = exception;
        }

        public ErpResponse(Exception exception, int messageCode, MessageType messageType)
        {
            this.IsSuccess = false;
            this.Message = exception.Message;
            this.MessageCode = messageCode;
            this.MessageType = messageType;
            this.Exception = exception;
        }


        //result
        public ErpResponse(T result)
        {
            this.IsSuccess = true;
            this.Message = "";
            this.MessageCode = 1;
            this.MessageType = MessageType.Success;
            this.Result = result;
            this.Exception = null;
        }

        public ErpResponse(bool isSuccess, T result)
        {
            this.IsSuccess = isSuccess;
            this.Message = "";
            this.MessageCode = isSuccess ? 1 : 0;
            this.MessageType = isSuccess ? MessageType.Success : MessageType.Warning;
            this.Result = result;
            this.Exception = null;
        }


        public ErpResponse(bool isSuccess, string message, T result)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.MessageCode = isSuccess ? 1 : 0;
            this.MessageType = isSuccess ? MessageType.Success : MessageType.Warning;
            this.Result = result;
            this.Exception = null;
        }


        //todos
        public ErpResponse(bool isSuccess, string message, int messageCode, MessageType messageType, T result, Exception exception)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.MessageCode = messageCode;
            this.MessageType = messageType;
            this.Result = result;
            this.Exception = exception;
        }
    }
}
