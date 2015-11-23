using DDS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Service
{
    // operations you want to expose
    public interface IGrupoService
    {
        IEnumerable<Grupo> GetGrupos();
        IEnumerable<Grupo> GetGruposByUserId(int id);
        IEnumerable<Grupo> GetGruposPorUsuarioUnido(int id);
        IEnumerable<Grupo> GetGruposByName(string nombre, int idUsuer);
        Grupo GetGrupo(int id);
        void CreateGrupo(Grupo grupo);
        void UpdateGrupo(Grupo grupo);
        void SaveGrupo();

        void DeleteGrupo(Grupo grupo);
    }
}
