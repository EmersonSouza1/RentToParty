using System;
using System.Runtime.Serialization;

namespace RentToParty.Controllers
{
    [Serializable]
    internal class BusinessException : Exception
    {
        private string v;
        private object exc;

        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string v, object exc)
        {
            this.v = v;
            this.exc = exc;
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}