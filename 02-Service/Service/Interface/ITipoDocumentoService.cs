using Common;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITipoDocumentoService
    {
        ResponseHelper InsertOrUpdate(TipoDocumento model);
    }
}
