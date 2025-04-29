using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using prj_core_withdbfirstapproch.MyModels;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using System.Reflection.PortableExecutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace prj_core_withdbfirstapproch.Repository
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Alokcontext _context;

        public SQLRepository(Alokcontext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            var addedEntity = (await _context.AddAsync(entity)).Entity;
            _context.SaveChanges();
            return addedEntity;
        }

        public void Delete(int entityId)
        {
            var entity = _context.Find<T>(entityId);
            if (entity != null) _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<T>? GetById(int entityId)
        {
            var entityType = _context.Model.FindEntityType(typeof(T));
            IQueryable<T> query = _context.Set<T>();
            var navigations = entityType.GetNavigations().ToList();
            foreach (var navigation in navigations)
            {
                query = query.Include(navigation.Name);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(e => e.id == entityId);

            //return await _context.FindAsync<T>(entityId);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var entityType = _context.Model.FindEntityType(typeof(T));
            IQueryable<T> query = _context.Set<T>();
            var navigations = entityType.GetNavigations().ToList();
            foreach (var navigation in navigations)
            {
                query = query.Include(navigation.Name);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            var updatedEntity = _context.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return updatedEntity;
        }



        public async Task<T> Partial_update(int id, T entity)
        {
            var existing_record = await GetById(id);
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (IsCollectionType(property))
                {
                    ICollection existingCollection = (ICollection)property.GetValue(existing_record);
                    ICollection updatedCollection = (ICollection)property.GetValue(entity);

                    foreach (var item in updatedCollection)
                    {
                        var propertyName = "Id";
                        var itemType = item.GetType();
                        var itemIdProperty = itemType.GetProperty(propertyName);
                        var itemIdValue = itemIdProperty?.GetValue(item, null);

                        var value = item.GetType().GetProperty(propertyName)?.GetValue(item, null);
                        var existingItem = existingCollection.Cast<object>().Where(x => x.GetType()
                        .GetProperty(propertyName)?.GetValue(x, null)?.Equals(value) ?? false).FirstOrDefault();

                        PropertyInfo[] propety = existingItem.GetType().GetProperties();
                        foreach (var prop in propety)
                        {

                            var updatedValue = itemType.GetProperty(prop.Name)?.GetValue(item);
                            if (updatedValue != null)
                            {
                                if (prop.CanWrite)
                                {
                                    var convertedValue = Convert.ChangeType(updatedValue, prop.PropertyType);
                                    prop.SetValue(existingItem, convertedValue);
                                }
                            }

                        }
                    }
                }
            }
            UpdateNonNullProperties(existing_record, entity);
            _context.Update(existing_record);
            await _context.SaveChangesAsync();
            return existing_record;
        }
        private void UpdateNonNullProperties<T>(T existing_records, T updatedObject)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (!IsCollectionType(property))
                {
                    var updatedValue = property.GetValue(updatedObject);
                    if (updatedValue != null)
                    {
                        property.SetValue(existing_records, updatedValue);
                    }
                }
            }
        }
        public static bool IsCollectionType(PropertyInfo property)
        {
            return typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
                   && property.PropertyType != typeof(string); // Exclude string
        }


        //[HttpPatch]
        //public async Task<IActionResult> PartiallyUpdateHeaderAndChild(int headerId, JsonPatchDocument<T> headerPatchDoc, int? childId, JsonPatchDocument<T> childPatchDoc)
        //{
        //    // Update header
        //    if (headerPatchDoc != null)
        //    {
        //        var header = await GetById(headerId);

        //        //if (header != null)
        //        //{
        //        //    return NotFound();
        //        //}

        //        headerPatchDoc.ApplyTo(header, ModelState);

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //    }

        //    // Update child
        //    if (childPatchDoc != null && childId.HasValue)
        //    {
        //        var child = await _context.Children.FirstOrDefaultAsync(x => x.Id == childId.Value);

        //        if (child == null)
        //        {
        //            return NotFound();
        //        }

        //        childPatchDoc.ApplyTo(child, ModelState);

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //    }

        //    await _context.SaveChangesAsync();

        //    return new NoContentResult();
        //}

    }
}
