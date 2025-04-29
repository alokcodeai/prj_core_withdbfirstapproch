using Azure;
using Microsoft.AspNetCore.JsonPatch;
using prj_core_withdbfirstapproch.MyModels;

namespace prj_core_withdbfirstapproch.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        void Delete(int entityId);
        Task<T>? GetById(int entityId);
        Task<IEnumerable<T>> GetAll();

       // Task<T> UpdatePartial(int id, JsonPatchDocument<T> entity);
        Task<T> Partial_update(int id, T entity);
   
    }
}
