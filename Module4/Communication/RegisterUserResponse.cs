using Module4.Models;
using Module4.Models.User;

namespace Module4.Communication
{
    public class RegisterUserResponse : BaseResponse
    {
        public RegisterVM register { get; private set; }
        public RegisterUserResponse(bool success, string message, RegisterVM register) : base(success, message)
        {
        }
        public RegisterUserResponse(RegisterVM register) : this(true, string.Empty, register)
        { }

        public RegisterUserResponse(string message) : this(false, message, null)
        { }
    }
}
