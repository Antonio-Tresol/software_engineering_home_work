namespace MyMath {
    public class Class1 {

    }

    public class Rooter {
        public double SquareRoot(double input) {
            if (input <= 0.0) {
                throw new ArgumentOutOfRangeException();
            }
            double result = input;                  // Initialize the result with the input value
            double previousResult = -input;         // Initialize previousResult with an unlikely value

            // Iterate while the difference between previousResult and result is larger than result / 1000
            while (Math.Abs(previousResult - result) > result / 1000) {
                previousResult = result;            // Store the current result in previousResult
                // Update result using the Newton-Raphson method formula
                result = (result + input / result) / 2;
                // was: result = result - (result * result - input) / (2 * result);
            }

            return result;                          // Return the final approximated square root
        }
    }
}