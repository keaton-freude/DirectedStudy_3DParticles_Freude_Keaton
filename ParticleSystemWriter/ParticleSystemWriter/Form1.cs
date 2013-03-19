using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParticleSystemWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Take our submitted values and create a ParticleSettings out of it */
            ParticleSettings settings = new ParticleSettings();

            settings.TextureName = txtTextureName.Text;
            settings.MaxParticles = GetInt(txtMaxParticles.Text);
            settings.Duration = TimeSpan.FromSeconds(GetFloat(txtDuration.Text));
            settings.DurationRandomness = GetFloat(txtDurationRandomness.Text);
            settings.EmitterVelocitySensitivity = GetFloat(txtEmitterVelocitySensitivity.Text);
            settings.MinHorizontalVelocity = GetFloat(txtMinHorizontalVelocity.Text);
            settings.MaxHorizontalVelocity = GetFloat(txtMaxHorizontalVelocity.Text);
            settings.MinVerticalVelocity = GetFloat(txtMinVerticalVelocity.Text);
            settings.MaxVerticalVelocity = GetFloat(txtMaxVerticalVelocity.Text);
            settings.Gravity.X = GetFloat(txtGravityX.Text);
            settings.Gravity.Y = GetFloat(txtGravityY.Text);
            settings.Gravity.Z = GetFloat(txtGravityZ.Text);
            settings.EndVelocity = GetFloat(txtEndVelocity.Text);

            settings.MinColor.R = GetByte(txtMinColorR.Text);
            settings.MinColor.G = GetByte(txtMinColorG.Text);
            settings.MinColor.B = GetByte(txtMinColorB.Text);

            settings.MaxColor.R = GetByte(txtMaxColorR.Text);
            settings.MaxColor.G = GetByte(txtMaxColorG.Text);
            settings.MaxColor.B = GetByte(txtMaxColorB.Text);

            settings.MinRotateSpeed = GetFloat(txtMinRotateSpeed.Text);
            settings.MaxRotateSpeed = GetFloat(txtMaxRotateSpeed.Text);
            settings.MinStartSize = GetFloat(txtMinStartSize.Text);
            settings.MaxStartSize = GetFloat(txtMaxStartSize.Text);
            settings.MinEndSize = GetFloat(txtMinEndSize.Text);
            settings.MaxEndSize = GetFloat(txtMaxEndSize.Text);


            if (cmbBlendState.Text == "Additive")
                settings.BlendState = Microsoft.Xna.Framework.Graphics.BlendState.Additive;
            else
                settings.BlendState = Microsoft.Xna.Framework.Graphics.BlendState.AlphaBlend;

            settings.SaveToFile("Test.xml");
          
        }

        public float GetFloat(string s)
        {
            return (float)Convert.ToDouble(s);
        }

        public int GetInt(string s)
        {
            return Convert.ToInt32(s);
        }

        public byte GetByte(string s)
        {
            return Convert.ToByte(s);
        }
    }
}
