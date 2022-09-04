using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;


namespace Arhlon.Projectiles
{
    internal abstract class WhipProjectile : ModProjectile
    {
        public int segments = 30;
        public float rangeMultiplier = 1f;

        public virtual void SafeSetDefaults() { }
        
        public virtual void CustomAI() { }

        public sealed override void SetDefaults()
        {
            Projectile.DefaultToWhip();
            SafeSetDefaults();
        }

        public sealed override void PostAI()
        {
            Projectile.GetWhipSettings(Projectile, out var timeToFlyOut, out var _, out var _);
            if (Projectile.ai[0] == (float)(int)(timeToFlyOut / 2f))
            {
                Projectile.WhipPointsForCollision.Clear();
                FillWhipControlPoints(Projectile.WhipPointsForCollision);
                Vector2 position = Projectile.WhipPointsForCollision[Projectile.WhipPointsForCollision.Count - 1];
                SoundEngine.PlaySound(SoundID.Item153, position);
            }

            CustomAI();
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects spriteEffects = 0;
            if (Projectile.spriteDirection == 1)
            {
                spriteEffects = (SpriteEffects)((int)spriteEffects ^ 1);
            }
            Texture2D whipTexture = TextureAssets.Projectile[Projectile.type].Value;
            Rectangle rectangle = whipTexture.Frame(1, 5);
            int height = rectangle.Height;
            rectangle.Height -= 2;
            Vector2 center = rectangle.Size() / 2f;
            List<Vector2> controlPoints = new();
            FillWhipControlPoints(controlPoints);

            Vector2 currentPosition = controlPoints[0];
            for (int i = 0; i < controlPoints.Count - 1; i++)
            {
                Vector2 origin = center;
                float scale = 1f;
                if (i == 0)
                {
                    origin.Y -= 4f;
                }
                else
                {
                    int frame = 1;
                    if (i > 10)
                    {
                        frame = 2;
                    }
                    if (i > 30)
                    {
                        frame = 3;
                    }
                    rectangle.Y = height * frame;
                }
                if (i == controlPoints.Count - 2)
                {
                    rectangle.Y = height * 4;
                    Projectile.GetWhipSettings(Projectile, out var timeToFlyOut, out _, out _);
                    float t = Projectile.ai[0] / timeToFlyOut;
                    float amount = Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true);
                    scale = MathHelper.Lerp(0.5f, 1.5f, amount);
                }
                Vector2 currentPoint = controlPoints[i];
                Vector2 offsetPoint = controlPoints[i + 1] - currentPoint;
                float rotation = offsetPoint.ToRotation() - MathHelper.PiOver2;
                Color color = Lighting.GetColor(currentPoint.ToTileCoordinates());
                Main.spriteBatch.Draw(
                    whipTexture,
                    currentPosition - Main.screenPosition,
                    (Rectangle?)rectangle,
                    color,
                    rotation,
                    origin,
                    scale,
                    spriteEffects,
                    0f
                );
                currentPosition += offsetPoint;
            }
            return false;
        }

        private void FillWhipControlPoints(List<Vector2> list)
        {

            Projectile.GetWhipSettings(Projectile, out var timeToFlyOut, out var _, out var _);
            float num = Projectile.ai[0] / timeToFlyOut;
            float num10 = 0.5f;
            float num11 = 1f + num10;
            float num12 = (float)Math.PI * 10f * (1f - num * num11) * (float)(-Projectile.spriteDirection) / (float)segments;
            float num13 = num * num11;
            float num14 = 0f;
            if (num13 > 1f)
            {
                num14 = (num13 - 1f) / num10;
                num13 = MathHelper.Lerp(1f, 0f, num14);
            }
            float num15 = Projectile.ai[0] - 1f;
            Player player = Main.player[Projectile.owner];
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            num15 = (float)(ContentSamples.ItemsByType[heldItem.type].useAnimation * 2) * num * player.whipRangeMultiplier;
            float num16 = Projectile.velocity.Length() * num15 * num13 * rangeMultiplier / (float)segments;
            float num17 = 1f;
            Vector2 playerArmPosition = Main.GetPlayerArmPosition(Projectile);
            Vector2 vector = playerArmPosition;
            float num2 = -(float)Math.PI / 2f;
            Vector2 value = vector;
            float num3 = (float)Math.PI / 2f + (float)Math.PI / 2f * (float)Projectile.spriteDirection;
            Vector2 value2 = vector;
            float num4 = (float)Math.PI / 2f;
            list.Add(playerArmPosition);
            for (int i = 0; i < segments; i++)
            {
                float num5 = (float)i / (float)segments;
                float num6 = num12 * num5 * num17;
                Vector2 vector2 = vector + num2.ToRotationVector2() * num16;
                Vector2 vector3 = value2 + num4.ToRotationVector2() * (num16 * 2f);
                Vector2 val = value + num3.ToRotationVector2() * (num16 * 2f);
                float num7 = 1f - num13;
                float num8 = 1f - num7 * num7;
                Vector2 value3 = Vector2.Lerp(vector3, vector2, num8 * 0.9f + 0.1f);
                Vector2 value4 = Vector2.Lerp(val, value3, num8 * 0.7f + 0.3f);
                Vector2 spinningpoint = playerArmPosition + (value4 - playerArmPosition) * new Vector2(1f, num11);
                float num9 = num14;
                num9 *= num9;
                Vector2 item = spinningpoint.RotatedBy(Projectile.rotation + 4.712389f * num9 * (float)Projectile.spriteDirection, playerArmPosition);
                list.Add(item);
                num2 += num6;
                num4 += num6;
                num3 += num6;
                vector = vector2;
                value2 = vector3;
                value = val;
            }
        }
    }
}