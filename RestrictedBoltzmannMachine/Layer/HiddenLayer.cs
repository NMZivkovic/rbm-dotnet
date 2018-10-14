using System.Linq;

namespace RestrictedBoltzmannMachine.LayerNamespace
{
    public class HiddenLayer : Layer
    {
        public HiddenLayer(int numberOfNeurons) : base(numberOfNeurons)
        { }

        public void CalculateState()
        {
            foreach(var neuron in Neurons)
            {
                var probability = _sigmoid.CalculateOutput(neuron.Inputs.Where(x => x.InputNeruon.State).Sum(y => y.Weight));
                neuron.State = probability < _random.NextDouble();
            }
        }

        public override void CalculateCDState()
        {
            foreach (var neuron in Neurons)
            {
                var probability = _sigmoid.CalculateOutput(neuron.Inputs.Where(x => x.InputNeruon.CDState).Sum(y => y.Weight));
                neuron.CDState = probability < _random.NextDouble();
            }
        }
    }
}
