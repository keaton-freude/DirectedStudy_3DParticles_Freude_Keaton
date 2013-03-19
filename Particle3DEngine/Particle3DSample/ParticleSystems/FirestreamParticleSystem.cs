using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Particle3DSample.ParticleSystems
{
    class FirestreamParticleSystem: ParticleSystem
    {
        public FirestreamParticleSystem(Game game, ContentManager content) : base(game, content)
        {
        }

        public override void InitializeSettings(ParticleSettings settings)
        {
            settings.TextureName = "WaterDrop";

            settings.MaxParticles = 15000;

            settings.Duration = TimeSpan.FromSeconds(5);

            settings.MinHorizontalVelocity = 0;
            settings.MaxHorizontalVelocity = 0;

            settings.MinVerticalVelocity = 0;
            settings.MaxVerticalVelocity = 0;

            settings.Gravity = new Vector3(0, -200, 0);

            settings.EndVelocity = 0;

            settings.MinColor = Color.LightBlue;
            settings.MaxColor = Color.LightBlue;

            

            settings.MinRotateSpeed = 0;
            settings.MaxRotateSpeed = 0;

            settings.MinStartSize = 1;
            settings.MaxStartSize = 1;
            
            settings.MinEndSize = 1;
            settings.MaxEndSize = 1;
        }
    }
}
