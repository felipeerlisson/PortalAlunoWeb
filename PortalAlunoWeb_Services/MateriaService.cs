using PortalAlunoWeb_DataAccess.Dapper.Interface;
using PortalAlunoWeb_Domain;
using PortalAlunoWeb_Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Services
{
    public class MateriaService : IMateriaService
    {
        protected readonly IMateriaRepository _materiaRepository;

        public MateriaService(IMateriaRepository materiaRepository) 
        {
            _materiaRepository = materiaRepository;
        }
        public async Task<List<Materia>> BuscarTodasMaterias()
        {
            return await _materiaRepository.BuscarTodasMaterias();
        }

        public void SalvarMateria(Materia materia)
        {
            _materiaRepository.SalvarMateria(materia);
        }
    }

}
