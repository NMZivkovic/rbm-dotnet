using RestrictedBoltzmannMachine.ConnectionNamespace;
using System.Collections.Generic;

namespace RestrictedBoltzmannMachine.NeuronNamespace
{
    public interface INeuron
    {
        bool State { get; set; }
        bool CDState { get; set; }
        double Bias { get; }
        List<IConnection> Inputs { get; }
        List<IConnection> Outputs { get; }

        void AddInputNeuron(INeuron inputNeuron, double weight);
        void AddOutputNeuron(INeuron outputNeuron, double weight);
    }
}
