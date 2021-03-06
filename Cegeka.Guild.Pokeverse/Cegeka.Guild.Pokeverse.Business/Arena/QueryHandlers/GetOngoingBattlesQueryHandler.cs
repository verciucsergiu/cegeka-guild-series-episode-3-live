﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cegeka.Guild.Pokeverse.Business.Arena.Models;
using Cegeka.Guild.Pokeverse.Business.Arena.Queries;
using Cegeka.Guild.Pokeverse.Domain.Abstracts;
using Cegeka.Guild.Pokeverse.Domain.Entities;
using MediatR;

namespace Cegeka.Guild.Pokeverse.Business.Arena.QueryHandlers
{
    internal sealed class GetOngoingBattlesQueryHandler : IRequestHandler<GetOngoingBattlesQuery, IEnumerable<OngoingBattleModel>>
    {
        private readonly IReadRepository<Battle> battleReadRepository;

        public GetOngoingBattlesQueryHandler(IReadRepository<Battle> battleReadRepository)
        {
            this.battleReadRepository = battleReadRepository;
        }

        public Task<IEnumerable<OngoingBattleModel>> Handle(GetOngoingBattlesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(battleReadRepository.GetAll()
                .Where(b => b.Winner == null)
                .Select(b => new OngoingBattleModel
                {
                    Id = b.Id,
                    Attacker = b.Attacker.Pokemon.Name,
                    AttackerHealth = b.Attacker.Health,
                    Defender = b.Defender.Pokemon.Name,
                    DefenderHealth = b.Defender.Health,
                    StartedAt = b.StartedAt
                }));
        }
    }
}