using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KTCommon
{
    public class BusinessLogicException : Exception, ISerializable
    {
        public BusinessLogicException() : base()
        {
            // Add implementation.
        }

        public BusinessLogicException(string message) : base(message)
        {
            // Add implementation.
        }

        public BusinessLogicException(string message, Exception inner) : base(message, inner)
        {
            // Add implementation.
        }

        // This constructor is needed for serialization.
        protected BusinessLogicException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            // Add implementation.
        }
    }
}
