using RestrictedBoltzmannMachine.Functions;
using RestrictedBoltzmannMachine.NeuronNamespace;
using System;
using System.Collections.Generic;

namespace RestrictedBoltzmannMachine.LayerNamespace
{
    public abstract class Layer
    {
        public List<INeuron> Neurons { get; }

        protected Sigmoid _sigmoid;
        protected Random _random;

        public Layer(int numberOfNeurons)
        {
            Neurons = new List<INeuron>();
            _random = new Random();

            for (int i = 0; i < numberOfNeurons; i++)
            {
                Neurons.Add(new Neuron(GenerateRandomBool(), _random.NextDouble()));
            }
        }

        public void ConnectLayers(Layer layer)
        {
            foreach(var thisNeuron in this.Neurons)
            {
                foreach(var layerNeruon in layer.Neurons)
                {
                    layerNeruon.AddInputNeuron(thisNeuron, _random.NextDouble());
                }
            }
        }

        private bool GenerateRandomBool()
        {
            return _random.NextDouble() > 0.5;
        }

        public abstract void CalculateCDState();
    }
}
