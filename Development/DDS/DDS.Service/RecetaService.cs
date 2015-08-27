using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Service
{
    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository recetasRepository;
        //private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public RecetaService(IRecetaRepository recetasRepository, /*ICategoryRepository categoryRepository,*/ IUnitOfWork unitOfWork)
        {
            this.recetasRepository = recetasRepository;
            //this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IRecetaService Members

        public IEnumerable<Receta> GetRecetas()
        {
            var recetas = recetasRepository.GetAll();
            return recetas;
        }

        //public IEnumerable<Usuario> GetCategoryUsuarios(string categoryName, string usuarioName = null)
        //{
        //    var category = categoryRepository.GetCategoryByName(categoryName);
        //    return category.Usuarios.Where(g => g.Name.ToLower().Contains(usuarioName.ToLower().Trim()));
        //}

        public Receta GetReceta(int id)
        {
            var receta = recetasRepository.GetById(id);
            return receta;
        }

        public void CreateReceta(Receta receta)
        {
            receta.FechaCreacion = DateTime.Now;
            recetasRepository.Add(receta);
        }

        public void UpdateReceta(Receta receta)
        {
            receta.FechaUltimaModificacion = DateTime.Now;
            recetasRepository.Update(receta);
        }

        public void SaveReceta()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
