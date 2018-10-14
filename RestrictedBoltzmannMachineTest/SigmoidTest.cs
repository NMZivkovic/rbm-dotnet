using RestrictedBoltzmannMachine.Functions;
using Xunit;
using System;

namespace RestrictedBoltzmannMachineTest
{
    public class SigmoidTest
    {
        [Fact]
        public void CalculateOutput_InputPassed_CorrectOutput()
        {
            var sigmoidFuncion = new Sigmoid(1);

            Assert.Equal(0.56, Math.Round(sigmoidFuncion.CalculateOutput(0.23), 2));
        }
    }
}
