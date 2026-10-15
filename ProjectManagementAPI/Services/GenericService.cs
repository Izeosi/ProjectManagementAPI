using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Data.Repository;

namespace ProjectManagementAPI.Services
{
    public class GenericService<TEntity, TCreateDTO, TUpdateDTO, TResponseDTO>: 
        IGenericService<TEntity, TCreateDTO, TUpdateDTO, TResponseDTO> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GenericService(IRepository<TEntity> repository, IMapper mapper, ApplicationDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<TResponseDTO>> GetAllAsync()
        {
            var records = await _repository.GetAllAsync();

            return _mapper.Map<List<TResponseDTO>>(records);
        }

        public async Task<TResponseDTO> GetByIdAsync(int id)
        {
            var entityType = _context.Model.FindEntityType(typeof(TEntity));

            if (entityType == null)
            {
                throw new InvalidOperationException($"Entity type {typeof(TEntity).Name} is not part of the EF Core model.");
            }

            var primarykey = entityType.FindPrimaryKey();

            if (primarykey == null || primarykey.Properties.Count != 1)
            {
                throw new InvalidOperationException($"Entity type {typeof(TEntity).Name} does not have a primary key defined.");
            }

            var primaryKeyProperty = primarykey.Properties[0];

            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return default;
            }

            return _mapper.Map<TResponseDTO>(entity);
        }

        public async Task<TResponseDTO> CreateAsync(TCreateDTO createDTO)
        {
            var entity = _mapper.Map<TEntity>(createDTO);
            var entityType = _context.Model.FindEntityType(typeof(TEntity));

            if (entityType == null)
            {
                throw new InvalidOperationException(
                    $"{typeof(TEntity).Name} is not part of the EF Core model.");
            }

            var createdAt = DateTime.UtcNow;

            var dateCreatedProperty = entityType.FindProperty("DateCreated");
            dateCreatedProperty?.PropertyInfo?.SetValue(entity, createdAt);

            var dateModifiedProperty = entityType.FindProperty("DateModified");
            dateModifiedProperty?.PropertyInfo?.SetValue(entity, createdAt);

            var createdEntity = await _repository.CreateAsync(entity);
            return _mapper.Map<TResponseDTO>(createdEntity);
        }

        public async Task<TResponseDTO> UpdateAsync(int id, TUpdateDTO updateDTO)
        {
            var existingEntity = await _context.Set<TEntity>().FindAsync(id);

            if (existingEntity == null)
            {
                return default;
            }

            _mapper.Map(updateDTO, existingEntity);
            var dateModifiedProperty = _context.Model.FindEntityType(typeof(TEntity))?.FindProperty("DateModified");

            dateModifiedProperty?.PropertyInfo?.SetValue(existingEntity, DateTime.UtcNow);

            var updatedEntity = await _repository.UpdateAsync(existingEntity);
            if (updatedEntity == null)
            {
                return default;
            }

            return _mapper.Map<TResponseDTO>(updatedEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingEntity = await _context.Set<TEntity>().FindAsync(id);
            if (existingEntity == null)
            {
                return false;
            }
            return await _repository.DeleteAsync(existingEntity);
        }
    }
}
