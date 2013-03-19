#region File Description
//-----------------------------------------------------------------------------
// SmokePlumeParticleSystem.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace Particle3DSample
{
    /// <summary>
    /// Custom particle system for creating a giant plume of long lasting smoke.
    /// </summary>
    class SmokePlumeParticleSystem : ParticleSystem
    {
        public SmokePlumeParticleSystem(Game game, ContentManager content)
            : base(game, content)
        { }


        public override void InitializeSettings(ParticleSettings settings)
        {
            settings.TextureName = "smoke";

            settings.MaxParticles = 2200;

            settings.Duration = TimeSpan.FromSeconds(6);

            settings.MinHorizontalVelocity = 0;
            settings.MaxHorizontalVelocity = 0;

            settings.MinVerticalVelocity = 100;
            settings.MaxVerticalVelocity = 100;

            // Create a wind effect by tilting the gravity vector sideways.
            settings.Gravity = new Vector3(100, -5, 0);

            settings.EndVelocity = 0.75f;

            settings.MinRotateSpeed = 0;
            settings.MaxRotateSpeed = 0;

            settings.MinColor = Color.Yellow;
            settings.MaxColor = Color.Red;

            settings.MinStartSize = 4;
            settings.MaxStartSize = 7;

            settings.MinEndSize = 35;
            settings.MaxEndSize = 140;

            settings.BlendState = BlendState.Additive;
        }
    }
}
