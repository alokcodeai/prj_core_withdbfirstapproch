using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prj_core_withdbfirstapproch.MyModels;
using prj_core_withdbfirstapproch.Repository;

namespace prj_core_withdbfirstapproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CrudBaseController<Customer>
    {
        public CustomerController(IRepository<Customer> repository) : base(repository)
        {
        }
    }
}
