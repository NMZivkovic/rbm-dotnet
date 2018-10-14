using System;
using System.Linq;

namespace RestrictedBoltzmannMachine.LayerNamespace
{
    public class VisibleLayer : Layer
    {
        public VisibleLayer(int numberOfNeurons) : base(numberOfNeurons)
        {
        }

        public override void CalculateCDState()
        {
            foreach (var neuron in Neurons)
            {
                var probability = _sigmoid.CalculateOutput(neuron.Outputs.Where(x => x.InputNeruon.CDState).Sum(y => y.Weight));
                neuron.CDState = probability < _random.NextDouble();
            }
        }

        public void PushValuesToInput(bool[] input)
        {
            if (input.Length != Neurons.Count)
            {
                throw new ArgumentException("Input has invalid size");
            }

            for (int i = 0; i < input.Length; i++)
            {
                Neurons[i].State = input[i];
            }
        }
    }
}
