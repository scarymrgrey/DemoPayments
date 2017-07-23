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
            public int Age { get; set; }
            public string Name { get; set; }
        }

        protected override List<Response> ExecuteResult()
        {
            var responses = Repository.Query<User>().Select(r => new Response()
            {
                Name = r.Name,
                Age = r.Age,
            }).ToList();
            return responses;
        }
    }
}