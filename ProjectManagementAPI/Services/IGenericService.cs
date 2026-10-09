namespace ProjectManagementAPI.Services
{
    public interface IGenericService<TEntity, TCreateDTO, TUpdateDTO, TResponseDTO> where TEntity : class
    {
        Task<List<TResponseDTO>> GetAllAsync();
        Task<TResponseDTO> GetByIdAsync(int id);
        Task<TResponseDTO> CreateAsync(TCreateDTO createDto);
        Task<TResponseDTO?> UpdateAsync(int id, TUpdateDTO updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
