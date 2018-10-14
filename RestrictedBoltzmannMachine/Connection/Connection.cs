using RestrictedBoltzmannMachine.NeuronNamespace;

namespace RestrictedBoltzmannMachine.ConnectionNamespace
{
    public class Connection : IConnection
    {
        public double Weight { get; set; }

        public INeuron InputNeruon { get; }
        public INeuron OutputNeruon { get; }

        public Connection(double weight, INeuron inputNeuron, INeuron outputNeuron)
        {
            Weight = weight;
            InputNeruon = inputNeuron;
            OutputNeruon = outputNeuron;
        }

        public void UpdateWeight(double learningRate)
        {
            if (InputNeruon.State & OutputNeruon.State)
            {
                Weight += learningRate;
            }

            if (InputNeruon.CDState & OutputNeruon.CDState)
            {
                Weight -= learningRate;
            }
        }
    }
}
