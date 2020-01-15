﻿using Cegeka.Guild.Pokeverse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cegeka.Guild.Pokeverse.Persistence.EntityFramework.Configurations
{
    public class BattleConfiguration : IEntityTypeConfiguration<Battle>
    {
        public void Configure(EntityTypeBuilder<Battle> builder)
        {
            builder.HasOne(battle => battle.Attacker)
                .WithOne()
                .HasForeignKey<PokemonInFight>(fight => fight.AttackBattleId);

            builder.HasOne(battle => battle.Defender)
                .WithOne()
                .HasForeignKey<PokemonInFight>(fight => fight.DefendBattleId);

            builder.Ignore(x => x.Winner);
            builder.Ignore(x => x.Loser);

            //builder.HasOne(x => x.Winner)
            //    .WithOne()
            //    .HasForeignKey<Battle>(x => x.WinnerId);

            //builder.HasOne(x => x.Loser)
            //    .WithOne()
            //    .HasForeignKey<Battle>(x => x.LoserId);
        }
    }
}