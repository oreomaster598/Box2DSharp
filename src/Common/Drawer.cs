using Box2DSharp.Dynamics;
using System;
using System.Numerics;

namespace Box2DSharp.Common
{
    public enum DebugDrawColor
    {
		inactiveColor = 0,
		staticBodyColor,
		kinematicBodyColor,
		sleepColor,
		lastColor,

	}
    public class DebugDrawContext
    {
        public DrawFlag context;
        public Body body;
        public int fixtureIndex;
        public int bodyIndex;
        public DebugDrawContext(DrawFlag context, Body body = null, int fixtureIndex = -1, int bodyIndex = -1)
		{
			this.context = context;
			this.body = body;
			this.fixtureIndex = fixtureIndex;
            this.bodyIndex = bodyIndex;
		}
	}
    public interface IDrawer
    {
        DrawFlag Flags { get; set; }

        Color[] GetColors();

        /// Draw a closed polygon provided in CCW order.
        void DrawPolygon(Span<Vector2> vertices, int vertexCount, in Color color, DebugDrawContext context);

        /// Draw a solid closed polygon provided in CCW order.
        void DrawSolidPolygon(Span<Vector2> vertices, int vertexCount, in Color color, DebugDrawContext context);

        /// Draw a circle.
        void DrawCircle(in Vector2 center, float radius, in Color color, DebugDrawContext context);

        /// Draw a solid circle.
        void DrawSolidCircle(in Vector2 center, float radius, in Vector2 axis, in Color color, DebugDrawContext context);

        /// Draw a line segment.
        void DrawSegment(in Vector2 p1, in Vector2 p2, in Color color, DebugDrawContext context);

        /// Draw a transform. Choose your own length scale.
        /// @param xf a transform.
        void DrawTransform(in Transform xf, DebugDrawContext context);

        /// Draw a point.
        void DrawPoint(in Vector2 p, float size, in Color color, DebugDrawContext context);
    }
}