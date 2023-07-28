public class OfferProvider {
protected string? offerText;

    public virtual void DisplayOffer()
    {
        Console.WriteLine(offerText);
    }
}

public class CalculatorOfferProvider : OfferProvider {

    public CalculatorOfferProvider(string calculatorContent) {
        offerText = calculatorContent;
    }

    public double CalculateHouseLoan(double loanAmount, double interestRate, int loanTermInMonths) {
        double monthlyInterestRate = interestRate / 12 / 100;
        

        double monthlyPayment = loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, loanTermInMonths)) /
                                (Math.Pow(1 + monthlyInterestRate, loanTermInMonths) - 1);

        return monthlyPayment;
    }
}

class Program
{
    static void Main(string[] args)
    {
    
        var calculatorOffer = new CalculatorOfferProvider("Calculate your house loan monthly payment!");

        double loanAmount = 2350000; 
        double interestRate = 3; 
        int loanTermInMonths = 360;

        double monthlyPayment = calculatorOffer.CalculateHouseLoan(loanAmount, interestRate, loanTermInMonths);
        Console.WriteLine($"Månedlig ydelse: {monthlyPayment:C}");
    }
}

