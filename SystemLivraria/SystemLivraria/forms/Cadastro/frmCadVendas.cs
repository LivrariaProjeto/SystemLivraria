using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLivraria.forms.Cadastro
{
    public sealed class frmCadVendas : frmOperacaoComercial
    {
        public frmCadVendas(int idUsuario)
            : base(true, idUsuario)
        {
        }
    }
}
