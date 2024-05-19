using System;

namespace SwimmingClient
{
    public class ClientException : Exception
    {
        public ClientException() : base() {}
        
        public ClientException(string message) : base(message) {}
        
        public ClientException(string message, Exception ex) : base(message, ex) {}
    }
}