*/
using AutoMapper;
using FIRSTBACK.Data;
using Microsoft.EntityFrameworkCore;

namespace FIRSTBACK.Oportunidades

/*{
    public class OportunidadService : IOportunidadService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OportunidadService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Oportunidad>> GetAllAsync()
        {
            return await _context.Oportunidades
                        .Include(o => o.Institucion) // Incluir la relación
                        .ToListAsync();
            /*  return await _context.Oportunidades.ToListAsync(); */
      //* }
      /*

        public async Task<Oportunidad?> GetByIdAsync(int id)
        {
            return await _context.Oportunidades.FindAsync(id);
        }
        public async Task CreateAsync(Oportunidad oportunidad)
        {
            _context.Oportunidades.Add(oportunidad);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var oportunidad = await _context.Oportunidades.FindAsync(id);
            if (oportunidad != null)
            {
                _context.Oportunidades.Remove(oportunidad);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int id, Oportunidad oportunidad)
        {
            var existingOportunidad = await _context.Oportunidades.FindAsync(id);
            if (existingOportunidad != null)
            {
                existingOportunidad.nombre = oportunidad.nombre;
                existingOportunidad.observaciones = oportunidad.observaciones;
                existingOportunidad.tipo = oportunidad.tipo;
                existingOportunidad.descripcion = oportunidad.descripcion;
                existingOportunidad.requisitos = oportunidad.requisitos;
                existingOportunidad.guia = oportunidad.guia;
                existingOportunidad.datos_adicionales = oportunidad.datos_adicionales;
                existingOportunidad.canales_atencion = oportunidad.canales_atencion;
                existingOportunidad.encargado = oportunidad.encargado;
                existingOportunidad.modalidad = oportunidad.modalidad;
                existingOportunidad.id_categoria = oportunidad.id_categoria;

                await _context.SaveChangesAsync();
            }
        }
    }

}/