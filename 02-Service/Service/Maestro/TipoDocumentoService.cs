using Common;
using Model.Auth;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Maestro
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<TipoDocumento> _tipoDocumentoRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public TipoDocumentoService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<TipoDocumento> tipoDocumentoRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _tipoDocumentoRepository = tipoDocumentoRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }

        public ResponseHelper InsertOrUpdate(TipoDocumento model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        _tipoDocumentoRepository.Insert(model);
                    }
                    else
                    {
                        _tipoDocumentoRepository.Update(model);
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
