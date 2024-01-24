using Demo.CA_CQRS_Pub_Sub.Domain.Entity;

namespace Demo.CA_CQRS_Pub_Sub.Domain.IRepository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsAsync();

        Task<Blog> GetByIdAsync(int id);

        Task<Blog> CreateAsync(Blog blog);

        Task<int> UpdateAsync(int id, Blog blog);

        Task<int> DeleteAsync(int id);
    }
}