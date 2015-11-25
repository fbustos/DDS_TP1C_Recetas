using System.Linq;
using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;
using System;
using System.Collections.Generic;

namespace DDS.Service
{
    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository recetasRepository;
        private readonly IIngredienteRepository ingredienteRepository;
        private readonly ICondimentoRepository condimentoRepository;
        private readonly IUnitOfWork unitOfWork;

        public RecetaService(IRecetaRepository recetasRepository, IIngredienteRepository ingredienteRepository, ICondimentoRepository condimentoRepository, IUnitOfWork unitOfWork)
        {
            this.recetasRepository = recetasRepository;
            this.ingredienteRepository = ingredienteRepository;
            this.condimentoRepository = condimentoRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IRecetaService Members

        public IEnumerable<Receta> GetRecetas()
        {
            var recetas = recetasRepository.GetAll();
            return recetas;
        }

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

        public void DeleteReceta(Receta receta)
        {
            recetasRepository.Delete(receta);
        }

        public void SaveReceta()
        {
            unitOfWork.Commit();
        }

        public IList<Ingrediente> GetIngredientes()
        {
            return this.ingredienteRepository.GetAll().ToList();
        }

        public IList<Condimento> GetCondimentos()
        {
            return this.condimentoRepository.GetAll().ToList();
        }

        public Ingrediente GetIngredienteById(int id)
        {
            return this.ingredienteRepository.GetById(id);
        }

        public Condimento GetCondimentoById(int id)
        {
            return this.condimentoRepository.GetById(id);
        }

        #endregion

    }
}
