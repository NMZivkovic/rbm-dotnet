using RestrictedBoltzmannMachine.NeuronNamespace;

namespace RestrictedBoltzmannMachine.ConnectionNamespace
{
    public interface IConnection
    {
        double Weight { get; set; }
        INeuron InputNeruon { get; }
        INeuron OutputNeruon { get; }
        void UpdateWeight(double learningRate);
    }
}
