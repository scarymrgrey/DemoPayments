using Incoding.CQRS;
using Operations.Persistance;

namespace Operations
{
    public class CreateUserCommand : CommandBase
    {
        public int Age { get; set; }
        public string Name { get; set; }
        protected override void Execute()
        {
            var entity = new User() { Age = Age, Name = Name };
            Repository.Save(entity);
        }
    }
}