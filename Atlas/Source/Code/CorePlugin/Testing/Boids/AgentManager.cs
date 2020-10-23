using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Editor;
using Duality.Resources;
using Soulstone.Duality.Plugins.Atlas.Interface;
using Soulstone.Duality.Plugins.Atlas.Testing.Boids.Behaviours;
using Soulstone.Duality.Plugins.BlueInput;

namespace Soulstone.Duality.Plugins.Atlas.Testing.Boids
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class AgentManager : Component, ICmpInitializable, ICmpUpdatable, ICmpMouseDragListener
    {
        public static Parameters GlobalParameters
        {
            get => Scene.Current.FindComponent<AgentManager>().Parameters.Res;
        }

        private ContentRef<Parameters> _parameters;

        public ContentRef<Parameters> Parameters
        {
            get
            {
                if (_parameters.Res == null)
                {
                    _parameters = ContentProvider
                        .GetAvailableContent<Parameters>()
                        .FirstOrDefault();

                    if (_parameters == null)
                        _parameters = new Parameters();
                }

                return _parameters;
            }

            set => _parameters = value;
        }

        public int FillCount { get; set; }

        public ContentRef<Prefab> AgentPrefab { get; set; }

        [DontSerialize]
        private AgentBehaviour[] _behaviours = new AgentBehaviour[]
        {
            new CohesionBehaviour(),
            new AlignmentBehaviour(),
            new SeparationBehaviour(),
            new ColorBehaviour(),
            new AvoidanceBehaviour(),
            new BasicBehaviour()
        };

        [DontSerialize] private List<IAgent> _agents = new List<IAgent>();
        [DontSerialize] private List<ICmpHostComponent> _hostAgents = new List<ICmpHostComponent>();

        public void OnUpdate()
        {
            Parameters.Res.General.Region = 
                Rect.Align(Alignment.Center, 0, 0, DualityApp.WindowSize.X, DualityApp.WindowSize.Y);

            foreach (var behaviour in _behaviours)
                foreach (var agent in _agents)
                    behaviour.Apply(agent, Time.DeltaTime);

            SyncManager.PushData(_hostAgents);
        }

        public void OnActivate() 
        {
            foreach (var behaviour in _behaviours)
                behaviour.Population = _agents;

            Clear();
            Fill();
        }

        public void OnDeactivate() 
        {
            Clear();
        }

        public void Clear()
        {
            var toRemove = GameObj.Children.ToArray();
            foreach (var item in toRemove)
                item.Dispose();
        }

        public void OnDragEnd(MouseDragEventArgs args)
        {
            var camera = Scene.FindComponent<Camera>();
            if (camera == null) return;

            var origin = camera.GetWorldPos(args.Origin);
            var target = camera.GetWorldPos(args.Pos);

            AddBoid(origin.Xy, target.Xy, push: true);
        }

        public void OnDragContinue(MouseDragEventArgs args) { }
        public void OnDragStart(MouseDragEventArgs args) { }

        private void AddBoid(Vector2 origin, Vector2 target, bool push = false)
        {
            if (AgentPrefab.Res == null) return;

            var obj = AgentPrefab.Res.Instantiate();
            obj.Name = $"{GameObj.Children.Count}";
            Scene.AddObject(obj);

            obj.Parent = GameObj;

            var agent = obj.GetComponent<IAgent>();
            if (agent != null)
            {
                _agents.Add(agent);

                foreach (var behaviour in _behaviours)
                    behaviour.Init(agent);

                agent.ApplyPosition(origin);

                var localTarget = agent.GetLocalPoint(target);
                agent.ApplyAngle(localTarget.Angle);

                agent.ApplyScale(0.2f);

                if (agent is ICmpHostComponent hostCmp)
                {
                    _hostAgents.Add(hostCmp);

                    if (push)
                        SyncManager.PushComponentActivation(hostCmp);
                }
            }
        }

        public void Fill()
        {
            Random random = new Random();

            if (DualityApp.ExecContext == DualityApp.ExecutionContext.Game)
            {
                for (int i = 0; i < FillCount; i++)
                {
                    var general = GlobalParameters.General;

                    var region = general.Region;
                    region.X += general.Margin;
                    region.Y += general.Margin;
                    region.W -= general.Margin;
                    region.H -= general.Margin;

                    var A = new Vector2(random.NextFloat(0, 1), random.NextFloat(0, 1));
                    var origin = region.TopLeft + A * region.Size;

                    var B = random.NextFloat(0, MathF.TwoPi);
                    var vector = Vector2.FromAngleLength(B, 1);

                    AddBoid(origin, origin + vector);
                }

                SyncManager.PushComponentActivation(_hostAgents);
            }
        }
    }
}