﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTef.net.Action
{
    /// <summary>
    /// Reserves a given value on the Client card, that can be later captured and charged.
    /// </summary>
    public class PreAutorizacaoAction : AbstractAction<Model.PreAuthorizacaoRequest, Model.PreAuthorizacaoResponse>
    {

        public PreAutorizacaoAction(Terminal terminal) : base(ActionType.PRE_AUTORIZACAO, terminal) { }

        protected override Model.PreAuthorizacaoResponse ReadOutput()
        {
            throw new NotImplementedException();
        }
    }
}