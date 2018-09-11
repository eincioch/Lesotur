using Common;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IPersonaService
    {
        IEnumerable<PersonaForGridView> GetAll();
        ResponseHelper InsertOrUpdate(Persona model);
    }

    public class PersonaService: IPersonaService
    {

        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Persona> _personaRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public PersonaService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Persona> personaRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _personaRepository = personaRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }

        public IEnumerable<PersonaForGridView> GetAll()
        {
            var result = new List<PersonaForGridView>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {

                    result = _personaRepository.GetAll(x => x.TipoDocumento, x => x.CreatedUser)
                        .Select(x => new PersonaForGridView
                        {
                            Id = x.Id,
                            NameCompleto = x.ApePaterno + " " + x.ApeMaterno + ", " + x.Nombres,
                            TipoDocumento = x.TipoDocumento.Descripcion,
                            NroDocumento = x.NumeroDocumento,
                            Sexo =  (x.Genero==0) ?"M":"F",
                            Birthday = x.Birthday,
                            CreatedBy = x.CreatedUser.UserName
                        }).ToList();
                }
            }
            catch (Exception e)
            {

                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdate(Persona model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        _personaRepository.Insert(model);
                    }
                    else
                    {
                        _personaRepository.Update(model);
                    }

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }
    }
}
