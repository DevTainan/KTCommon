using System;
using System.Runtime.Serialization;

namespace KTCommon
{
    /// <summary>
    /// 商務邏輯的例外
    /// </summary>
    public class BusinessLogicException : Exception, ISerializable
    {
        /// <summary>
        /// 建構式
        /// </summary>
        public BusinessLogicException() : base()
        {
            // Add implementation.
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="message"></param>
        public BusinessLogicException(string message) : base(message)
        {
            // Add implementation.
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public BusinessLogicException(string message, Exception inner) : base(message, inner)
        {
            // Add implementation.
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        /// <remarks>
        /// This constructor is needed for serialization.
        /// </remarks>
        protected BusinessLogicException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            // Add implementation.
        }
    }
}
