using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using prj_core_withdbfirstapproch.MyModels;

namespace prj_core_withdbfirstapproch.Repository
{
    public class CrudBaseController<T> : ControllerBase, IApiController<T>
     where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public CrudBaseController(IRepository<T> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IEnumerable<T>>? GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<T>? Get(int id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        public async Task<T> Post(T entity)
        {
            return await _repository.Add(entity);
        }

        [HttpPut]
        public async Task<T>? Put(T entity)
        {
            return await _repository.Update(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        [HttpPatch]
        public async Task<T>? Patch(int id, T entity)
        {
            return await _repository.Partial_update(id, entity);
        }


        //[HttpPatch]
        //public async Task<T>? Patch(int id, JsonPatchDocument<T> entity)
        //{
        //    return await _repository.UpdatePartial(id, entity);
        //}
    }
}
