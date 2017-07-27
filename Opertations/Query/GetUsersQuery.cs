using System.Collections.Generic;
using System.Linq;
using Incoding.CQRS;
using Operations.Persistance;

namespace Operations.Query
{
    public class GetUsersQuery : QueryBase<List<GetUsersQuery.Response>>
    {
        public class Response
        {
            public string Password { get; set; }
            public string Login { get; set; }
        }

        protected override List<Response> ExecuteResult()
        {
            var responses = Repository.Query<User>().Select(r => new Response()
            {
                Login = r.Login,
                Password = r.Password,
            }).ToList();
            return responses;
        }
    }
}