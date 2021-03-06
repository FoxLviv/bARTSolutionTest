using System;

namespace bART.Services.CustomExceptions
{
    [Serializable]
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message)
        {
        }
    }
}
