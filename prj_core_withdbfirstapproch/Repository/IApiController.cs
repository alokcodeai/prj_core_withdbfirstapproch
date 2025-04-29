using Microsoft.AspNetCore.JsonPatch;
using prj_core_withdbfirstapproch.MyModels;

namespace prj_core_withdbfirstapproch.Repository
{
    public interface IApiController<T> where T : BaseEntity
    {
        public Task<T>? Get(int id);
        public Task<T> Post(T entity);
        public Task<T>? Put(T entity);
        public void Delete(int id);
        public Task<IEnumerable<T>>? GetAll();

        public Task<T>? Patch(int id,T entity);
      //  public Task<T>? Patch(int id, JsonPatchDocument<T> entity);

    }
}
