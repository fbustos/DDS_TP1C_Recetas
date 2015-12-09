using System.Collections;
using System.Globalization;
using System.Linq;
using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;
using System;
using System.Collections.Generic;

namespace DDS.Service
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository consultasRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IUnitOfWork unitOfWork;

        public ConsultaService(IConsultaRepository consultaRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            this.consultasRepository = consultaRepository;
            this.usuarioRepository = usuarioRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IConsultaService Members

        public IEnumerable<Consulta> GetConsultas()
        {
            var consultas = consultasRepository.GetAll();
            return consultas;
        }


        public Consulta GetConsulta(int id)
        {
            var consulta = consultasRepository.GetById(id);
            return consulta;
        }

        public void CreateConsulta(Consulta consulta)
        {
            consulta.FechaCreacion = DateTime.Now;
            consultasRepository.Add(consulta);
        }

        public void SaveConsulta()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<Receta> GetEntreFechas(DateTime? f1, DateTime? f2)
        {
            var consultas = consultasRepository.GetAll().Where(row => (f1 == null || row.FechaCreacion >= f1)
                                                      && (f2 == null || row.FechaCreacion <= f2)).OrderByDescending(row => row.FechaCreacion);

            return consultas.Select(c => c.Receta).Distinct();
        }

        public IEnumerable<IGrouping<int, Receta>> GetEstadisticasSemanales(int? sexo, int? dificultad)
        {
            var consultasFiltradas = consultasRepository.GetAll().Where(c =>
                (sexo == null || sexo == 0 || sexo == (int?)c.Usuario.Perfil.Sexo) &&
                (dificultad == null || dificultad == 0 || dificultad == (int?)c.Receta.Dificultad));

            var consultasAgrupadas = consultasFiltradas.Select(c => new
            {
                semana = weekProjector(c.FechaCreacion) - weekProjector(c.Usuario.FechaCreacion),
                receta = c.Receta
            })
            .GroupBy(x => x.semana, y => y.receta);

            var consultasOrdenadas = consultasAgrupadas.OrderByDescending(g => g.Count());

            return consultasOrdenadas;
        }

        public IEnumerable<IGrouping<int, Receta>> GetEstadisticasMensuales(int? sexo, int? dificultad)
        {
            var consultasFiltradas = consultasRepository.GetAll().Where(c =>
                (sexo == null || sexo == 0 || sexo == (int?)c.Usuario.Perfil.Sexo) &&
                (dificultad == null || dificultad == 0 || dificultad == (int?)c.Receta.Dificultad));

            var consultasAgrupadas = consultasFiltradas.Select(c => new
            {
                semana = monthProjector(c.FechaCreacion) - monthProjector(c.Usuario.FechaCreacion),
                receta = c.Receta
            }).GroupBy(x => x.semana, y => y.receta);

            var consultasOrdenadas = consultasAgrupadas.OrderByDescending(g => g.Count());

            return consultasOrdenadas;
        }

        readonly Func<DateTime, int> weekProjector =
            d => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                d,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Sunday);

        readonly Func<DateTime, int> monthProjector =
           d => CultureInfo.CurrentCulture.Calendar.GetMonthsInYear(
               d.Year);

        #endregion

    }
}
