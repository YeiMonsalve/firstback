using BackendProject.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace firstback.categorias
{
    public class CategoriasService : ICategoriasService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriasService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categorias?> GetByIDAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<int> CreateAsync(CategoriasDTO categoriasDTO)
        {
            Categorias categorias = _mapper.Map<Categorias>(categoriasDTO);
            _context.Categorias.Add(categorias);
            await _context.SaveChangesAsync();

            return categorias.id;
        }

        public async Task UpdateAsync(int id, CategoriasDTO categoriasDTO)
        {
            var existingCategoria = await _context.Categorias.FindAsync(id);

            if (existingCategoria != null)
            {
                _mapper.Map(categoriasDTO, existingCategoria);
                _context.Categorias.Update(existingCategoria);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var existingCategoria = await _context.Categorias.FindAsync(id);

            if (existingCategoria != null)
            {
                _context.Categorias.Remove(existingCategoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}