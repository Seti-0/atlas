using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Editor;
using Duality.Resources;

using Soulstone.Duality.Plugins.BlueInput;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class BoidGroup : Component, ICmpInitializable, ICmpUpdatable, ICmpMouseDragListener
    {
        public static GeneralParameters GlobalGeneral { get; set; } = new GeneralParameters();
        public static AllSteeringParameters GlobalSteering { get; set; } = new AllSteeringParameters();

        public GeneralParameters General
        {
            get => GlobalGeneral;
            set => GlobalGeneral = value;
        }

        public AllSteeringParameters Steering
        {
            get => GlobalSteering;
            set => GlobalSteering = value;
        }

        public int InitialCount { get; set; }

        public ContentRef<Prefab>  Boid { get; set; }

        public void OnDragEnd(MouseDragEventArgs args)
        {
            if (Boid.Res == null) return;

            var camera = Scene.FindComponent<Camera>();
            if (camera == null) return;

            var origin = camera.GetWorldPos(args.Origin);
            var target = camera.GetWorldPos(args.Pos);

            AddBoid(origin.Xy, target.Xy);
        }

        public void OnDragContinue(MouseDragEventArgs args) { }
        public void OnDragStart(MouseDragEventArgs args){}

        public void OnActivate()
        {
            Random random = new Random();

            if (DualityApp.ExecContext == DualityApp.ExecutionContext.Game)
            {
                for (int i = 0; i < InitialCount; i++)
                {
                    var region = General.Region;
                    region.X += General.Border/3;
                    region.Y += General.Border/3;
                    region.W -= General.Border/3;
                    region.H -= General.Border/3;

                    var A = new Vector2(random.NextFloat(0, 1), random.NextFloat(0, 1));
                    var origin = region.TopLeft + A * region.Size;

                    var B = random.NextFloat(0, MathF.TwoPi);
                    var vector = Vector2.FromAngleLength(B, 1);

                    AddBoid(origin, origin + vector);
                }
            }
        }

        public void OnDeactivate(){}

        private void AddBoid(Vector2 origin, Vector2 target)
        {
            var obj = Boid.Res.Instantiate();
            obj.Name = $"{GameObj.Children.Count}";
            Scene.AddObject(obj);

            obj.Parent = GameObj;

            var transform = obj.Transform;
            if (transform == null) return;

            transform.Pos = new Vector3(origin);

            var localTarget = transform.GetLocalPoint(new Vector3(target));

            transform.LocalAngle = localTarget.Xy.Angle;

            transform.LocalScale = 1;
        }

        public void OnUpdate()
        {
            General.Region = Rect.Align(Alignment.Center, 0, 0, 
                DualityApp.WindowSize.X, DualityApp.WindowSize.Y);
        }
    }
}
