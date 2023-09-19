﻿using PrevisaoClimatica.Api.Models;

namespace PrevisaoClimatica.Api.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
