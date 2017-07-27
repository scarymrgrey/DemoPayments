using Incoding.CQRS;
using Operations.Persistance;

namespace Operations
{
    public class CreateUserCommand : CommandBase
    {
        public string Password { get; set; }
        public string Login { get; set; }
        protected override void Execute()
        {
            var entity = new User() { Password = Password, Login = Login };
            Repository.Save(entity);
        }
    }
}