﻿using System;
using MediatR;

namespace Cegeka.Guild.Pokeverse.Business.Battles.Commands
{
    public class UseAbilityCommand : IRequest
    {
        public UseAbilityCommand(Guid battleId, Guid participantId, Guid abilityId)
        {
            BattleId = battleId;
            ParticipantId = participantId;
            AbilityId = abilityId;
        }
        public Guid BattleId { get; }
        
        public Guid ParticipantId { get; }
        
        public Guid AbilityId { get; }
    }
}