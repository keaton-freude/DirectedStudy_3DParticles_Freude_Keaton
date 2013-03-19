using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Particle3DSample.ParticleSystems
{
    class GenericParticleSystem : ParticleSystem
    {

        public GenericParticleSystem(Game game, ContentManager content) : base(game, content)
        {
        }

        public override void InitializeSettings(ParticleSettings settings)
        {
            
        }
    }
}
