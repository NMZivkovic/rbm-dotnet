using RestrictedBoltzmannMachine.LayerNamespace;

namespace RestrictedBoltzmannMachineTest
{
    public class TestLayer : Layer
    {
        public TestLayer(int numberOfNeurons) : base(numberOfNeurons)
        { }

        public override void CalculateCDState()
        {
            throw new System.NotImplementedException();
        }
    }
}
