using RestrictedBoltzmannMachine.ConnectionNamespace;
using RestrictedBoltzmannMachine.Functions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestrictedBoltzmannMachine.NeuronNamespace
{
    public class Neuron : INeuron
    {
        public bool State { get; set; }
        public bool CDState { get; set; }
        public double Bias { get; }
        public List<IConnection> Inputs { get; }
        public List<IConnection> Outputs { get; }


        public Neuron(bool initialState, double bias)
        {
            State = initialState;
            Bias = bias;

            Inputs = new List<IConnection>();
            Outputs = new List<IConnection>();
        }

        public void AddInputNeuron(INeuron inputNeuron, double weight)
        {
            var connection = new Connection(weight, inputNeuron, this);
            Inputs.Add(connection);
            inputNeuron.Outputs.Add(connection);
        }

        public void AddOutputNeuron(INeuron outputNeuron, double weight)
        {
            var connection = new Connection(weight, this, outputNeuron);
            Outputs.Add(connection);
            outputNeuron.Inputs.Add(connection);
        }
    }
}
