#region File Description
//-----------------------------------------------------------------------------
// ParticleSettings.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion
using System.Xml;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Particle3DSample
{
    /// <summary>
    /// Settings class describes all the tweakable options used
    /// to control the appearance of a particle system.
    /// </summary>
    public class ParticleSettings
    {
        // Name of the texture used by this particle system.
        public string TextureName = null;


        // Maximum number of particles that can be displayed at one time.
        public int MaxParticles = 100;


        // How long these particles will last.
        public TimeSpan Duration = TimeSpan.FromSeconds(1);


        // If greater than zero, some particles will last a shorter time than others.
        public float DurationRandomness = 0;


        // Controls how much particles are influenced by the velocity of the object
        // which created them. You can see this in action with the explosion effect,
        // where the flames continue to move in the same direction as the source
        // projectile. The projectile trail particles, on the other hand, set this
        // value very low so they are less affected by the velocity of the projectile.
        public float EmitterVelocitySensitivity = 1;


        // Range of values controlling how much X and Z axis velocity to give each
        // particle. Values for individual particles are randomly chosen from somewhere
        // between these limits.
        public float MinHorizontalVelocity = 0;
        public float MaxHorizontalVelocity = 0;


        // Range of values controlling how much Y axis velocity to give each particle.
        // Values for individual particles are randomly chosen from somewhere between
        // these limits.
        public float MinVerticalVelocity = 0;
        public float MaxVerticalVelocity = 0;


        // Direction and strength of the gravity effect. Note that this can point in any
        // direction, not just down! The fire effect points it upward to make the flames
        // rise, and the smoke plume points it sideways to simulate wind.
        public Vector3 Gravity = Vector3.Zero;


        // Controls how the particle velocity will change over their lifetime. If set
        // to 1, particles will keep going at the same speed as when they were created.
        // If set to 0, particles will come to a complete stop right before they die.
        // Values greater than 1 make the particles speed up over time.
        public float EndVelocity = 1;


        // Range of values controlling the particle color and alpha. Values for
        // individual particles are randomly chosen from somewhere between these limits.
        public Color MinColor = Color.White;
        public Color MaxColor = Color.White;


        // Range of values controlling how fast the particles rotate. Values for
        // individual particles are randomly chosen from somewhere between these
        // limits. If both these values are set to 0, the particle system will
        // automatically switch to an alternative shader technique that does not
        // support rotation, and thus requires significantly less GPU power. This
        // means if you don't need the rotation effect, you may get a performance
        // boost from leaving these values at 0.
        public float MinRotateSpeed = 0;
        public float MaxRotateSpeed = 0;


        // Range of values controlling how big the particles are when first created.
        // Values for individual particles are randomly chosen from somewhere between
        // these limits.
        public float MinStartSize = 100;
        public float MaxStartSize = 100;


        // Range of values controlling how big particles become at the end of their
        // life. Values for individual particles are randomly chosen from somewhere
        // between these limits.
        public float MinEndSize = 100;
        public float MaxEndSize = 100;


        // Alpha blending settings.
        public BlendState BlendState = BlendState.NonPremultiplied;

        public ParticleSettings()
        {
        }

        /* this particle settings will take a path, and build its settings based on that */
        public ParticleSettings(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode n = doc.SelectSingleNode("ParticleSystem");

            TextureName = n.ChildNodes[0].InnerText;
            MaxParticles = Convert.ToInt32(n.ChildNodes[1].InnerText);
            Duration = TimeSpan.FromSeconds(Convert.ToDouble(n.ChildNodes[2].InnerText));
            DurationRandomness = (float)Convert.ToDouble(n.ChildNodes[3].InnerText);
            EmitterVelocitySensitivity = (float)Convert.ToDouble(n.ChildNodes[4].InnerText);
            MinHorizontalVelocity = (float)Convert.ToDouble(n.ChildNodes[5].InnerText);
            MaxHorizontalVelocity = (float)Convert.ToDouble(n.ChildNodes[6].InnerText);
            MinVerticalVelocity = (float)Convert.ToDouble(n.ChildNodes[7].InnerText);
            MaxVerticalVelocity = (float)Convert.ToDouble(n.ChildNodes[8].InnerText);
            Gravity.X = (float)Convert.ToDouble(n.ChildNodes[9].Attributes[0].Value);
            Gravity.Y = (float)Convert.ToDouble(n.ChildNodes[9].Attributes[1].Value);
            Gravity.Z = (float)Convert.ToDouble(n.ChildNodes[9].Attributes[2].Value);
            EndVelocity = (float)Convert.ToDouble(n.ChildNodes[10].InnerText);
            MinColor.R = Convert.ToByte(n.ChildNodes[11].Attributes[0].Value);
            MinColor.G = Convert.ToByte(n.ChildNodes[11].Attributes[1].Value);
            MinColor.B = Convert.ToByte(n.ChildNodes[11].Attributes[2].Value);

            MaxColor.R = Convert.ToByte(n.ChildNodes[12].Attributes[0].Value);
            MaxColor.G = Convert.ToByte(n.ChildNodes[12].Attributes[1].Value);
            MaxColor.B = Convert.ToByte(n.ChildNodes[12].Attributes[2].Value);

            MinRotateSpeed = (float)Convert.ToDouble(n.ChildNodes[13].InnerText);
            MaxRotateSpeed = (float)Convert.ToDouble(n.ChildNodes[14].InnerText);

            MinStartSize = (float)Convert.ToDouble(n.ChildNodes[15].InnerText);
            MaxStartSize = (float)Convert.ToDouble(n.ChildNodes[16].InnerText);

            MinEndSize = (float)Convert.ToDouble(n.ChildNodes[17].InnerText);
            MaxEndSize = (float)Convert.ToDouble(n.ChildNodes[18].InnerText);

            string bs = n.ChildNodes[19].InnerText.Split('.')[1];

            if (bs == "Additive")
                this.BlendState = BlendState.Additive;
            else if (bs == "Alpha")
                this.BlendState = BlendState.AlphaBlend;
            
        }

        public void SaveToFile(string path)
        {
            /* save the current ParticleSettings to file */
            XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.ASCII);

            writer.WriteStartDocument();
            writer.WriteStartElement("ParticleSystem");

            writer.WriteStartElement("TextureName");
            writer.WriteValue(TextureName);
            writer.WriteEndElement();

            writer.WriteStartElement("MaxParticles");
            writer.WriteValue(MaxParticles);
            writer.WriteEndElement();

            writer.WriteStartElement("Duration");
            writer.WriteValue(Duration.TotalSeconds);
            writer.WriteEndElement();

            writer.WriteStartElement("DurationRandomness");
            writer.WriteValue(DurationRandomness);
            writer.WriteEndElement();

            writer.WriteStartElement("EmitterVelocitySensitivity");
            writer.WriteValue(EmitterVelocitySensitivity);
            writer.WriteEndElement();

            writer.WriteStartElement("MinHorizontalVelocity");
            writer.WriteValue(MinHorizontalVelocity);
            writer.WriteEndElement();

            writer.WriteStartElement("MaxHorizontalVelocity");
            writer.WriteValue(MaxHorizontalVelocity);
            writer.WriteEndElement();

            writer.WriteStartElement("MinVerticalVelocity");
            writer.WriteValue(MinVerticalVelocity);
            writer.WriteEndElement();

            writer.WriteStartElement("MaxVerticalVelocity");
            writer.WriteValue(MaxVerticalVelocity);
            writer.WriteEndElement();

            writer.WriteStartElement("Gravity");

            writer.WriteStartAttribute("x");
            writer.WriteValue(Gravity.X);
            writer.WriteEndAttribute();

            writer.WriteStartAttribute("y");
            writer.WriteValue(Gravity.Y);
            writer.WriteEndAttribute();

            writer.WriteStartAttribute("z");
            writer.WriteValue(Gravity.Z);
            writer.WriteEndAttribute();

            writer.WriteEndElement();

            writer.WriteStartElement("EndVelocity");
            writer.WriteValue(EndVelocity);
            writer.WriteEndElement();

            writer.WriteStartElement("MinColor");

            writer.WriteStartAttribute("r");
            writer.WriteValue(MinColor.R);
            writer.WriteEndAttribute();

            writer.WriteStartAttribute("g");
            writer.WriteValue(MinColor.G);
            writer.WriteEndAttribute();

            writer.WriteStartAttribute("b");
            writer.WriteValue(MinColor.B);
            writer.WriteEndAttribute();

            writer.WriteEndElement();

            writer.WriteStartElement("MaxColor");

            writer.WriteStartAttribute("r");
            writer.WriteValue(MaxColor.R);
            writer.WriteEndAttribute();

            writer.WriteStartAttribute("g");
            writer.WriteValue(MaxColor.G);
            writer.WriteEndAttribute();

            writer.WriteStartAttribute("b");
            writer.WriteValue(MaxColor.B);
            writer.WriteEndAttribute();

            writer.WriteEndElement();


            writer.WriteStartElement("MinRotateSpeed");
            writer.WriteValue(MinRotateSpeed);
            writer.WriteEndElement();

            writer.WriteStartElement("MaxRotateSpeed");
            writer.WriteValue(MaxRotateSpeed);
            writer.WriteEndElement();

            writer.WriteStartElement("MinStartSize");
            writer.WriteValue(MinStartSize);
            writer.WriteEndElement();

            writer.WriteStartElement("MaxStartSize");
            writer.WriteValue(MaxStartSize);
            writer.WriteEndElement();

            writer.WriteStartElement("MinEndSize");
            writer.WriteValue(MinEndSize);
            writer.WriteEndElement();

            writer.WriteStartElement("MaxEndSize");
            writer.WriteValue(MaxEndSize);
            writer.WriteEndElement();

            writer.WriteStartElement("BlendState");
            writer.WriteValue(this.BlendState.ToString());
            writer.WriteEndElement();



            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Close();
        }
    }
}
